using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;

namespace AitTrafficMonitoring.Test.Unit
{
    [TestFixture]
    class SeperationTracksUnitTests
    {

        private ISeperationTracks _uut;
        private ILogWriter _logWriterToFile;
        private ILogWriter _logWriterToConsole;
        private ITransponderReceiver _transponderReceiver;
        private List<Track> _myList;
        private DateTime _date1;
        private DateTime _date2;
        private Track _track1;
        private Track _track2;

        [SetUp]
        public void Setup()
        {
            _transponderReceiver = Substitute.For<ITransponderReceiver>();
            _logWriterToFile = Substitute.For<ILogWriter>();
            _logWriterToConsole = Substitute.For<ILogWriter>();
            _uut = new SeperationTracks(_logWriterToFile,_logWriterToConsole);

            _date1 = new DateTime(2018, 4, 17, 20, 15, 12);
            _date2 = new DateTime(2018, 4, 17, 20, 15, 14);

            _track1 = new Track
            {
                Tag = "BIJ515",
                XCoordinate = 12345,
                YCoordinate = 54321,
                Altitude = 17891,
                Timestamp = _date1
            };

            _track2 = new Track
            {
                Tag = "QWF639",
                XCoordinate = 12346,
                YCoordinate = 54322,
                Altitude = 17892,
                Timestamp = _date2
            };

            _myList = new List<Track>
            {
                _track1,
                _track2
            };
        }

        [Test]
        public void SeperationCheck_ToTracksCollide_LogToFileAndConsole()
        {
            _uut.SeperationCheck(_myList);

            _logWriterToFile.Received().LogEvent(_track1.Tag, _track2.Tag, _date2);
            _logWriterToConsole.Received().LogEvent(_track1.Tag, _track2.Tag, _date2);
        }

        [Test]
        public void SeperationCheck_ToTracksDoNotCollide_NoSeperationEvent()
        {
            _track1.Altitude = 17592;

            _uut.SeperationCheck(_myList);

            _logWriterToFile.DidNotReceive().LogEvent(_track1.Tag, _track2.Tag, _date2);
            _logWriterToConsole.DidNotReceive().LogEvent(_track1.Tag, _track2.Tag, _date2);
        }
    }
}
