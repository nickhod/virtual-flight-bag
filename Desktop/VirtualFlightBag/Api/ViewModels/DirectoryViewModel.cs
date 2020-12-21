using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFlightBag.Api.ViewModels
{
    public class DirectoryViewModel
    {
        public IList<DocumentViewModel> Documents { get; set; }
        public string ParentDirectoryUrl { get; set; }
    }
}
