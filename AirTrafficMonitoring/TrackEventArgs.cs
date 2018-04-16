using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public class TrackEventArgs : EventArgs
    {
        public ITrack ITrack { get; set; }
    }
}
