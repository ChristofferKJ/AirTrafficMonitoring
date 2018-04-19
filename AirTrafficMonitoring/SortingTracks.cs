using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public class SortingTracks : ISortingTracks
    {
        private readonly ICalculateVelocity _calculateVelocity;
        private readonly ICalculateCourse _calculateCourse;
        private readonly IWriter _writer;
        private readonly ISeperationTracks _seperationTracks;
        private List<Track> _currentTrackList;

        public SortingTracks(ICalculateVelocity calculateVelocity, ICalculateCourse calculateCourse, IWriter writer, ISeperationTracks seperationTracks)
        {
            _calculateVelocity = calculateVelocity;
            _calculateCourse = calculateCourse;
            _writer = writer;
            _seperationTracks = seperationTracks;
            _currentTrackList = new List<Track>();
        }

        public void SortTracksInAirspace(List<Track> newTrackList)
        {
            for (int i = 0; i < newTrackList.Count; i++)
            {
                for (int j = 0; j < _currentTrackList.Count; j++)
                {
                    if (newTrackList[i].Tag == _currentTrackList[j].Tag)
                    {
                        _calculateVelocity.CalcVelocity(_currentTrackList[j], newTrackList[i]);
                        _calculateCourse.CalcCourse(_currentTrackList[j], newTrackList[i]);
                    }
                }
            }
            _currentTrackList = newTrackList;

            foreach (var track in _currentTrackList)
            {
                _writer.WriteTrack(track);
            }

            _seperationTracks.SeperationCheck(_currentTrackList);
        }
    }
}
