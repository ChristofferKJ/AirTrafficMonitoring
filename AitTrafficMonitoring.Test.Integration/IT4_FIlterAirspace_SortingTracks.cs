using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using NSubstitute;
using NUnit.Framework;

namespace AitTrafficMonitoring.Test.Integration
{
    [TestFixture]
    class IT4_FIlterAirspace_SortingTracks
    {
        private IFilterAirspace _filterAirspace;
        private IWriter _writer;
        private ICalculateCourse _calculateCourse;
        private ICalculateVelocity _calculateVelocity;
        private ISortingTracks _sortingTracks;
        private ISeperationTracks _seperationTracks;
        private IEventController _eventController;
        private ILogWriter _logWriterToFile;
        private ILogWriter _logWriterToConsole;
        private SeperationEvent _seperationEvent;
        private Track _track1;
        private Track _track2;
        private DateTime _date1;
        private DateTime _date2;
        private List<Track> _myTrackList;

        [SetUp]
        public void SetUp()
        {
            _writer = Substitute.For<IWriter>();
            _calculateVelocity = new CalculateVelocity();
            _calculateCourse = new CalculateCourse();
            _logWriterToFile = Substitute.For<ILogWriter>();
            _logWriterToConsole = Substitute.For<ILogWriter>();
            _eventController = new EventController(_logWriterToFile, _logWriterToConsole);
            _seperationEvent = new SeperationEvent();
            _seperationTracks = new SeperationTracks(_seperationEvent, _eventController);
            _sortingTracks = new SortingTracks(_calculateVelocity, _calculateCourse, _writer, _seperationTracks);
            _filterAirspace = new FilterAirspace(_sortingTracks);

            _myTrackList = new List<Track>();

            _date1 = new DateTime(2018, 04, 05, 20, 20, 18);
            _date2 = new DateTime(2018, 04, 05, 20, 20, 20);

            _track1 = new Track
            {
                Tag = "BIJ515",
                XCoordinate = 90000,
                YCoordinate = 90000,
                Altitude = 3000,
                Timestamp = _date1
            };
            _track2 = new Track
            {
                Tag = "BIJ515",
                XCoordinate = 9000,
                YCoordinate = 10000,
                Altitude =  3000,
                Timestamp = _date2
            };
        }

        [Test]
        public void FilterTrack_TrackInAirspace_ResultOK()
        {
            _myTrackList.Add(_track1);

            _filterAirspace.FilterTrack(_myTrackList);
            
            _writer.Received().WriteTrack(_track1);
           
        }

        [Test]
        public void FilterTrack_TrackNotInAirspace_ResultOK()
        {
            _myTrackList.Add(_track2);

            _filterAirspace.FilterTrack(_myTrackList);

            _writer.DidNotReceive().WriteTrack(_track2);
        }
    }
}
