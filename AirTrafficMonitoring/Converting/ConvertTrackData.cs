using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace AirTrafficMonitoring
{
    public class ConvertTrackData : IConvertTrackData
    {
        private readonly IConvertStringToDateTime _convertStringToDateTime;
        private readonly IFilterAirspace _filterAirspace;

        public ConvertTrackData(ITransponderReceiver transponderReceiver,IConvertStringToDateTime convertStringToDateTime, IFilterAirspace filterAirspace)
        {
            transponderReceiver.TransponderDataReady += TransponderReceiver_TransponderDataReady;
            _convertStringToDateTime = convertStringToDateTime;
            _filterAirspace = filterAirspace;
        }

        private void TransponderReceiver_TransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            var myList = e.TransponderData;
            var trackList = new List<Track>();

            for (var i = 0; i < myList.Count; i++)
            {
                var track = ConvertData(myList[i]);
                trackList.Add(track);
            }

            _filterAirspace.FilterTrack(trackList);
        }

        public Track ConvertData(string trackData)
        {
            var myTrack = new Track();

            string[] array = trackData.Split(';');

            myTrack.Tag = array[0];
            myTrack.XCoordinate = Convert.ToInt32(array[1]);
            myTrack.YCoordinate = Convert.ToInt32(array[2]);
            myTrack.Altitude = Convert.ToInt32(array[3]);
            myTrack.Timestamp = _convertStringToDateTime.ConvertToDateTime(array[4]);
            
            return myTrack;
        }
    }
}
