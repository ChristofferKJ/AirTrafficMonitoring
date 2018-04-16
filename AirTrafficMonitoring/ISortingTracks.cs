using System.Collections.Generic;

namespace AirTrafficMonitoring
{
    public interface ISortingTracks
    {
        Dictionary<string, List<ITrack>> TracksInAirspace { get; set; }

        void SortTracksInAirspace(object sender, TrackEventArgs trackEventArgs);
    }
}