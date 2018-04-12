using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    interface ILogWriter
    {
        void LogEventToFile(Track track1, Track track2);
    }
}
