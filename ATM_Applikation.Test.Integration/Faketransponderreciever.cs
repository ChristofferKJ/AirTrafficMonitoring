using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Applikation.Test.Integration
{
    public class Faketransponderreciever : EventArgs
    {
        public List<string> TransponderData { get; set; }
        public Faketransponderreciever(List<string> transponderData)

        {
            TransponderData = transponderData;
        }
        
        public interface ITransponderReceiver

        {
            event EventHandler<Faketransponderreciever> TransponderDataReady;
        }
    }
}
