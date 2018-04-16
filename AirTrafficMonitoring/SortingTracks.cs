using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public class SortingTracks : ISortingTracks
    {
        public Dictionary<string,List<ITrack>> TracksInAirspace { get; set; }
        private readonly ICalculateVelocity _calculateVelocity;

        public SortingTracks(ICalculateVelocity calculateVelocity)
        {
            _calculateVelocity = calculateVelocity;
            TracksInAirspace = new Dictionary<string, List<ITrack>>();
        }


        public void SortTracksInAirspace(object sender, TrackEventArgs trackEventArgs)
        {           
            if (!TracksInAirspace.ContainsKey(trackEventArgs.ITrack.Tag))
            {
                TracksInAirspace.Add(trackEventArgs.ITrack.Tag, new List<ITrack>() {trackEventArgs.ITrack});
            }

            else
            {
                List<ITrack> existingTrack = TracksInAirspace.First(tag => tag.Key == trackEventArgs.ITrack.Tag).Value;
                _calculateVelocity.CalcVelocity(existingTrack);
            }
        }
    }
}
