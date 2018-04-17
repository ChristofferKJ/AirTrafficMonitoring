using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public class ConvertTrackData : IConvertTrackData
    {
        private ConvertStringToDateTime _convertStringToDateTime;


        public Track ConvertData(string trackData)
        {
            var myTrack = new Track();

            _convertStringToDateTime = new ConvertStringToDateTime();

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
