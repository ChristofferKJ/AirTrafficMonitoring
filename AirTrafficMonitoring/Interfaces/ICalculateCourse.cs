using System.Collections.Generic;

namespace AirTrafficMonitoring
{
    public interface ICalculateCourse
    {
        void CalcCourse(Track track1, Track track2);
    }
}