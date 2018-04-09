using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
   public class ConsoleWriter: IWriter
    {
      
        public void WriteTrack(ConvertTrackData track)
        {
          Console.WriteLine(track.ToString());   
        }
    }
}
