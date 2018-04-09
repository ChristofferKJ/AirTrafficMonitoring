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
    public class DisplayTrackUnitTest
    {
        private ITransponderReceiver _transponderReceiver;
        private DisplayTrack _uut;
        private IWriter _writer;

        [SetUp]
        public void Setup()
        {
            _writer = Substitute.For<IWriter>();
            _transponderReceiver = Substitute.For<ITransponderReceiver>(); 
            _uut = new DisplayTrack(_transponderReceiver,_writer);

            var track = "BIJ515;12345;54321;67891;20180409153742853";
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
            _writer.Received().WriteTrack(Arg.Is<Track>(track => track.Altitude.Equals(67891)));
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
