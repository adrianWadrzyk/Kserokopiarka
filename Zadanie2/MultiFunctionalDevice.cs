using System;
using System.Collections.Generic;
using System.Text;
using ver1;
using Zadanie1;
namespace Zadanie2
{
   public class MultiFunctionalDevice : Copier, IFax
    {
        public void GetFax(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
        {
            document = formatType switch
            {
                IDocument.FormatType.PDF => new PDFDocument($"Fax.pdf"),
                IDocument.FormatType.TXT => new TextDocument($"Fax.txt"),
                _ => new ImageDocument($"Fax.jpg")
            };

            switch (state)
            {
                case IDevice.State.on:
                    Console.WriteLine($"{DateTime.Now} Get Fax: {document.GetFileName()}");
                    break;
                case IDevice.State.off:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void SendFax(in IDocument document)
        {
            if(base.state == IDevice.State.on)
            {
                Console.WriteLine($"{DateTime.Now} Sending Fax {document.GetFileName()}");
            }
        }
    }
}
