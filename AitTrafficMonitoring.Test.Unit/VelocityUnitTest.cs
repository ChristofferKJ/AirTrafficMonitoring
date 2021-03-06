﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using NUnit.Framework;

namespace AitTrafficMonitoring.Test.Unit
{
    [TestFixture]
    internal class VelocityUnitTest
    {
        private ICalculateVelocity _uut;
        private Track _track1;
        private Track _track2;
        private List<Track> _tracks;

        [SetUp]
        public void Setup()
        {
            _uut = new CalculateVelocity();

            var dateTime1 = new DateTime(2018, 04, 05, 20, 20, 18);
            var dateTime2 = new DateTime(2018, 04, 05, 20, 20, 20);
            _track1 = new Track
            {
                Tag = "JHL878",
                XCoordinate = 12345,
                YCoordinate = 98765,
                Altitude = 19987,
                Timestamp = dateTime1
            };
            _track2 = new Track
            {
                Tag = "JHL878",
                XCoordinate = 92345,
                YCoordinate = 88765,
                Altitude = 19987,
                Timestamp = dateTime2
            };
            _tracks = new List<Track>
            {
                _track1,
                _track2
            };
        }

        [Test]
        public void CalcVelocity_Velocity_EqualTo40311Point29()
        {
            _uut.CalcVelocity(_track1, _track2);
            Assert.That(Math.Round(_tracks[1].Velocity, 2), Is.EqualTo(40311.29));
        }
    }
}

