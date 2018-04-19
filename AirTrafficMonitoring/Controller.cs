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
        private readonly ISeperationTracks _seperationTracks; 
        public event EventHandler<TrackEventArgs> SortTracksInAirspace;
        //public event EventHandler<TrackEventArgs> Con // SKal vi oprette et nyt event i stedet??
        

        public Controller(ITransponderReceiver myReciever, IConvertTrackData convertTrackData, IWriter writer, IFilterAirspace filterAirspace, ISortingTracks sortingTracks, ISeperationTracks seperationTracks)
        {
            _convertTrackData = convertTrackData;
            _writer = writer;
            _filterAirspace = filterAirspace;
            _sortingTracks = sortingTracks;
            _seperationTracks = seperationTracks;
            SortTracksInAirspace += sortingTracks.SortTracksInAirspace; // Svarer til Attach()
            myReciever.TransponderDataReady += _myReciever_TransponderDataReady;
        }

        private void _myReciever_TransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            var myList = e.TransponderData;
            var trackList = new List<Track>();

            for (var i = 0; i < myList.Count; i++)
            {
                var track = _convertTrackData.ConvertData(myList[i]);
                trackList.Add(track);

                _filterAirspace.FilterTrack(track);

                if (_filterAirspace.IsTrackInAirspace)
                {
                    SortTracksInAirspace?.Invoke(this, new TrackEventArgs {ITrack = track});
                    _writer.WriteTrack(track);
                    _seperationTracks.SeperationCheck(trackList);
                }
            }
        }
    }
}
