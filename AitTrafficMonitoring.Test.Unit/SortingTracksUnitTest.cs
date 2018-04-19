using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TransponderReceiver;

namespace AitTrafficMonitoring.Test.Unit
{
    [TestFixture]
    class SortingTracksUnitTest
    {
        public Dictionary<string, List<ITrack>> TracksDictionary { get; set; }
        private ICalculateCourse _calculateCourse;
        private ICalculateVelocity _calculateVelocity;
        private SortingTracks _uut; 
        private Track _track1;
        private Track _track2;
        private Track _track3; 
        [SetUp]
        public void SetUp()
        {
            _track1 = new Track
            {
                Tag = "JHL878",
                //XCoordinate = 12345,
                //YCoordinate = 98765,
                //Altitude = 19987,
                //Timestamp = dateTime1
            };
            _track2 = new Track
            {
                Tag = "JHL878",
                //XCoordinate = 12345,
                //YCoordinate = 98765,
                //Altitude = 19987,
                //Timestamp = dateTime1
            };
            _track3 = new Track
            {
                Tag = "HHH878",
                //XCoordinate = 12345,
                //YCoordinate = 98765,
                //Altitude = 19987,
                //Timestamp = dateTime1
            };

            List<Track> myList;
            
           // myList.Add(_track1);
            _calculateCourse = Substitute.For<ICalculateCourse>();
            _calculateVelocity = Substitute.For<ICalculateVelocity>(); 
            _uut = new SortingTracks(_calculateVelocity,_calculateCourse);
        }

        [Test]
        public void ksks_sksks_sksk()
        {

                _uut.
                _uut.SortTracksInAirspace(Arg.Is<Track>(track => track.Tag.Contains("BIJ515")))
        }
    }
}
