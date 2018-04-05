using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public class ConvertTrackData
    {
        private Track myTrack;

        public Track ConvertData(string trackData)
        {
            string[] array = trackData.Split(';');

            myTrack = new Track();

            myTrack.Tag = array[0];
            myTrack.XCoordinate = Convert.ToInt32(array[1]);
            myTrack.YCoordinate = Convert.ToInt32(array[2]);
            myTrack.Altitude = Convert.ToInt32(array[3]);
            //myTrack.Timestamp = Convert.ToDateTime(array[4]);

            return myTrack;
        }

        public override string ToString()
        {
            return "Tag: " + myTrack.Tag + "\nX Coordinate: " + myTrack.XCoordinate + "\nY Coordinate: " +
                   myTrack.YCoordinate + "\nAltitude: " + myTrack.Altitude + "\nTimestamp: "; //+ myTrack.Timestamp;
        }
    }
}
