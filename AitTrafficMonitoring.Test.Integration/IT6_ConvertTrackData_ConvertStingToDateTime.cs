using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;

namespace AitTrafficMonitoring.Test.Integration
{
    [TestFixture]
    class IT6_ConvertTrackData_ConvertStingToDateTime
    {
        private ITransponderReceiver _transponderReceiver;
        private IConvertTrackData _convertTrackData;
        private IFilterAirspace _filterAirspace;
        private IWriter _writer;
        private IConvertStringToDateTime _convertStringToDateTime;
        private ICalculateCourse _calculateCourse;
        private ICalculateVelocity _calculateVelocity;
        private ISortingTracks _sortingTracks;
        private ISeperationTracks _seperationTracks;
        private IEventController _eventController;
        private ILogWriter _logWriterToFile;
        private ILogWriter _logWriterToConsole;
        private SeperationEvent _seperationEvent;
        private List<string> _myList;

        [SetUp]
        public void SetUp()
        {
            _writer = Substitute.For<IWriter>();
            _calculateVelocity = new CalculateVelocity();
            _calculateCourse = new CalculateCourse();
            _transponderReceiver = Substitute.For<ITransponderReceiver>();
            _logWriterToFile = Substitute.For<ILogWriter>();
            _logWriterToConsole = Substitute.For<ILogWriter>();
            _convertStringToDateTime = new ConvertStringToDateTime();
            _eventController = new EventController(_logWriterToFile, _logWriterToConsole);
            _seperationEvent = new SeperationEvent();
            _seperationTracks = new SeperationTracks(_seperationEvent, _eventController);
            _sortingTracks = new SortingTracks(_calculateVelocity, _calculateCourse, _writer, _seperationTracks);
            _filterAirspace = new FilterAirspace(_sortingTracks);
            _convertTrackData = new ConvertTrackData(_transponderReceiver, _convertStringToDateTime, _filterAirspace);

            var track = "BIJ515;12345;54321;17891;20180409153742853";
            _myList = new List<string> {track};

            var eventArgs = new RawTransponderDataEventArgs(_myList);

            _transponderReceiver.TransponderDataReady += Raise.EventWith(eventArgs);
        }

        [Test]
        public void TransponderDataReady_Tag_ResultOK()
        {
            _writer.Received().WriteTrack(Arg.Is<Track>((x) => x.Tag == "BIJ515"));
        }

        [Test]
        public void TransponderDataReady_XCoordinate_ResultOK()
        {
            _writer.Received().WriteTrack(Arg.Is<Track>((x) => x.XCoordinate == 12345));
        }

        [Test]
        public void TransponderDataReady_YCoordinate_ResultOK()
        {
            _writer.Received().WriteTrack(Arg.Is<Track>((x) => x.YCoordinate == 54321));
        }

        [Test]
        public void TransponderDataReady_Altitude_ResultOK()
        {
            _writer.Received().WriteTrack(Arg.Is<Track>((x) => x.Altitude == 17891));
        }

        [Test]
        public void TransponderDataReady_Year_ResultOK()
        {
            _writer.Received().WriteTrack(Arg.Is<Track>((x) => x.Timestamp.Year == 2018));
        }

        [Test]
        public void TransponderDataReady_Month_ResultOK()
        {
            _writer.Received().WriteTrack(Arg.Is<Track>((x) => x.Timestamp.Month == 04));
        }

        [Test]
        public void TransponderDataReady_Day_ResultOK()
        {
            _writer.Received().WriteTrack(Arg.Is<Track>((x) => x.Timestamp.Day == 09));
        }

        [Test]
        public void TransponderDataReady_Hour_ResultOK()
        {
            _writer.Received().WriteTrack(Arg.Is<Track>((x) => x.Timestamp.Hour == 15));
        }

        [Test]
        public void TransponderDataReady_Minutes_ResultOK()
        {
            _writer.Received().WriteTrack(Arg.Is<Track>((x) => x.Timestamp.Minute == 37));
        }

        [Test]
        public void TransponderDataReady_Seconds_ResultOK()
        {
            _writer.Received().WriteTrack(Arg.Is<Track>((x) => x.Timestamp.Second == 42));
        }

        [Test]
        public void TransponderDataReady_Milliseconds_ResultOK()
        {
            _writer.Received().WriteTrack(Arg.Is<Track>((x) => x.Timestamp.Millisecond == 853));
        }
    }
}
