using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public class CalculateCourse : ICalculateCourse
    {
        public void CalcCourse(Track track1, Track track2)
        {
            int distance1 = track2.XCoordinate - track1.XCoordinate;
            int distance2 = track2.YCoordinate - track1.YCoordinate;
            int distance3 = track2.YCoordinate - 90000;

            double sideA = 90000 - track1.YCoordinate;
            double sideB = Math.Sqrt(Math.Pow(distance1, 2) + Math.Pow(distance2, 2));
            double sideC = Math.Sqrt(Math.Pow(distance1, 2) + Math.Pow(distance3, 2));

            double radians = Math.Acos((Math.Pow(sideA, 2) + Math.Pow(sideB, 2) - Math.Pow(sideC, 2)) / (2 * sideA * sideB));
            var degrees = radians * 180 / Math.PI;
            track2.Course = degrees;
        }
    }
}
