// Adapted from https://github.com/bezzad/PdfiumViewer under Apache License 2.0
// https://github.com/bezzad/PdfiumViewer/blob/master/LICENSE

using System;

namespace VirutalFlightBag.Pdf.Core
{
    /// <summary>
    /// Contains text from metadata of the document.
    /// </summary>
    public class PdfInformation
    {
        public string Author { get; set; }
        public string Creator { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Keywords { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string Producer { get; set; }
        public string Subject { get; set; }
        public string Title { get; set; }
    }
}
