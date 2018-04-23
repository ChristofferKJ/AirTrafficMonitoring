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
    class IT3_SortingTracks_CalcVelocity_CalcCourse
    {
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
        private List<Track> _myTrackList2;

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

            _myTrackList = new List<Track>();
            _myTrackList2 = new List<Track>();

            _date1 = new DateTime(2018, 04, 05, 20, 20, 18);
            _date2 = new DateTime(2018, 04, 05, 20, 20, 20);

            _track1 = new Track
            {
                Tag = "BIJ515",
                XCoordinate = 90000,
                YCoordinate = 90000,
                Timestamp = _date1
            };
            _track2 = new Track
            {
                Tag = "BIJ515",
                XCoordinate = 10000,
                YCoordinate = 10000,
                Timestamp = _date2
            };
        }

        [Test]
        public void SortTracksInAirSpace_Track2VelocityAndCourse_ResultOK()
        {
            _myTrackList.Add(_track1);
            _myTrackList2.Add(_track2);

            _sortingTracks.SortTracksInAirspace(_myTrackList);
            _sortingTracks.SortTracksInAirspace(_myTrackList2);

            Assert.That(Math.Round(_track2.Course), Is.EqualTo(225));
            Assert.That(Math.Round(_track2.Velocity, 2), Is.EqualTo(56568.54));
        }
    }
}
