using System;
using ver1;

namespace Zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            var xerox = new Copier();
            xerox.PowerOn();
            IDocument doc1 = new PDFDocument("aaa.pdf");
            xerox.Print(in doc1);
            xerox.Print(in doc1);
            xerox.Print(in doc1);


            IDocument doc2;
            xerox.Scan(out doc2, formatType: IDocument.FormatType.JPG);
            xerox.Scan(out doc2, formatType: IDocument.FormatType.JPG);
        }
    }
}
