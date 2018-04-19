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
    public class ControllerUnitTests
    {
        private ITransponderReceiver _transponderReceiver;
        private Controller _uut;
        private IWriter _writer;
        private IConvertTrackData _convertTrackData;
        private IFilterAirspace _filterAirspace;
        private ISortingTracks _sortingTracks;
        private ISeperationTracks _seperationTracks;

        [SetUp]
        public void Setup()
        {
            _transponderReceiver = Substitute.For<ITransponderReceiver>();
            _convertTrackData = Substitute.For<IConvertTrackData>();
            _writer = Substitute.For<IWriter>();
            _filterAirspace = Substitute.For<IFilterAirspace>();
            _sortingTracks = Substitute.For<ISortingTracks>();
            _seperationTracks = Substitute.For<ISeperationTracks>();
            _uut = new Controller(_transponderReceiver,_convertTrackData,_writer,_filterAirspace,_sortingTracks,_seperationTracks);

            var track = "BIJ515;12345;54321;17891;20180409153742853";
            List<string> myList = new List<string>();
            myList.Add(track);

            var eventArgs = new RawTransponderDataEventArgs(myList);

            _transponderReceiver.TransponderDataReady += Raise.EventWith(eventArgs);
        }

        [Test]
        public void WriteTrack_EventRaised_TagIsOK()
        {
           _writer.Received().WriteTrack(Arg.Is<Track>(track => track.Tag.Contains("BIJ515")));
        }

        [Test]
        public void WriteTrack_EventRaised_XCoordinateIsOK()
        {
            _writer.Received().WriteTrack(Arg.Is<Track>(track => track.XCoordinate.Equals(12345)));
        }

        [Test]
        public void WriteTrack_EventRaised_YCoordinateIsOK()
        {
            _writer.Received().WriteTrack(Arg.Is<Track>(track => track.YCoordinate.Equals(54321)));
        }

        [Test]
        public void WriteTrack_EventRaised_AltitudeIsOK()
        {
            _writer.Received().WriteTrack(Arg.Is<Track>(track => track.Altitude.Equals(17891)));
        }

        [Test]
        public void WriteTrack_EventRaised_YearIsOK()
        {
            _writer.Received().WriteTrack(Arg.Is<Track>(track => track.Timestamp.Year.Equals(2018)));
        }

        [Test]
        public void WriteTrack_EventRaised_MonthIsOK()
        {
            _writer.Received().WriteTrack(Arg.Is<Track>(track => track.Timestamp.Month.Equals(04)));
        }

        [Test]
        public void WriteTrack_EventRaised_DayIsOK()
        {
            _writer.Received().WriteTrack(Arg.Is<Track>(track => track.Timestamp.Day.Equals(09)));
        }

        [Test]
        public void WriteTrack_EventRaised_HourIsOK()
        {
            _writer.Received().WriteTrack(Arg.Is<Track>(track => track.Timestamp.Hour.Equals(15)));
        }

        [Test]
        public void WriteTrack_EventRaised_MinuteIsOK()
        {
            _writer.Received().WriteTrack(Arg.Is<Track>(track => track.Timestamp.Minute.Equals(37)));
        }

        [Test]
        public void WriteTrack_EventRaised_SecondIsOK()
        {
            _writer.Received().WriteTrack(Arg.Is<Track>(track => track.Timestamp.Second.Equals(42)));
        }

        [Test]
        public void WriteTrack_EventRaised_MillisecondIsOK()
        {
            _writer.Received().WriteTrack(Arg.Is<Track>(track => track.Timestamp.Millisecond.Equals(853)));
        }
    }
}
