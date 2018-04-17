using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public static class TrackLists
    {
        public static void AddToTrackList(this List<ITrack> trackList, ITrack track, int maxSize)
        {
            if (trackList.Count >= maxSize)
            {
                trackList.RemoveAt(0);
            }

            trackList.Add(track);
        }
    }
}
