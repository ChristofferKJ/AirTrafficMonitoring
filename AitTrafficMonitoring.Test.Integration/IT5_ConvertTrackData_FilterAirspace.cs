﻿using System;
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
    class IT5_ConvertTrackData_FilterAirspace
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
        private RawTransponderDataEventArgs _eventArgs;

        [SetUp]
        public void SetUp()
        {
            _writer = Substitute.For<IWriter>();
            _calculateVelocity = new CalculateVelocity();
            _calculateCourse = new CalculateCourse();
            _transponderReceiver = Substitute.For<ITransponderReceiver>();
            _logWriterToFile = Substitute.For<ILogWriter>();
            _logWriterToConsole = Substitute.For<ILogWriter>();
            _convertStringToDateTime = Substitute.For<IConvertStringToDateTime>();
            _eventController = new EventController(_logWriterToFile, _logWriterToConsole);
            _seperationEvent = new SeperationEvent();
            _seperationTracks = new SeperationTracks(_seperationEvent, _eventController);
            _sortingTracks = new SortingTracks(_calculateVelocity, _calculateCourse, _writer, _seperationTracks);
            _filterAirspace = new FilterAirspace(_sortingTracks);
            _convertTrackData = new ConvertTrackData(_transponderReceiver,_convertStringToDateTime,_filterAirspace);

            _myList = new List<string>();

            _eventArgs = new RawTransponderDataEventArgs(_myList);
        }

        [Test]
        public void TransponderDataReady_TrackInAirspace_ResultOK()
        {
            string trackInAirspace = "BIJ515;12345;54321;17891;20180409153742853";

            _myList.Add(trackInAirspace);

            _transponderReceiver.TransponderDataReady += Raise.EventWith(_eventArgs);

            _writer.Received().WriteTrack(Arg.Is<Track>((x) => x.Tag == "BIJ515"));
        }

        [Test]
        public void TransponderDataReady_TrackNotInAirspace_ResultOK()
        {
            string trackOutOfAirspace = "BIJ515;90001;54321;17891;20180409153742853";

            _myList.Add(trackOutOfAirspace);

            _transponderReceiver.TransponderDataReady += Raise.EventWith(_eventArgs);

            _writer.DidNotReceive().WriteTrack(Arg.Any<Track>());
        }
    }
}
