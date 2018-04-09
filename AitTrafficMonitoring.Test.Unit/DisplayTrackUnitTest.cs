using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;

namespace AitTrafficMonitoring.Test.Unit
{
    [TestFixture]
    public class DisplayTrackUnitTest
    {
        private ITransponderReceiver _iTransponderReceiver;
        private DisplayTrack _uut; 
        [SetUp]
        public void Setup()
        {
            _iTransponderReceiver = Substitute.For<ITransponderReceiver>(); 
            _uut = new DisplayTrack(_iTransponderReceiver);
        }

        [TestCase("kfkf")]
        public void kfkf_fkfkf_kfkf(string track)
        {
            List<string> myList = new List<string>();
            myList.Add(track);          

            _uut
            

        }

    }
}
