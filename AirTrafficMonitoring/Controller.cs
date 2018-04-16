using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace AirTrafficMonitoring
{
    public  class Controller
    {
        private readonly ITrack _track;
        private readonly IConvertTrackData _convertTrackData;
        private readonly IWriter _writer;
        private readonly ICalculateCourse _calculateCourse;
        private readonly IFilterAirspace _filterAirspace;
        private readonly ISortingTracks _sortingTracks;
        public event EventHandler<TrackEventArgs> _sortTracksInAirspace;

        public Controller(ITransponderReceiver myReciever, ITrack track, IConvertTrackData convertTrackData, IWriter writer, ICalculateCourse calculateCourse,IFilterAirspace filterAirspace, ISortingTracks sortingTracks)
        {
            _track = track;
            _convertTrackData = convertTrackData;
            _writer = writer;
            _calculateCourse = calculateCourse;
            _filterAirspace = filterAirspace;
            _sortingTracks = sortingTracks;
            _sortTracksInAirspace += sortingTracks.SortTracksInAirspace; // Svarer til Attach()
            myReciever.TransponderDataReady += _myReciever_TransponderDataReady;
        }

        private void _myReciever_TransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            var myList = e.TransponderData;

                for (int i = 0; i < myList.Count; i++)
                {
                    _convertTrackData.ConvertData(myList[i]);
                    if (_filterAirspace.FilterTrack(_track))
                    {
                        _sortTracksInAirspace?.Invoke(this,new TrackEventArgs() {ITrack = _track});
                        _calculateCourse.CalcCourse(_track);
                        _writer.WriteTrack(_track);
                    }
                }
        }
    }
}
