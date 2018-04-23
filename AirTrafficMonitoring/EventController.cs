using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
   public class EventController : IEventController
    {
        private readonly ILogWriter _logWriterToFile;
        private readonly ILogWriter _logWriterToConsole;
        private List<SeperationEvent> _currentSeperationEvents; 

        public EventController(ILogWriter logWriterToFile, ILogWriter logWriterToConsole)
        {
            _logWriterToFile = logWriterToFile;
            _logWriterToConsole = logWriterToConsole;
            _currentSeperationEvents = new List<SeperationEvent>();
        }

        public void seperationsDetected(List<SeperationEvent> newSeperationEvents)
        {
            for (var i = 0; i < newSeperationEvents.Count; i++)
            {
                if (_currentSeperationEvents.Count == 0)
                {
                    _logWriterToFile.LogEvent(newSeperationEvents[i].Tag1, newSeperationEvents[i].Tag2, newSeperationEvents[i].TimeOfOccurrence);
                    _logWriterToConsole.LogEvent(newSeperationEvents[i].Tag1, newSeperationEvents[i].Tag2, newSeperationEvents[i].TimeOfOccurrence);

                }
                for (int j = 0; j < _currentSeperationEvents.Count; j++)
                {
                    if (newSeperationEvents[i].Tag1 != _currentSeperationEvents[j].Tag1 && newSeperationEvents[i].Tag2 != _currentSeperationEvents[j].Tag2)
                    {
                        _logWriterToFile.LogEvent(newSeperationEvents[i].Tag1, newSeperationEvents[i].Tag2, newSeperationEvents[i].TimeOfOccurrence);
                        _logWriterToConsole.LogEvent(newSeperationEvents[i].Tag1, newSeperationEvents[i].Tag2, newSeperationEvents[i].TimeOfOccurrence);

                        _logWriterToFile.UnlogEvent(_currentSeperationEvents[j].Tag1, _currentSeperationEvents[j].Tag2,
                            _currentSeperationEvents[j].TimeOfOccurrence);
                        _logWriterToConsole.UnlogEvent(_currentSeperationEvents[j].Tag1, _currentSeperationEvents[j].Tag2,
                            _currentSeperationEvents[j].TimeOfOccurrence);
                    }                
                }
            }
            _currentSeperationEvents = newSeperationEvents; 
        }
    }
}
