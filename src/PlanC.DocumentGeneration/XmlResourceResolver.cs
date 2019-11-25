using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace PlanC.DocumentGeneration
{
    internal sealed class XmlResourceResolver : XmlResolver
    {
        //Les constantes des groupes de nom du regex pour le URI.
        private const string GRP_NAME_RESOURCE_FILE = "ResourceFile";
        private const string GRP_NAME_RESOURCE_ITEM = "ResourceItem";

        //Le regex pour valider le URI absolu et en extraire les infos. Notons qu'il n'accepte que les lettres, les
        //chiffres et les points dans les noms. Or, un fichier de resource accepte bien d'autres caractères. Il y a
        //aussi certainement d'autres contraintes qu'on n'applique pas.
        private static readonly Regex uriRegex = new Regex(
            @$"^res:(?<{GRP_NAME_RESOURCE_FILE}>[A-Z][A-Z0-9.]*)\/(?<{GRP_NAME_RESOURCE_ITEM}>[A-Z][A-Z0-9.]*)$",
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        private Assembly _assembly;
        private HashSet<ResourceManager> _cachedResourceManagers;

        /// <summary>
        ///     Construit un nouveau <see cref="XmlResourceResolver"/> pouvant obtenir des resources de l'assembly
        ///     spécifié.
        /// </summary>
        /// <param name="assembly">
        ///     L'assembly dans lequel rechercher les resources.
        /// </param>
        public XmlResourceResolver(Assembly assembly)
        {
            _assembly = assembly ?? throw new ArgumentNullException(nameof(assembly));
            _cachedResourceManagers = new HashSet<ResourceManager>();
        }

        public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
        {
            //Valide et extrait les paramètres de l'URI
            var match = uriRegex.Match(absoluteUri.AbsoluteUri);
            if (!match.Success)
                throw new ArgumentException(
                        null,
                        nameof(absoluteUri),
                        new UriFormatException("Le URI absolu spécifié n'est pas valide. Il doit impérativement être du format res:<ResourceManager>/<Resource>."));
            var resourceFileName = match.Groups[GRP_NAME_RESOURCE_FILE].Value;
            var resourceItemName = match.Groups[GRP_NAME_RESOURCE_ITEM].Value;

            //Crée le resource manager. TODO : Va planter si resourceManName invalide?
            var resourceFile = GetCachedResourceManager(resourceFileName);

            //Obtient la resource
            //TODO : Objet peut ne pas être byte[]
            var resource = (byte[]?)resourceFile.GetObject(resourceItemName);
            if (resource == null)
                throw new ArgumentException(
                    nameof(absoluteUri),
                    $"Impossible de trouver une resource portant le nom {resourceFile} parmis les gestionnaire de resource de l'assembly {_assembly}.");

            return new MemoryStream(resource);
        }

        public override Uri ResolveUri(Uri? baseUri, string? relativeUri)
        {
            if (baseUri == null && relativeUri != null)
            {
                //relativeUri est déjà un Uri absolu.
                if (!uriRegex.IsMatch(relativeUri))
                    throw new UriFormatException(
                        $"Si {nameof(baseUri)} n'est pas spécifié, {nameof(relativeUri)} doit être un URI absolu du format res:<ResourceManager>/<Resource>.");

                return new Uri(relativeUri, UriKind.Absolute);
            }
            else if (baseUri != null && baseUri.IsAbsoluteUri)
            {

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
    }
}
