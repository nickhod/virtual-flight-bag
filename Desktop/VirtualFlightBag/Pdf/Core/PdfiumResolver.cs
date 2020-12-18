// Adapted from https://github.com/bezzad/PdfiumViewer under Apache License 2.0
// https://github.com/bezzad/PdfiumViewer/blob/master/LICENSE

namespace VirutalFlightBag.Pdf.Core
{
    public class PdfiumResolver
    {
        public static event PdfiumResolveEventHandler Resolve;

        private static void OnResolve(PdfiumResolveEventArgs e)
        {
            Resolve?.Invoke(null, e);
        }

        internal static string GetPdfiumFileName()
        {
            var e = new PdfiumResolveEventArgs();
            OnResolve(e);
            return e.PdfiumFileName;
        }
    }
}
