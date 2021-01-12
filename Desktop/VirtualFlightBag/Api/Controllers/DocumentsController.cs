using EmbedIO;
using EmbedIO.Routing;
using EmbedIO.WebApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFlightBag.Api.Controllers
{
    public class DocumentsController : WebApiController
    {
        public DocumentsController() : base()
        {
        }

        [Route(HttpVerbs.Get, "/{path}")]
        public async Task FileList(string path)
        {
            var baseDocumentsPath = VirtualFlightBagManager.Instance.Settings.DocumentsDirectory;
            string ret = "";

            var files = Directory.GetFiles(baseDocumentsPath);
            var directories = Directory.GetDirectories(baseDocumentsPath);

            try
            {
                ret = "Goodbye from webserver @ " + DateTime.Now.ToLongTimeString();
            }
            catch (Exception ex)
            {
                int i = 0;
            }
            await HttpContext.SendDataAsync(ret);

        }

        [Route(HttpVerbs.Post, "/pin/{path}")]
        public async Task PinDocument(string path)
        {
            string ret = "";
            await HttpContext.SendDataAsync(ret);
        }

        [Route(HttpVerbs.Post, "/unpin/{path}")]
        public async Task UnpinDocument(string path)
        {
            string ret = "";
            await HttpContext.SendDataAsync(ret);
        }
    }
}
