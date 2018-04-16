using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public class FilterAirspace : IFilterAirspace
    {
        public bool FilterTrack(Track track)
        {
            return !(track.XCoordinate > 90000 || track.XCoordinate < 10000 || track.YCoordinate < 10000 || track.YCoordinate > 90000 || track.Altitude < 500 || track.Altitude > 20000);
        }
    }
}
