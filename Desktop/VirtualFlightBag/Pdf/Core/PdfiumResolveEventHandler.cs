// Adapted from https://github.com/bezzad/PdfiumViewer under Apache License 2.0
// https://github.com/bezzad/PdfiumViewer/blob/master/LICENSE

using System;

namespace VirutalFlightBag.Pdf.Core
{
    public class PdfiumResolveEventArgs : EventArgs
    {
        public string PdfiumFileName { get; set; }
    }

    public delegate void PdfiumResolveEventHandler(object sender, PdfiumResolveEventArgs e);
}
