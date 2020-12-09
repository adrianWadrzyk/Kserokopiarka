using System;
using ver1;

namespace Zadanie2
{
    class Program
    {
        static void Main(string[] args)
        {
            MultiFunctionalDevice device = new MultiFunctionalDevice();
            device.PowerOn();

            IDocument doc1 = new PDFDocument("aaa.pdf");
            device.SendFax(doc1);
            device.PowerOff();
            device.SendFax(doc1);
            device.PowerOn();
            IDocument doc2;
            device.GetFax(out doc2);

            device.Print(doc1);
        }
    }
}

