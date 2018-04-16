using System;

namespace AirTrafficMonitoring
{
    public interface ITrack
    {
        int Altitude { get; set; }
        double Course { get; set; }
        string Tag { get; set; }
        DateTime Timestamp { get; set; }
        double Velocity { get; set; }
        int XCoordinate { get; set; }
        int YCoordinate { get; set; }

        string ToString();
        string ToStringLog();
    }
}