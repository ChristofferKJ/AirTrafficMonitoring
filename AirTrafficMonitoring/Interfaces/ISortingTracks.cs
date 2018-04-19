using System.Collections.Generic;

namespace AirTrafficMonitoring
{
    public interface ISortingTracks
    {
        void SortTracksInAirspace(List<Track> trackList);
    }
}