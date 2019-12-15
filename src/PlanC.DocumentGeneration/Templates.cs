#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8603 // Possible null reference return.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Resources;
using System.Text;

namespace PlanC.DocumentGeneration
{
    /// <summary>
    ///     Classe d'aide pour obtenir les ressources du fichier incorporé Templates.resx à l'aide d'un API statiquement
    ///     typé.
    /// </summary>
    internal static class Templates
    {
        private static ResourceManager _resourceManager = new ResourceManager(typeof(Templates));

        [DebuggerStepThrough]
        private static byte[] GetBytes(string name) =>
            (byte[])_resourceManager.GetObject(name) ?? throw ResourceNotFoundException.ForResourceName(name);

        public static class CourseTemplate
        {
            public static byte[] GetPackage() => GetBytes("CourseTemplatePackage.dotx");

            public static byte[] GetMainDocumentPart() => GetBytes("CourseTemplateMainDocumentPart.xslt");
        }

        public static class CoursePlan
        {

        }
    }
}
