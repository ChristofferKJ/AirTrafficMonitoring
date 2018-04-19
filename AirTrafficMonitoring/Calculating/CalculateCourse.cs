using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public class CalculateCourse : ICalculateCourse
    {

        public void CalcCourse(List<ITrack> trackList)
        {
           double deltaXCoordinate = trackList[1].XCoordinate - trackList[0].XCoordinate;
           double deltaYCoordinate = trackList[1].YCoordinate - trackList[0].YCoordinate;
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
            
           trackList[1].Course = degrees;
        }
    }
}
