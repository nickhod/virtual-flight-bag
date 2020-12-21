using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFlightBag.Api.ViewModels
{
    public class DocumentViewModel
    {
        public string Name { get; set; }
        public FileType FileType { get; set; }
        public string Url { get; set; }
    }
}
