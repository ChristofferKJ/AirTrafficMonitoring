using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace AirTrafficMonitoring
{
    public class Track
    {
        public string Tag { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public int Altitude { get; set; }
        public DateTime Timestamp { get; set; }

        public override string ToString()
        {
            return "Tag: " + Tag + "\nX Coordinate: " + XCoordinate + "\nY Coordinate: " +
                   YCoordinate + "\nAltitude: " + Altitude + "\nTimestamp: " +
                   Timestamp + "." + Timestamp.Millisecond + "\n";
        }

    }
}
