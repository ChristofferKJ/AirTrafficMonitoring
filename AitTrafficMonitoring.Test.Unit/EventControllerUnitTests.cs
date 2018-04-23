using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using NSubstitute;
using NUnit.Framework;

namespace AitTrafficMonitoring.Test.Unit
{
    [TestFixture]
    class EventControllerUnitTests
    {
        private IEventController _uut;
        private ILogWriter _logWriterToFile;
        private ILogWriter _logWriterToConsole;
        private SeperationEvent _seperationEvent1;
        private SeperationEvent _seperationEvent2;
        private List<SeperationEvent> _newEventslist;
        private List<SeperationEvent> _currentSeperationEvents;
        private DateTime _date1;
        private DateTime _date2;
        private SeperationEvent _seperationEvent3;

        [SetUp]
        public void Setup()
        {
            _logWriterToFile = Substitute.For<ILogWriter>();
            _logWriterToConsole = Substitute.For<ILogWriter>();
            _currentSeperationEvents = new List<SeperationEvent>();
            _newEventslist = new List<SeperationEvent>();
            _uut = new EventController(_logWriterToFile, _logWriterToConsole);
            _date1 = new DateTime(2018,07,02,14,07,15);
            _date2 = new DateTime(2018, 07, 02, 14, 07, 19);

            _seperationEvent1 = new SeperationEvent
            {
                Tag1 = "DJE900",
                Tag2 = "SJE900",
                TimeOfOccurrence = _date1
            };

            _seperationEvent2 = new SeperationEvent
            {
                Tag1 = "DJE900",
                Tag2 = "SJE900",
                TimeOfOccurrence = _date2
            };

            _seperationEvent3 = new SeperationEvent
            {
                Tag1 = "DJE100",
                Tag2 = "SJE100",
                TimeOfOccurrence = _date2
            };
        }

        [Test]
        public void SeperationsDetected_NewSeperationEventAndOldSeperationEventGone_NewEventLoggedAndOldEventUnlogged()
        {
            _currentSeperationEvents.Add(_seperationEvent2);
            _newEventslist.Add(_seperationEvent3);

            _uut.seperationsDetected(_currentSeperationEvents);
            _uut.seperationsDetected(_newEventslist);

            _logWriterToFile.Received().LogEvent(_seperationEvent3.Tag1, _seperationEvent3.Tag2, _seperationEvent3.TimeOfOccurrence);
            _logWriterToConsole.Received().LogEvent(_seperationEvent3.Tag1, _seperationEvent3.Tag2, _seperationEvent3.TimeOfOccurrence);

            _logWriterToFile.Received().UnlogEvent(_seperationEvent2.Tag1, _seperationEvent2.Tag2, _seperationEvent2.TimeOfOccurrence);
            _logWriterToConsole.Received().UnlogEvent(_seperationEvent2.Tag1, _seperationEvent2.Tag2, _seperationEvent2.TimeOfOccurrence);
        }

        [Test]
        public void SeperationsDetected_EventAlreadyLogged_NoLogging()
        {
            _currentSeperationEvents.Add(_seperationEvent1);
            _uut.seperationsDetected(_currentSeperationEvents);

            _newEventslist.Add(_seperationEvent2);
            _uut.seperationsDetected(_newEventslist);

            _logWriterToFile.DidNotReceive().LogEvent(_seperationEvent2.Tag1, _seperationEvent2.Tag2, _seperationEvent2.TimeOfOccurrence);
            _logWriterToConsole.DidNotReceive().LogEvent(_seperationEvent2.Tag1, _seperationEvent2.Tag2, _seperationEvent2.TimeOfOccurrence);

            _logWriterToFile.DidNotReceive().UnlogEvent(_seperationEvent1.Tag1, _seperationEvent1.Tag2, _seperationEvent1.TimeOfOccurrence);
            _logWriterToConsole.DidNotReceive().UnlogEvent(_seperationEvent1.Tag1, _seperationEvent1.Tag2, _seperationEvent1.TimeOfOccurrence);
        }

        [Test]
        public void SeperationsDetected_NewEvent_Log()
        {
            _newEventslist.Add(_seperationEvent2);

            _uut.seperationsDetected(_newEventslist);

            _logWriterToFile.Received().LogEvent(_seperationEvent2.Tag1, _seperationEvent2.Tag2, _seperationEvent2.TimeOfOccurrence);
            _logWriterToConsole.Received().LogEvent(_seperationEvent2.Tag1, _seperationEvent2.Tag2, _seperationEvent2.TimeOfOccurrence);
        }
    }
}
