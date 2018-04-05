using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace AirTrafficMonitoring
{
    public  class DisplayTrack
    {
        private ITransponderReceiver _myReciever;

        public void DisplayTrackData()
        {

           _myReciever = TransponderReceiverFactory.CreateTransponderDataReceiver();

            _myReciever.TransponderDataReady += _myReciever_TransponderDataReady;
        }

        private void _myReciever_TransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            ConvertTrackData convertTrackData = new ConvertTrackData();
            var myList = e.TransponderData;

            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(myList[i]);
                convertTrackData.ConvertData(myList[i]);
                Console.WriteLine(convertTrackData.ToString());
            }
        }
    }
}
