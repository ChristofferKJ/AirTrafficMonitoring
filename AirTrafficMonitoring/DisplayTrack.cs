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
        private readonly IWriter _writer; 

        public DisplayTrack(ITransponderReceiver myReciever, IWriter writer)
        {
            _writer = writer; 
            myReciever.TransponderDataReady += _myReciever_TransponderDataReady;
        }

        private void _myReciever_TransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            var myTrack = new Track();
            ConvertTrackData convertTrackData = new ConvertTrackData(myTrack);
            var myList = e.TransponderData;

            for (int i = 0; i < myList.Count; i++)
            {
                convertTrackData.ConvertData(myList[i]);
                _writer.WriteTrack(myTrack);  
            }
        }
    }
}
