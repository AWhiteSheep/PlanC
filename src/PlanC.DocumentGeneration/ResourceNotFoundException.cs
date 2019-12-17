using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PlanC.DocumentGeneration
{
    /// <summary>
    ///     Définit une erreur où une ressource spécifique n'est pas trouvée au sein d'un fichier ressource incorporé à
    ///     cet assembly. Cette exception signale un bug et ne devrait pas être attrapée.
    /// </summary>
    internal class ResourceNotFoundException : Exception
    {
        public static ResourceNotFoundException ForResourceName(string resourceName)
        {
            if (string.IsNullOrWhiteSpace(resourceName))
            {
                throw new ArgumentNullException(nameof(resourceName), "Le nom d'une resource ne peut pas être vide.");
            }
            return new ResourceNotFoundException(
                $"La resource '{resourceName}' est attendue, mais ne peut pas être trouvée.");
        }

        public ResourceNotFoundException()
            : base()
        { }

        public ResourceNotFoundException(string? message)
            : base(message)
        { }

        public ResourceNotFoundException(string? message, Exception? inner)
            : base(message, inner)
        { }

        protected ResourceNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
