using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public class ConvertTrackData : IConvertTrackData
    {
        private readonly Track _myTrack;
        private ConvertStringToDateTime _convertStringToDateTime;

        public ConvertTrackData(Track myTrack)
        {
            _myTrack = myTrack;
        }

        public Track ConvertData(string trackData)
        {
            _convertStringToDateTime = new ConvertStringToDateTime();

            string[] array = trackData.Split(';');

            _myTrack.Tag = array[0];
            _myTrack.XCoordinate = Convert.ToInt32(array[1]);
            _myTrack.YCoordinate = Convert.ToInt32(array[2]);
            _myTrack.Altitude = Convert.ToInt32(array[3]);
            _myTrack.Timestamp = _convertStringToDateTime.ConvertToDateTime(array[4]);
            
            return _myTrack;
        }
    }
}
