using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public class ConvertTrackData
    {
        private Track _myTrack;
        private ConvertStringToDateTime _convertStringToDateTime;

        public Track ConvertData(string trackData)
        {
            _convertStringToDateTime = new ConvertStringToDateTime();

            string[] array = trackData.Split(';');

            _myTrack = new Track();

            _myTrack.Tag = array[0];
            _myTrack.XCoordinate = Convert.ToInt32(array[1]);
            _myTrack.YCoordinate = Convert.ToInt32(array[2]);
            _myTrack.Altitude = Convert.ToInt32(array[3]);
            _myTrack.Timestamp = _convertStringToDateTime.ConvertToDateTime(array[4]);
            
            return _myTrack;
        }

        public override string ToString()
        {
            return "Tag: " + _myTrack.Tag + "\nX Coordinate: " + _myTrack.XCoordinate + "\nY Coordinate: " +
                   _myTrack.YCoordinate + "\nAltitude: " + _myTrack.Altitude + "\nTimestamp: " +
                   _myTrack.Timestamp + "." + _myTrack.Timestamp.Millisecond + "\n";
        }
    }
}
