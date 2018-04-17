using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
   public interface ILogWriter
    {
        void LogEventToFile(string tag1, string tag2, DateTime timeofOccurrence);
    }
}
