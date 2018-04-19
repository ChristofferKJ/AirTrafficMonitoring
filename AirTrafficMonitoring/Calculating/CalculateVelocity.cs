using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public class CalculateVelocity : ICalculateVelocity
    {
        public void CalcVelocity(Track track1, Track track2)
        {
                double xCoordinate0 = track1.XCoordinate;
                double xCoordinate1 = track2.XCoordinate;
                double yCoordinate0 = track1.YCoordinate;
                double yCoordinate1 = track2.YCoordinate;

                double distance = Math.Sqrt(Math.Pow(xCoordinate0 - xCoordinate1, 2) +
                         Math.Pow(yCoordinate0 - yCoordinate1, 2));

                double timedifference = track2.Timestamp.Subtract(track1.Timestamp).TotalSeconds;

                track2.Velocity = distance / timedifference;            
        }
    }
}
