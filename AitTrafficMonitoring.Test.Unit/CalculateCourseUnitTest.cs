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
        private Track _track1;
        private Track _track2;

        [SetUp]
        public void Setup()
        {
            _uut = new CalculateCourse();

            _track1 = new Track
            {
                Tag = "BIJ515",
                XCoordinate = 90000,
                YCoordinate = 90000
            };

            _track2 = new Track
            {
                Tag = "BIJ515",
                XCoordinate = 10000,
                YCoordinate = 10000
            };
        }

        [Test]
        public void CalcCourse_SouthWest_CourseOK()
        {
            _uut.CalcCourse(_track1,_track2);
            Assert.That(Math.Round(_track2.Course),Is.EqualTo(225));
        }

        [Test]
        public void CalcCourse_NorthEast_CourseOK()
        {
            _track1.XCoordinate = 10000;
            _track1.YCoordinate = 10000;
            _track2.XCoordinate = 90000;
            _track2.YCoordinate = 90000;

            _uut.CalcCourse(_track1, _track2);
            Assert.That(Math.Round(_track2.Course), Is.EqualTo(45));
        }

        [Test]
        public void CalcCourse_North_CourseOK()
        {
            _track1.XCoordinate = 10000;
            _track1.YCoordinate = 10000;
            _track2.XCoordinate = 10000;
            _track2.YCoordinate = 90000;

            _uut.CalcCourse(_track1, _track2);
            Assert.That(Math.Round(_track2.Course), Is.EqualTo(0));
        }

        [Test]
        public void CalcCourse_South_CourseOK()
        {
            _track1.XCoordinate = 10000;
            _track1.YCoordinate = 90000;
            _track2.XCoordinate = 10000;
            _track2.YCoordinate = 10000;

            _uut.CalcCourse(_track1, _track2);
            Assert.That(Math.Round(_track2.Course), Is.EqualTo(180));
        }

        [Test]
        public void CalcCourse_West_CourseOK()
        {
            _track1.XCoordinate = 90000;
            _track1.YCoordinate = 90000;
            _track2.XCoordinate = 10000;
            _track2.YCoordinate = 90000;

            _uut.CalcCourse(_track1, _track2);
            Assert.That(Math.Round(_track2.Course), Is.EqualTo(270));
        }

        [Test]
        public void CalcCourse_East_CourseOK()
        {
            _track1.XCoordinate = 10000;
            _track1.YCoordinate = 90000;
            _track2.XCoordinate = 90000;
            _track2.YCoordinate = 90000;

            _uut.CalcCourse(_track1, _track2);
            Assert.That(Math.Round(_track2.Course), Is.EqualTo(90));
        }
    }
}
