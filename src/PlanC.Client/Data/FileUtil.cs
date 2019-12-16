using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanC.Client.Data
{
    public static class FileUtil
    {
        /// <summary>
        /// File upload avec js runtime
        /// </summary>
        /// <param name="js"></param>
        /// <param name="filename"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ValueTask<object> SaveAs(this IJSRuntime js, string filename, byte[] data)
            => js.InvokeAsync<object>(
                "saveAsFile",
                filename,
                Convert.ToBase64String(data)); 
        
        // return une demande invke avec jsRuntime pour téléchargé du côté client
    }
}
