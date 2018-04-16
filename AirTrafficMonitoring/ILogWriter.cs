using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    interface ILogWriter
    {
        void LogEventToFile(ITrack track1, ITrack track2);
    }
}
