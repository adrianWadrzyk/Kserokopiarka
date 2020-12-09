using System;
using System.Collections.Generic;
using System.Text;
using ver1;

namespace Zadanie3
{
   public class Copier : BaseDevice
    {
        public new void PowerOn()
        {
            if(base.state == IDevice.State.off)
            base.state = IDevice.State.on;
        }

        public new void PowerOff()
        {
            if(base.state == IDevice.State.on)
            base.state = IDevice.State.off;
        }

        public void Print(in IDocument document)
        {
            if(base.state == IDevice.State.on)
            {
                Printer printer = new Printer();
                printer.PowerOn();
                printer.Print(document);
                printer.PowerOff();
            }
        }
        
        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
        {
            if(base.state == IDevice.State.on)
            {
                Scanner scanner = new Scanner();
                scanner.PowerOn();
                scanner.Scan(out document, formatType);
            }
        }

        public void ScanAndPrint()
        {
            Scan(out IDocument document);
            Print(document);
        }
    }
}
