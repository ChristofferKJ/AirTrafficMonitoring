using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    class LogWriter : ILogWriter
    {
        public void LogEventToFile(ITrack track1, ITrack track2)
        {
            track1.ToStringLog();
            track2.ToStringLog();

            string text = "The patient has left the bed";
            System.IO.File.WriteAllText(@"\\Mac\Home\Documents\AU\3. semester\Programmering\Øvelse\Hospital Bed, GoF Factory\LogFile.txt", text);
        }
    }
}
