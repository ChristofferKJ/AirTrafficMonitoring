using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public class FilterAirspace : IFilterAirspace
    {
        private readonly ISortingTracks _sortingTracks;

        public FilterAirspace(ISortingTracks sortingTracks)
        {
            _sortingTracks = sortingTracks;
        }

        public void FilterTrack(List<Track> trackList)
        {
            foreach (var track in trackList)
            {
                if (track.XCoordinate > 90000 || track.XCoordinate < 10000 || track.YCoordinate < 10000 ||
                    track.YCoordinate > 90000 || track.Altitude < 500 || track.Altitude > 20000)
                    trackList.Remove(track);
            }

            _sortingTracks.SortTracksInAirspace(trackList);
        }
    }
}
