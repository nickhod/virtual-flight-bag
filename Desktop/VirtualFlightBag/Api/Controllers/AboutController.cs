using EmbedIO;
using EmbedIO.Routing;
using EmbedIO.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFlightBag.Api.Controllers
{
    public class AboutController : WebApiController
    {
        public AboutController() : base()
        {

        }


        //[Route(HttpVerbs.Get, "/api/hello/{name}")]
        //public string SayHello(string name)
        //{
        //    return $"Hello, {name}";
        //}

        [Route(HttpVerbs.Get, "/hello")]
        public async Task HelloWorld()
        {
            string ret = null;
            try
            {
                ret = "Hello from webserver @ " + DateTime.Now.ToLongTimeString();
            }
            catch (Exception ex)
            {
                //
                int i = 0;
            }
            await HttpContext.SendDataAsync(ret);

        }
    }
}
