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
    class ConvertTrackDataUnitTest
    {
        private ConvertTrackData _uut;
        private IConvertStringToDateTime _convertStringToDateTime;
        private IFilterAirspace _filterAirspace;
        private ITransponderReceiver _transponderReceiver;
        private string data;
        private Track _track;
        private List<Track> _tracklist;
        private List<string> _myList;


        [SetUp]
        public void Setup()
        {
            _convertStringToDateTime = Substitute.For<IConvertStringToDateTime>();
            _filterAirspace = Substitute.For<IFilterAirspace>();
            _transponderReceiver = Substitute.For<ITransponderReceiver>();
            _uut = new ConvertTrackData(_transponderReceiver, _convertStringToDateTime, _filterAirspace);

            _track = new Track();
            _tracklist = new List<Track> { _track };

            var track = "BIJ515;12345;54321;17891;20180409153742853";
            _myList = new List<string> { track };

            var eventArgs = new RawTransponderDataEventArgs(_myList);
            _transponderReceiver.TransponderDataReady += Raise.EventWith(eventArgs);
        }



        [Test]
        public void FilterTrack_EventRaised_TagIsOK()
        {
            _filterAirspace.Received().FilterTrack(Arg.Is<List<Track>>(x => x[0].Tag == "BIJ515"));
        }


        [Test]
        public void FilterTrack_EventRaised_XCoordinateIsOK()
        {
            _filterAirspace.Received().FilterTrack(Arg.Is<List<Track>>(x => x[0].XCoordinate == 12345));
        }

        [Test]
        public void FilterTrack_EventRaised_YCoordinateIsOK()
        {
            _filterAirspace.Received().FilterTrack(Arg.Is<List<Track>>(x => x[0].YCoordinate ==54321));
        }

        [Test]
        public void FilterTrack_EventRaised_AltitudeIsOK()
        {
            _filterAirspace.Received().FilterTrack(Arg.Is<List<Track>>(x => x[0].Altitude == 17891));
        }

        [Test]
        public void FilterTrack_EventRaised_YearIsOK()
        {
            _filterAirspace.Received().FilterTrack(Arg.Is<List<Track>>(x => x[0].Timestamp.Year == 2018));
        }

        [Test]
        public void FilterTrack_EventRaised_MonthIsOK()
        {
            _filterAirspace.Received().FilterTrack(Arg.Is<List<Track>>(x => x[0].Timestamp.Month == 04));
        }

        [Test]
        public void FilterTrack_EventRaised_DayIsOK()
        {
            _filterAirspace.Received().FilterTrack(Arg.Is<List<Track>>(x => x[0].Timestamp.Day == 09));
        }

        [Test]
        public void FilterTrack_EventRaised_HourIsOK()
        {
            _filterAirspace.Received().FilterTrack(Arg.Is<List<Track>>(x => x[0].Timestamp.Hour == 15));
        }

        [Test]
        public void FilterTrack_EventRaised_MinuteIsOK()
        {
            _filterAirspace.Received().FilterTrack(Arg.Is<List<Track>>(x => x[0].Timestamp.Minute == 37));
        }

        [Test]
        public void FilterTrack_EventRaised_SecondIsOK()
        {
            _filterAirspace.Received().FilterTrack(Arg.Is<List<Track>>(x => x[0].Timestamp.Second == 42));
        }

        [Test]
        public void FilterTrack_EventRaised_MillisecondIsOK()
        {
            _filterAirspace.Received().FilterTrack(Arg.Is<List<Track>>(x => x[0].Timestamp.Millisecond == 853));
        }
    }
}


