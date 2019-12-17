using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace PlanC.DocumentGeneration
{
    /// <summary>
    ///     Définit un objet pouvant résolver des ressources XML incorporées dans un assembly.
    /// </summary>
    internal sealed class XmlResourceResolver : XmlResolver
    {
        //Les constantes des groupes de nom du regex pour le URI.
        private const string GRP_NAME_RESOURCE_FILE = "ResourceFile";
        private const string GRP_NAME_RESOURCE_ITEM = "ResourceItem";

        //Le regex pour valider le URI absolu et en extraire les infos. Notons qu'il n'accepte que les lettres, les
        //chiffres et les points dans les noms. Or, un fichier de ressource accepte bien d'autres caractères. Il y a
        //aussi certainement d'autres contraintes qu'on n'applique pas.
        private static readonly Regex uriRegex = new Regex(
            @$"^res:(?<{GRP_NAME_RESOURCE_FILE}>[A-Z][A-Z0-9.]*)\/(?<{GRP_NAME_RESOURCE_ITEM}>[A-Z][A-Z0-9.]*)$",
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        //Les champs d'instance
        private Assembly _assembly;
        private CultureInfo _cultureInfo;
        private HashSet<ResourceManager> _cachedResourceManagers;

        /// <summary>
        ///     Construit un nouveau <see cref="XmlResourceResolver"/> pouvant obtenir des ressources de l'assembly
        ///     spécifié.
        /// </summary>
        /// <param name="assembly">
        ///     L'assembly principal dans lequel rechercher les resources.
        /// </param>
        /// <param name="cultureInfo">
        ///     La culture dans laquelle obtenir les resources. Si ce paramètre n'est pas spécifié ou est <c>null</c>,
        ///     la culture du thread actuel sera utilisée.
        /// </param>
        public XmlResourceResolver(Assembly assembly, CultureInfo? cultureInfo = null)
        {
            _assembly = assembly ?? throw new ArgumentNullException(nameof(assembly));
            _cultureInfo = cultureInfo ?? CultureInfo.CurrentCulture;
            _cachedResourceManagers = new HashSet<ResourceManager>();
        }

        /// <summary>
        ///     Obtient un object correspondant à la ressource identifiée par l'URI spécifié.
        /// </summary>
        /// <param name="absoluteUri">
        ///     Un <see cref="Uri"/> absolu identifiant la resource à obtenir. Le format attendu est
        ///     <c>res:&lt;ResourceFile&gt;/&lt;ResourceItem&gt;</c>, où
        ///     <list type="bullet">
        ///         <item>
        ///             <term>&lt;ResourceFile&gt;</term>
        ///             <description>le nom du fichier de ressource sans extension ni suffixe de culture.</description>
        ///         </item>
        ///         <item>
        ///             <term>&lt;ResourceItem&gt;</term>
        ///             <description>le nom de la ressource.</description>
        ///         </item>
        ///     </list>
        /// </param>
        /// <param name="role">
        ///     Ignoré.
        /// </param>
        /// <param name="ofObjectToReturn">
        ///     Le type de l'objet à retourner. Ce paramètre doit, soit correspondre au type de la ressource, ou être
        ///     assignable d'un <see cref="MemoryStream"/>. Si ce paramètre n'est pas spécifié ou s'il est <c>null</c>,
        ///     <see cref="MemoryStream"/> est supposé.
        /// </param>
        /// <returns>
        ///     La ressource dans son type d'origine ou un <see cref="MemoryStream"/>.
        /// </returns>
        public override object GetEntity(Uri absoluteUri, string? role, Type? ofObjectToReturn = null)
        {
            //Valide et extrait les paramètres de l'URI
            var (resourceFileName, resourceItemName) = ParseUri(absoluteUri);

            //Crée le resource manager. Remarque : si resourceFileName n'est pas valide, c'est GetObject qui va lancer
            //une exception, puisque la validation du nom de fichier se fait en différé.
            var resourceFile = GetCachedResourceManager(resourceFileName);

            //Obtient la ressource
            var resource = resourceFile.GetObject(resourceItemName, _cultureInfo);
            if (resource == null)
                throw new FileNotFoundException(
                    $"Impossible de trouver une ressource portant le nom {resourceItemName} au sein du fichier ressource {resourceFile.BaseName} se trouvant dans l'assembly {_assembly}.");

            if (ofObjectToReturn != null)
            {
                //Si on nous demande un objet d'un type compatible avec celui de la ressource, alors parfait, on
                //retourne la ressource telle quelle.
                if (ofObjectToReturn.IsAssignableFrom(resource.GetType()))
                {
                    return resource;
                }

                //Sinon, on retourne un MemoryStream. On s'assure que l'appelant est d'accord avec ça.
                if (!ofObjectToReturn.IsAssignableFrom(typeof(MemoryStream)))
                {
                    throw new NotSupportedException(
                        $"Le type d'objet demandé est {ofObjectToReturn}. Or, la ressource est de type {resource.GetType()}. Lorsque ces deux types ne sont pas compatibles, ce resolveur ne peut que retourner un MemoryStream.");
                }
            }

            //Pour l'instant, on ne support que la création d'un stream à partir d'un tableau de byte.
            if (resource.GetType() != typeof(byte[]))
            {
                throw new NotSupportedException(
                    $"La ressource est de type {resource.GetType()}. Or, ce resolveur ne supporte que la création d'un stream à partir d'un tableau de byte.");
            }

            return new MemoryStream((byte[])resource);
        }

        /// <summary>
        ///     Résou un URI absolu à partir d'un URI de base et d'un URI relatif.
        /// </summary>
        /// <param name="baseUri">
        ///     Le URI de base.
        /// </param>
        /// <param name="relativeUri">
        ///     Le URI absolu.
        /// </param>
        /// <returns>
        ///     Un <see cref="Uri"/> représentant le URI absolu de la ressource.
        /// </returns>
        public override Uri ResolveUri(Uri? baseUri, string? relativeUri)
        {
            if (baseUri == null && relativeUri != null)
            {
                //relativeUri est déjà un Uri absolu.
                if (!uriRegex.IsMatch(relativeUri))
                    throw new UriFormatException(
                        $"Si {nameof(baseUri)} n'est pas spécifié, {nameof(relativeUri)} doit être un URI absolu du format res:<ResourceFile>/<ResourceItem>.");

                return new Uri(relativeUri, UriKind.Absolute);
            }
            else if (baseUri != null && baseUri.IsAbsoluteUri)
            {
                //On nous a passé un URI de base absolu
                return new Uri(baseUri, relativeUri);
            }
            throw new NotSupportedException();
        }

        private ResourceManager GetCachedResourceManager(string baseName)
        {
            var result = _cachedResourceManagers.SingleOrDefault(rm => rm.BaseName == baseName);
            if (result == null)
            {
                result = new ResourceManager(baseName, _assembly);
                _cachedResourceManagers.Add(result);
            }
            return result;
        }

        private static (string ResourceFile, string ResourceItem) ParseUri(Uri absoluteUri)
        {
            var match = uriRegex.Match(absoluteUri.AbsoluteUri);
            if (!match.Success)
                throw new UriFormatException(
                    "Le URI absolu spécifié n'est pas valide. Il doit impérativement être du format res:<ResourceFile>/<ResourceItem>.");
            return (match.Groups[GRP_NAME_RESOURCE_FILE].Value, match.Groups[GRP_NAME_RESOURCE_ITEM].Value);
        }
    }
}
