using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public class SeperationTracks : ISeperationTracks
    {   
        private readonly SeperationEvent _seperationEvent;
        private readonly IEventController _eventController;
        private readonly List<SeperationEvent> _seperationList; 

        public SeperationTracks(SeperationEvent seperationEvent, IEventController eventController)
        {
            _seperationEvent = seperationEvent;
            _eventController = eventController;
            _seperationList = new List<SeperationEvent>();
        }

        public void SeperationCheck(List<Track> trackList)
        {
            for (var i = 0; i < trackList.Count; i++)
            {
                for (int n = i + 1; n < trackList.Count; n++)
                {
                    if (trackList.Count >= 2 && trackList[i].Tag != trackList[n].Tag)
                    {
                        double xCoordinate0 = trackList[i].XCoordinate;
                        double xCoordinate1 = trackList[n].XCoordinate;
                        double yCoordinate0 = trackList[i].YCoordinate;
                        double yCoordinate1 = trackList[n].YCoordinate;

                        var horisentalDist = Math.Sqrt(Math.Pow(xCoordinate0 - xCoordinate1, 2) +
                                                       Math.Pow(yCoordinate0 - yCoordinate1, 2));

                        double vertikalDist = Math.Abs(trackList[i].Altitude - trackList[n].Altitude);

                        if (horisentalDist < 5000 && vertikalDist < 300)
                        {
                            var timeOfOccurrence = trackList[i].Timestamp > trackList[n].Timestamp
                                ? trackList[i].Timestamp
                                : trackList[n].Timestamp;
                                                     
                                _seperationEvent.Tag1 = trackList[i].Tag;
                                _seperationEvent.Tag2 = trackList[n].Tag;
                                _seperationEvent.TimeOfOccurrence = timeOfOccurrence;

                                _seperationList.Add(_seperationEvent);
                                _eventController.seperationsDetected(_seperationList);                          
                        }
                    }
                }
            }
        }
    }
}
