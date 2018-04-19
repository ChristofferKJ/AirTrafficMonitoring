using System.Collections.Generic;

namespace AirTrafficMonitoring
{
    public interface IFilterAirspace
    {
        void FilterTrack(List<Track> trackList);
    }
}