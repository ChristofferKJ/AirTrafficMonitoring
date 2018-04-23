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
            double deltaXCoordinate = track2.XCoordinate - track1.XCoordinate;
            double deltaYCoordinate = track2.YCoordinate - track1.YCoordinate;
            double degrees = 0;

            if (deltaXCoordinate == 0)
            {
                degrees = deltaYCoordinate > 0 ? 0 : 180;
            }
            else
            {
                double radians = Math.Atan2(deltaYCoordinate, deltaXCoordinate);
                degrees = radians / Math.PI * 180;

                degrees = 90 - degrees;
                if (degrees < 0) degrees += 360;
            }
            track2.Course = degrees;
        }
    }
}
