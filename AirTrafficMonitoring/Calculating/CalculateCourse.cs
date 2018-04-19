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

           double radians = Math.Atan(deltaYCoordinate/ deltaXCoordinate);
           double degrees = radians / (180 / Math.PI);

            if (deltaXCoordinate < 0 || deltaYCoordinate < 0)
                degrees += 180;
            if (deltaXCoordinate > 0 && deltaYCoordinate < 0)
                degrees -= 180;
            if (degrees <0 )
            {
                degrees += 360;
            }
            
           track2.Course = degrees;
        }
    }
}
