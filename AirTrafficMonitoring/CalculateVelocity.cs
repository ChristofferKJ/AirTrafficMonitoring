using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    class CalculateVelocity
    {
        public double Velocity { get; set; }

        private readonly List<Track> _trackList = new List<Track>();
        public int Counter { get; set; } = 1;

        public void CalcVelocity(Track track)
        {
            _trackList.Add(track);

            if (_trackList.Count == 2)
            {
                double XCoordinate0 = _trackList[0].XCoordinate;
                double XCoordinate1 = _trackList[1].XCoordinate;
                double YCoordinate0 = _trackList[0].YCoordinate;
                double YCoordinate1 = _trackList[1].YCoordinate;

                double distance = Math.Sqrt(Math.Pow(XCoordinate0 - XCoordinate1, 2) +
                         Math.Pow(YCoordinate0 - YCoordinate1, 2));

                double timedifference = _trackList[1].Timestamp.Subtract(_trackList[0].Timestamp).TotalSeconds;

                Velocity = distance / timedifference;

                _trackList.RemoveAt(0);
            }
        }
    }
}
