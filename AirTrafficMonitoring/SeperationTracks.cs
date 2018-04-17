using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public class SeperationTracks : ISeperationTracks
    {
        private readonly ILogWriter _logWriter;

        public SeperationTracks(ILogWriter logWriter)
        {
            _logWriter = logWriter;
        }

        public void SeperationCheck(List<Track> trackList)
        {
            for (var i = 0; i < trackList.Count; i++)
                if (trackList[i].Tag != trackList[i + 1].Tag)
                {
                    double xCoordinate0 = trackList[i].XCoordinate;
                    double xCoordinate1 = trackList[i + 1].XCoordinate;
                    double yCoordinate0 = trackList[i].YCoordinate;
                    double yCoordinate1 = trackList[i + 1].YCoordinate;

                    var HorisentalDist = Math.Sqrt(Math.Pow(xCoordinate0 - xCoordinate1, 2) +
                                                   Math.Pow(yCoordinate0 - yCoordinate1, 2));
                    double VertikalDist = Math.Abs(trackList[i].Altitude - trackList[i + 1].Altitude);
                    if (HorisentalDist < 5000 && VertikalDist < 300)
                    {
                        var timeOfOccurrence = trackList[i].Timestamp > trackList[i + 1].Timestamp
                            ? trackList[i].Timestamp
                            : trackList[i + 1].Timestamp;

                        _logWriter.LogEventToFile(trackList[i].Tag, trackList[i + 1].Tag, timeOfOccurrence);
                    }
                }
        }
    }
}
