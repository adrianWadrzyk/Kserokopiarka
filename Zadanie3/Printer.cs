using System;
using System.Collections.Generic;
using System.Text;
using ver1;

namespace Zadanie3
{
    class Printer : IPrinter
    {
        public int Counter => throw new NotImplementedException();
        private int PrintCouner  { get; set; }
        protected IDevice.State state = IDevice.State.off;

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
            PrintCouner++;
        }

        public void Print(in IDocument document)
        {
            Console.WriteLine($"{DateTime.Now} Print {document.GetFileName()}");
        }
    }
}
