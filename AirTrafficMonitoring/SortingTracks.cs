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
        private readonly ICalculateCourse _calculateCourse;

        public SortingTracks(ICalculateVelocity calculateVelocity, ICalculateCourse calculateCourse)
        {
            _calculateVelocity = calculateVelocity;
            _calculateCourse = calculateCourse;
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
                var existingTrack = TracksInAirspace.First(tag => tag.Key == trackEventArgs.ITrack.Tag).Value;
                existingTrack.AddToTrackList(trackEventArgs.ITrack, 2);
                _calculateVelocity.CalcVelocity(existingTrack);
                _calculateCourse.CalcCourse(existingTrack);
            }
        }
    }
}
