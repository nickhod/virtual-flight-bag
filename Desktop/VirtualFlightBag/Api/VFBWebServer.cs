using EmbedIO;
using EmbedIO.Actions;
using EmbedIO.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualFlightBag.Api.Controllers;

namespace VirtualFlightBag.Api
{
    public class VFBWebServer
    {
        public VFBWebServer()
        {



        }

        public void StartWebServer()
        {
            Task.Run(() =>
            {
                var url = "http://localhost:9696/";

                // Our web server is disposable.
                using (var server = this.CreateWebServer(url))
                {
                    // Once we've registered our modules and configured them, we call the RunAsync() method.
                    var task = server.RunAsync();
                    task.Wait();

                }
            });



        }

        private WebServer CreateWebServer(string url)
        {
            var server = new WebServer(o => o
                .WithUrlPrefix(url)
                .WithMode(HttpListenerMode.EmbedIO))
                .WithLocalSessionManager()

                .WithWebApi("/about", m => m.WithController<AboutController>())
                .WithWebApi("/airpots", m => m.WithController<AirportsController>())
                .WithWebApi("/chartfox", m => m.WithController<ChartFoxController>())
                .WithWebApi("/documents", m => m.WithController<DocumentsController>())
                .WithWebApi("/littlenavmap", m => m.WithController<LittleNavMapController>())
                .WithWebApi("/maps", m => m.WithController<MapsController>())
                .WithWebApi("/navigraph", m => m.WithController<NavigraphController>())
                .WithWebApi("/notes", m => m.WithController<NotesController>())
                .WithWebApi("/settings", m => m.WithController<SettingsController>())
                .WithWebApi("/vatsim", m => m.WithController<VATSIMController>())

                //.WithModule(new WebSocketChatModule("/chat"))
                //.WithModule(new WebSocketTerminalModule("/terminal"))
                //.WithStaticFolder("/", HtmlRootPath, true, m => m
                //.WithContentCaching(UseFileCache)) // Add static files after other modules to avoid conflicts

                .WithModule(new ActionModule("/", HttpVerbs.Any, ctx => ctx.SendDataAsync(new { Message = "Error" })));

            // Listen for state changes.
            server.StateChanged += (sender, evt) => 
            {
                Console.WriteLine(evt.NewState);
                   // $"WebServer New State - {e.NewState}".Info()
            };

            return server;
        }
    }
}
