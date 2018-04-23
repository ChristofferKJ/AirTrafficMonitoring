using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public class LogWriter : ILogWriter
    {
        public void LogEvent(string tag1, string tag2, DateTime timeofOccurrence)
        {
            string path = Directory.GetCurrentDirectory() + "LogFile.txt";
            string text = "Alarm! \nTag: " + tag1 + " and tag: " + tag2 + " is on a collision course \nTime: " + timeofOccurrence;
            File.WriteAllText(path, text);
        }
    }
}
