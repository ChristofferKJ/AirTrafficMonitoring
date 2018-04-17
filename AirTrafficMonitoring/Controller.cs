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
        private readonly IConvertTrackData _convertTrackData;
        private readonly IWriter _writer;
        private readonly IFilterAirspace _filterAirspace;
        private readonly ISortingTracks _sortingTracks;
        public event EventHandler<TrackEventArgs> SortTracksInAirspace;

        public Controller(ITransponderReceiver myReciever, IConvertTrackData convertTrackData, IWriter writer, IFilterAirspace filterAirspace, ISortingTracks sortingTracks)
        {
            _convertTrackData = convertTrackData;
            _writer = writer;
            _filterAirspace = filterAirspace;
            _sortingTracks = sortingTracks;
            SortTracksInAirspace += sortingTracks.SortTracksInAirspace; // Svarer til Attach()
            myReciever.TransponderDataReady += _myReciever_TransponderDataReady;
        }

        private void _myReciever_TransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            var myList = e.TransponderData;
            

                for (int i = 0; i < myList.Count; i++)
                {
                var track = _convertTrackData.ConvertData(myList[i]);
                    if (_filterAirspace.FilterTrack(track))
                    {
                        SortTracksInAirspace?.Invoke(this, new TrackEventArgs() {ITrack = track});
                        _writer.WriteTrack(track);
                    }
                }
        }
    }
}
