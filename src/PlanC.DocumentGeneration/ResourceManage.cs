using System;
using System.Collections.Generic;
using System.Text;

namespace PlanC.DocumentGeneration
{
    //Temp
    internal static class ResourceManager
    {
        private static string? rootPath;

        public static string RootPath
        {
            get => rootPath ?? Environment.CurrentDirectory;
            set => rootPath = value;
        }

        public class Entry
        {
            
        }
    }
}
