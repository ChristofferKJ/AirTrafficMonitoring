using System.Collections.Generic;

namespace AirTrafficMonitoring
{
    public interface ICalculateCourse
    {
        void CalcCourse(List<ITrack> _trackList);
    }
}