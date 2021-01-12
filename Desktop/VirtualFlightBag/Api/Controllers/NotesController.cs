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
    public class NotesController : WebApiController
    {
        public NotesController() : base()
        {
        }

        [Route(HttpVerbs.Get, "/")]
        public async Task ListNotes()
        {
            string ret = "";
            await HttpContext.SendDataAsync(ret);
        }

        [Route(HttpVerbs.Get, "/{id}")]
        public async Task GetNote(int id)
        {
            string ret = "";
            await HttpContext.SendDataAsync(ret);
        }

        [Route(HttpVerbs.Post, "/save")]
        public async Task SaveNote()
        {
            string ret = "";
            await HttpContext.SendDataAsync(ret);
        }

        [Route(HttpVerbs.Post, "/delete")]
        public async Task DeleteNote()
        {
            string ret = "";
            await HttpContext.SendDataAsync(ret);
        }
    }
}
