using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NUnit.Framework;
using TransponderReceiver;

namespace AitTrafficMonitoring.Test.Unit
{
    [TestFixture]
    class SeperationTracksUnitTests
    {
        private ISeperationTracks _uut;
        private SeperationEvent _seperationEvent;
        private IEventController _eventController;
        private List<Track> _myList;
        private DateTime _date1;
        private DateTime _date2;
        private Track _track1;
        private Track _track2;
        private Track _track3;
        private DateTime _date3;

        [SetUp]
        public void Setup()
        {
            _seperationEvent = new SeperationEvent();
            _eventController = Substitute.For<IEventController>();
            _uut = new SeperationTracks(_seperationEvent, _eventController);

            _date1 = new DateTime(2018, 4, 17, 20, 15, 12);
            _date2 = new DateTime(2018, 4, 17, 20, 15, 14);
            _date3 = new DateTime(2018, 4, 17, 20, 16, 26);

            _track1 = new Track
            {
                Tag = "BIJ515",
                XCoordinate = 12345,
                YCoordinate = 54321,
                Altitude = 17000,
                Timestamp = _date1
            };

            _track2 = new Track
            {
                Tag = "QWF639",
                XCoordinate = 12346,
                YCoordinate = 54322,
                Altitude = 17299,
                Timestamp = _date2
            };

            _track3 = new Track()
            {
                Tag = "PXL968",
                XCoordinate = 12346,
                YCoordinate = 54322,
                Altitude = 17299,
                Timestamp = _date3
            };

            _myList = new List<Track>
            {
                _track1,
                _track2
            };
        }


        [Test]
        public void SeperationCheck_VerticalSeparationUnder300_LogToFileAndConsole()
        {
            _uut.SeperationCheck(_myList);

            _eventController.Received().seperationsDetected(Arg.Is<List<SeperationEvent>>((x) => x[0].Tag1 == "BIJ515" && x[0].Tag2 == "QWF639"));
        }

        [Test]
        public void SeperationCheck_VerticalSeparationAbove300_NoSeperationEvent()
        {
            _track2.Altitude = 17300;

            _uut.SeperationCheck(_myList);

            _eventController.DidNotReceive().seperationsDetected(Arg.Any<List<SeperationEvent>>());
        }

        [Test]
        public void SeperationCheck_HorizontalSeparationUnder5000_LogToFileAndConsole()
        {
            _track2.XCoordinate = 17344;
            _track2.YCoordinate = 54321;

            _uut.SeperationCheck(_myList);

            _eventController.Received().seperationsDetected(Arg.Is<List<SeperationEvent>>((x) => x[0].Tag1 == "BIJ515" && x[0].Tag2 == "QWF639"));
        }

        [Test]
        public void SeperationCheck_HorizontalSeparationAbove5000_NoSeperationEvent()
        {
            _track2.Altitude = 17300;
            _track2.XCoordinate = 17345;
            _track2.YCoordinate = 54321;

            _uut.SeperationCheck(_myList);

            _eventController.DidNotReceive().seperationsDetected(Arg.Any<List<SeperationEvent>>());
        }

        [Test]
        public void SeperationCheck_Track1AndTrack3Collide_LogToFileAndConsole()
        {
            _track2.Altitude = 18000;

            _myList.Add(_track3);

            _uut.SeperationCheck(_myList);

            _eventController.Received().seperationsDetected(Arg.Is<List<SeperationEvent>>((x) => x[0].Tag1 == "BIJ515" && x[0].Tag2 == "PXL968"));

        }

        [Test]
        public void SeperationCheck_SameTag_NoSeperationEvent()
        {
            _track2.Tag = "BIJ515";

            _uut.SeperationCheck(_myList);

            _eventController.DidNotReceive().seperationsDetected(Arg.Any<List<SeperationEvent>>());
        }
    }
}
