
using VirutalFlightBag.Pdf.Drawing;

namespace VirutalFlightBag.Pdf.Core
{
    public class PdfMatch
    {
        public string Text { get; }
        public PdfTextSpan TextSpan { get; }
        public int Page { get; }

        public PdfMatch(string text, PdfTextSpan textSpan, int page)
        {
            Text = text;
            TextSpan = textSpan;
            Page = page;
        }
    }
}
