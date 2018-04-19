using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public class SeperationTracks : ISeperationTracks
    {
        private readonly ILogWriter _logWriterToFile;
        private readonly ILogWriter _logWriterToConsole;

        public SeperationTracks(ILogWriter logWriterToFile, ILogWriter logWriterToConsole)
        {
            _logWriterToFile = logWriterToFile;
            _logWriterToConsole = logWriterToConsole;
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

                            _logWriterToFile.LogEvent(trackList[i].Tag, trackList[n].Tag, timeOfOccurrence);
                            _logWriterToConsole.LogEvent(trackList[i].Tag, trackList[n].Tag, timeOfOccurrence);
                        }
                    }
                }
            }
        }
    }
}
