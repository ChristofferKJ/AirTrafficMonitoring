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
    class ConvertTrackDataUnitTest
    {
        private ConvertTrackData _uut;
        private IConvertStringToDateTime _convertStringToDateTime;
        private IFilterAirspace _filterAirspace;
        private ITransponderReceiver _transponderReceiver;
        private string data;
        private Track _track;
        private List<Track> _tracklist;
        private List<string> myList;


        [SetUp]
        public void Setup()
        {
            _convertStringToDateTime = Substitute.For<IConvertStringToDateTime>();
            _filterAirspace = Substitute.For<IFilterAirspace>();
            _transponderReceiver = Substitute.For<ITransponderReceiver>();
            _uut = new ConvertTrackData(_transponderReceiver, _convertStringToDateTime, _filterAirspace);
            _track = new Track();
            _tracklist = new List<Track>();
            _tracklist.Add(_track);

            //myList = new List<string>();
            //data = "123;12345;23456;567;20180709170815852";
            //myList.Add(data);
            //var eventArgs = new RawTransponderDataEventArgs(myList);
            //_transponderReceiver.TransponderDataReady += Raise.EventWith(eventArgs);

            var track = "BIJ515;12345;54321;17891;20180409153742853";
            List<string> myList = new List<string>();
            myList.Add(track);

            var eventArgs = new RawTransponderDataEventArgs(myList);

            _transponderReceiver.TransponderDataReady += Raise.EventWith(eventArgs);
        }


        [Test]
        public void k_k_k()
        {
            _track = _uut.ConvertData(data);
            Assert.That(_track.Tag, Is.EqualTo("BIJ515"));
            Assert.That(_uut.ConvertData(data).XCoordinate, Is.EqualTo(12345));
            Assert.That(_uut.ConvertData(data).YCoordinate, Is.EqualTo(54321));
            Assert.That(_uut.ConvertData(data).Altitude, Is.EqualTo(17891));
            Assert.That(_track.Timestamp.Year, Is.EqualTo(2018));
        }

        [Test]
        public void WriteTrack_EventRaised_TagIsOK()
        {
            _filterAirspace.Received().FilterTrack(_tracklist);
        }

        [Test]
        public void WriteTrack_EventRaised_YCoordinateIsOK()
        {
            _filterAirspace.Received()
                .FilterTrack(Arg.Is<List<Track>>(track => _tracklist[0].YCoordinate.Equals(54321)));
        }
    }
}


