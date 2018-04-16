using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public class CalculateVelocity : ICalculateVelocity
    {
        private readonly List<Track> _trackList = new List<Track>();

        public void CalcVelocity(Track track)
        {
            _trackList.Add(track);

            if (_trackList.Count == 2 && _trackList[0].Tag == _trackList[1].Tag)
            {
                double xCoordinate0 = _trackList[0].XCoordinate;
                double xCoordinate1 = _trackList[1].XCoordinate;
                double yCoordinate0 = _trackList[0].YCoordinate;
                double yCoordinate1 = _trackList[1].YCoordinate;

                double distance = Math.Sqrt(Math.Pow(xCoordinate0 - xCoordinate1, 2) +
                         Math.Pow(yCoordinate0 - yCoordinate1, 2));

                double timedifference = _trackList[1].Timestamp.Subtract(_trackList[0].Timestamp).TotalSeconds;

                track.Velocity = distance / timedifference;

                _trackList.RemoveAt(0);
            }
        }
    }
}
