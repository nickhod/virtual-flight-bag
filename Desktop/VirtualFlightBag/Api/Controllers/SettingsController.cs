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
    public class SettingsController : WebApiController
    {
        public SettingsController() : base()
        {
        }

        [Route(HttpVerbs.Get, "/")]
        public async Task GetSettings()
        {
            string ret = "";
            await HttpContext.SendDataAsync(ret);
        }

        [Route(HttpVerbs.Post, "/save")]
        public async Task SaveSettings()
        {
            string ret = "";
            await HttpContext.SendDataAsync(ret);
        }
    }
}
