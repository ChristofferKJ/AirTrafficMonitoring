using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public class CalculateVelocity : ICalculateVelocity
    {
        //private readonly List<Track> _trackList = new List<Track>();

        public void CalcVelocity(List<ITrack> trackList)
        {
            //if (trackList.Count == 2)
            {
                double xCoordinate0 = trackList[0].XCoordinate;
                double xCoordinate1 = trackList[1].XCoordinate;
                double yCoordinate0 = trackList[0].YCoordinate;
                double yCoordinate1 = trackList[1].YCoordinate;

                double distance = Math.Sqrt(Math.Pow(xCoordinate0 - xCoordinate1, 2) +
                         Math.Pow(yCoordinate0 - yCoordinate1, 2));

                double timedifference = trackList[1].Timestamp.Subtract(trackList[0].Timestamp).TotalSeconds;

                trackList[1].Velocity = distance / timedifference;

                trackList.RemoveAt(0);
            }
        }
    }
}
