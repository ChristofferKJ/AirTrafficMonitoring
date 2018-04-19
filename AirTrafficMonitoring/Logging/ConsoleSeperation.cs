using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    class ConsoleSeperation : ILogWriter
    { 
        public void LogEvent(string tag1, string tag2, DateTime timeofOccurrence)
        {
            Console.WriteLine("Alarm! \nTag: " + tag1 + " and tag: " + tag2 + " is on a collision course \nTime: " + timeofOccurrence);
        }
    }
}
