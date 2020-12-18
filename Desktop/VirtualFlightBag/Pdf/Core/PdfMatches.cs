// Adapted from https://github.com/bezzad/PdfiumViewer under Apache License 2.0
// https://github.com/bezzad/PdfiumViewer/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

#pragma warning disable 1591

namespace VirutalFlightBag.Pdf.Core
{
    public class PdfMatches
    {
        public int StartPage { get; private set; }

        public int EndPage { get; private set; }

        public IList<PdfMatch> Items { get; private set; }

        public PdfMatches(int startPage, int endPage, IList<PdfMatch> matches)
        {
            if (matches == null)
                throw new ArgumentNullException(nameof(matches));

            StartPage = startPage;
            EndPage = endPage;
            Items = new ReadOnlyCollection<PdfMatch>(matches);
        }
    }
}
