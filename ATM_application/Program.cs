using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using TransponderReceiver;

namespace ATM_application
{
    class Program
    {
        static void Main(string[] args)
        {
            IWriter writer = new ConsoleWriter();
            var myReciever = TransponderReceiverFactory.CreateTransponderDataReceiver();    
            DisplayTrack myDisplayTrack = new DisplayTrack(myReciever, writer);
         
            Console.ReadKey();
        }
    }
}
