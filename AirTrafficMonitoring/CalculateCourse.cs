using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public class CalculateCourse : ICalculateCourse
    {
        private readonly List<Track> _trackList = new List<Track>();

        public void CalcCourse(Track track)
        {
            _trackList.Add(track);

            if (_trackList.Count == 2)
            {
                double xCoordinate0 = _trackList[0].XCoordinate;
                double xCoordinate1 = _trackList[1].XCoordinate;
                double yCoordinate0 = _trackList[0].YCoordinate;
                double yCoordinate1 = _trackList[1].YCoordinate;

                double distanceC = Math.Sqrt(Math.Pow(xCoordinate0 - xCoordinate1, 2) +
                                            Math.Pow(yCoordinate0 - yCoordinate1, 2));

                double distanceA = Math.Sqrt(Math.Pow(xCoordinate1 - xCoordinate1, 2) +
                                             Math.Pow(yCoordinate1 - yCoordinate0, 2));

                double distanceB = Math.Sqrt(Math.Pow(xCoordinate0 - xCoordinate1, 2) +
                                             Math.Pow(yCoordinate0 - yCoordinate0, 2));

                double punktB = (Math.Pow(distanceA, 2) + Math.Pow(distanceC, 2) - Math.Pow(distanceB, 2)) / 2 *
                                distanceA * distanceC;

                double vinkel = Math.Acos(punktB);

                track.Course = vinkel;

                _trackList.RemoveAt(0);
            }
        }
    }
}
