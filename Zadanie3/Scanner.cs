using System;
using System.Collections.Generic;
using System.Text;
using ver1;

namespace Zadanie3
{
    class Scanner : IScanner
    {
        protected IDevice.State state = IDevice.State.off;

        public int Counter => ScanCounter;
        private int ScanCounter { get; set; }

        public IDevice.State GetState()
        {
            return state;
        }

        public void PowerOff()
        {
            state = IDevice.State.off;
            Console.WriteLine("Device is turn off");
        }

        public void PowerOn()
        {
            state = IDevice.State.on;
            Console.WriteLine("Device is turn on");
            ScanCounter++;
    }

        public void Scan(out IDocument document, IDocument.FormatType formatType)
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
                    Console.WriteLine($"{DateTime.Now} Scan: {document.GetFileName()}");
                    break;
                case IDevice.State.off:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
