using System.Collections.Generic;

namespace AirTrafficMonitoring
{
    public interface ISeperationTracks
    {
        void SeperationCheck(List<ITrack> trackList);
    }
}