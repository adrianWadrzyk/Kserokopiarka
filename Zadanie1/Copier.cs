using System;
using System.Collections.Generic;
using System.Text;
using ver1;

namespace Zadanie1
{
        public class Copier : BaseDevice, IPrinter, IScanner
        {
            public int PrintCounter { get; set; } = 0;
            public int ScanCounter { get; set; } = 0;
            public new int Counter { get; set; }

            DateTime thisDay = DateTime.Today;

            public new void PowerOn()
            {
                if (base.state == IDevice.State.off)
                {
                    base.state = IDevice.State.on;
                    this.Counter++;
                }
                else
                    Console.WriteLine("Device is already on...");
            }

            public new void PowerOff()
            {
                if (base.state == IDevice.State.on)
                    base.state = IDevice.State.off;
            }

            public void Print(in IDocument document)
            {
                if (base.state == IDevice.State.on)
                {
                    this.PrintCounter++;
                    Console.WriteLine($"{thisDay} Print: {document.GetFileName()}");
                }
            }

            public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
            {

                document = formatType switch
                {
                    IDocument.FormatType.PDF => new PDFDocument($"PDFScan{ScanCounter}.pdf"),
                    IDocument.FormatType.TXT => new TextDocument($"TextScan{ScanCounter}.txt"),
                    _ => new ImageDocument($"ImageScan{ScanCounter}.jpg")
                };

                switch (state)
                {
                    case IDevice.State.on:
                        ScanCounter++;
                        Console.WriteLine($"{thisDay} Scan: {document.GetFileName()}");
                        break;
                    case IDevice.State.off:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            public void ScanAndPrint()
            {
                Scan(out IDocument document);
                Print(document);
            }
        }
}
