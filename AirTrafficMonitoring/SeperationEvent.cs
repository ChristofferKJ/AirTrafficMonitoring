using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    class SeperationEvent
    {
        public event EventHandler Separation;

        public void Separate()
        {
            Separation?.Invoke(this, System.EventArgs.Empty);
        }
    }
}
