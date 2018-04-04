using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM_application
{
    class Program
    {
        static void Main(string[] args)
        {
            var myReciever = TransponderReceiverFactory.CreateTransponderDataReceiver();

            myReciever.TransponderDataReady += MyReciever_TransponderDataReady;

            Console.ReadKey();
        }

        private static void MyReciever_TransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            var myList = e.TransponderData;

            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(myList[i]);   
            }
        }
    }
}
