using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AitTrafficMonitoring.Test.Integration
{
    [TestFixture]
    public class IT1_SeperationTracks_EventController
    {
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
            _logWriterToFile = Substitute.For<ILogWriter>();
            _logWriterToConsole = Substitute.For<ILogWriter>();
            _eventController = new EventController(_logWriterToFile,_logWriterToConsole);
            _seperationEvent = new SeperationEvent();
            _seperationTracks = new SeperationTracks(_seperationEvent,_eventController);
            _myTrackList = new List<Track>();

            _date1 = new DateTime(2018, 4, 17, 20, 15, 12);
            _date2 = new DateTime(2018, 4, 17, 20, 15, 14);
            _track1 = new Track
            {
                Tag = "JHL878",
                XCoordinate = 12345,
                YCoordinate = 98765,
                Altitude = 19987,
                Timestamp = _date1
            };
            _track2 = new Track
            {
                Tag = "MDO724",
                XCoordinate = 12346,
                YCoordinate = 98766,
                Altitude = 19988,
                Timestamp = _date2
            };
        }

        [Test]
        public void SeperationCheck_Track1AndTrack2OnCollisionCourse_LogCalled()
        {
            _myTrackList.Add(_track1);
            _myTrackList.Add(_track2);

            _seperationTracks.SeperationCheck(_myTrackList);

            _logWriterToFile.Received().LogEvent(_track1.Tag, _track2.Tag, _track2.Timestamp);
            _logWriterToConsole.Received().LogEvent(_track1.Tag, _track2.Tag, _track2.Timestamp);
        }
    }
}
