using System.IO;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows;

namespace RtfHtmlConverter
{
    class Program
    {
        public interface IMarkupConverter
        {
            string ConvertXamlToHtml(string xamlText);
            string ConvertHtmlToXaml(string htmlText);
            string ConvertRtfToHtml(string rtfText);
            string ConvertHtmlToRtf(string htmlText);
        }

        private void ConvertRtfInSTAThread(object rtf)
        {
            var threadData = rtf as ConvertRtfThreadData;
            threadData.HtmlText = markupConverter.ConvertRtfToHtml(threadData.RtfText);
        }


        private class ConvertRtfThreadData
        {
            public string RtfText { get; set; }
            public string HtmlText { get; set; }
        }

        private static string ConvertXamlToRtf(string xamlText)
        {
            var richTextBox = new RichTextBox();
            if (string.IsNullOrEmpty(xamlText)) return "";
            var textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            using (var xamlMemoryStream = new MemoryStream())
            {
                using (var xamlStreamWriter = new StreamWriter(xamlMemoryStream))
                {
                    xamlStreamWriter.Write(xamlText);
                    xamlStreamWriter.Flush();
                    xamlMemoryStream.Seek(0, SeekOrigin.Begin);
                    textRange.Load(xamlMemoryStream, DataFormats.Xaml);
                }
            }
            using (var rtfMemoryStream = new MemoryStream())
            {
                textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
                textRange.Save(rtfMemoryStream, DataFormats.Rtf);
                rtfMemoryStream.Seek(0, SeekOrigin.Begin);
                using (var rtfStreamReader = new StreamReader(rtfMemoryStream))
                {
                    return rtfStreamReader.ReadToEnd();
                }
            }
        }
        static void string ConvertRtfToXaml(string rtfText)
        {
            var richTextBox = new RichTextBox();
            if (string.IsNullOrEmpty(rtfText)) return "";
            var textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            using (var rtfMemoryStream = new MemoryStream())
            {
                using (var rtfStreamWriter = new StreamWriter(rtfMemoryStream))
                {
                    rtfStreamWriter.Write(rtfText);
                    rtfStreamWriter.Flush();
                    rtfMemoryStream.Seek(0, SeekOrigin.Begin);
                    textRange.Load(rtfMemoryStream, DataFormats.Rtf);
                }
            }
            using (var rtfMemoryStream = new MemoryStream())
            {
                textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
                textRange.Save(rtfMemoryStream, DataFormats.Xaml);
                rtfMemoryStream.Seek(0, SeekOrigin.Begin);
                using (var rtfStreamReader = new StreamReader(rtfMemoryStream))
                {
                    return rtfStreamReader.ReadToEnd();
                }
            }
        }

        static void Main(string[] args)
        {
        }
    }
}
