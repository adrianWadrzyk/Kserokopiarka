using System;
using System.Collections.Generic;
using System.Text;
using ver1;

namespace Zadanie2
{
    public interface IFax : IDevice
    {
        void SendFax(in IDocument document);
        void GetFax(out IDocument document, IDocument.FormatType formatType);
    }
}
