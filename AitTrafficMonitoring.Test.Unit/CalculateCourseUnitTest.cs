using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using Castle.DynamicProxy.Generators;
using NUnit.Framework;

namespace AitTrafficMonitoring.Test.Unit
{
    [TestFixture]
    public class CalculateCourseUnitTest
    {
        private ICalculateCourse _uut;
        private List<Track> _tracklist;
        private Track _track1;
        private Track _track2;

        [SetUp]
        public void setup()
        {
            _uut = new CalculateCourse();
            _tracklist = new List<Track>();

            _track1 = new Track
            {
                Tag = "BIJ515",
                XCoordinate = 65884,
                YCoordinate = 21948

            };
            _track2 = new Track
            {
                Tag = "BIJ515",
                XCoordinate = 75884,
                YCoordinate = 31948
            };

        }
        [Test]
        public void CalcCourse_jfjf_kkfk()
        {
            _tracklist.Add(_track1);
            _tracklist.Add(_track2);
           // _uut.CalcCourse(_tracklist);
            Assert.That(_tracklist[1].Course,Is.EqualTo(315));

        }
    }
}
