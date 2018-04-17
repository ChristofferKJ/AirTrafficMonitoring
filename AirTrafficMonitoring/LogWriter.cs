using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    class LogWriter : ILogWriter
    {
        public void LogEventToFile(string tag1, string tag2, DateTime timeofOccurrence)
        {
            string path = Directory.GetCurrentDirectory();
            string text = "Alarm! \nTag: " + tag1 + " and tag: " + tag2 + " is on a collision course \nTime: " + timeofOccurrence;
            System.IO.File.WriteAllText(path, text);
        }
    }
}
