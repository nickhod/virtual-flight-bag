// Adapted from https://github.com/bezzad/PdfiumViewer under Apache License 2.0
// https://github.com/bezzad/PdfiumViewer/blob/master/LICENSE

#pragma warning disable 1591

using VirutalFlightBag.Pdf.Core;

namespace VirutalFlightBag.Pdf.Enums
{
    public enum PdfError
    {
        Success = (int)NativeMethods.FPDF_ERR.FPDF_ERR_SUCCESS,
        Unknown = (int)NativeMethods.FPDF_ERR.FPDF_ERR_UNKNOWN,
        CannotOpenFile = (int)NativeMethods.FPDF_ERR.FPDF_ERR_FILE,
        InvalidFormat = (int)NativeMethods.FPDF_ERR.FPDF_ERR_FORMAT,
        PasswordProtected = (int)NativeMethods.FPDF_ERR.FPDF_ERR_PASSWORD,
        UnsupportedSecurityScheme = (int)NativeMethods.FPDF_ERR.FPDF_ERR_SECURITY,
        PageNotFound = (int)NativeMethods.FPDF_ERR.FPDF_ERR_PAGE
    }
}
