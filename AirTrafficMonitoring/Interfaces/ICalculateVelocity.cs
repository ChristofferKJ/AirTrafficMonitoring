using System.Collections.Generic;

namespace AirTrafficMonitoring
{
    public interface ICalculateVelocity
    {
        void CalcVelocity(Track track1, Track track2);
    }
}