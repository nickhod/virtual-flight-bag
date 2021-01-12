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
    public class AirportsController : WebApiController
    {
        public AirportsController() : base()
        {
        }

        [Route(HttpVerbs.Get, "/{icao}")]
        public async Task GetSettings(string icao)
        {
            string ret = "";
            await HttpContext.SendDataAsync(ret);
        }
    }
}
