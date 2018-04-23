using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
   public interface ILogWriter
    {
        void LogEvent(string tag1, string tag2, DateTime timeofOccurrence);
        void UnlogEvent(string tag1, string tag2, DateTime timeofOccurrence);
    }
}
