using System.Collections.Generic;

namespace AirTrafficMonitoring
{
    public interface ICalculateVelocity
    {
        void CalcVelocity(List<ITrack> trackList);
    }
}