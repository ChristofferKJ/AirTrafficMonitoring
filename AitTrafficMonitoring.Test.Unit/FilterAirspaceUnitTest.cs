using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using AirTrafficMonitoring;


namespace AitTrafficMonitoring.Test.Unit
{
    [TestFixture]
    public class FilterAirspaceUnitTest
    {
        private IFilterAirspace _uut;
        private Track _track;
        private List<Track> _tracklist;
        private ISortingTracks _sortingTracks;

        [SetUp]
        public void Setup()
        {
            _sortingTracks = Substitute.For<ISortingTracks>();
            _uut = new FilterAirspace(_sortingTracks);
            _tracklist = new List<Track>();
        }
        [Test]
        public void FilterTrack_TrackIsInAirspace_TrackIsOk()
        {
            _track = new Track { XCoordinate = 89999, YCoordinate = 89999, Altitude = 19999 };

            _tracklist.Add(_track);

            _uut.FilterTrack(_tracklist);

            Assert.That(_tracklist.Count,Is.EqualTo(1));
        }

        [Test]
        public void FilterTrack_TrackIsInAirspace_TrackIsOk2()
        {
            _track = new Track { XCoordinate = 10001, YCoordinate = 10001, Altitude = 501 };

            _tracklist.Add(_track);

            _uut.FilterTrack(_tracklist);

            Assert.That(_tracklist.Count, Is.EqualTo(1));
        }

        [Test]
        public void FilterTrack_XIsToLow_TrackDeleted()
        {
            _track = new Track { XCoordinate = 10000, YCoordinate = 10001, Altitude = 501 };

            _tracklist.Add(_track);

            _uut.FilterTrack(_tracklist);

            Assert.That(_tracklist.Count, Is.EqualTo(1));
        }

        [Test]
        public void FilterTrack_YIsToLow_TrackDeleted()
        {
            _track = new Track { XCoordinate = 10001, YCoordinate = 9999, Altitude = 501 };

            _tracklist.Add(_track);

            _uut.FilterTrack(_tracklist);

            Assert.That(_tracklist.Count, Is.EqualTo(0));
        }
        [Test]
        public void FilterTrack_AltIsToLow_TrackDeleted()
        {
            _track = new Track { XCoordinate = 10001, YCoordinate = 10001, Altitude = 499 };

            _tracklist.Add(_track);

            _uut.FilterTrack(_tracklist);

            Assert.That(_tracklist.Count, Is.EqualTo(0));
        }

        [Test]
        public void FilterTrack_XIsToHigh_TrackDeleted()
        {
            _track = new Track { XCoordinate = 90001, YCoordinate = 89999, Altitude = 19999 };

            _tracklist.Add(_track);

            _uut.FilterTrack(_tracklist);

            Assert.That(_tracklist.Count, Is.EqualTo(0));

        }


        [Test]
        public void FilterTrack_YIsToHigh_TrackDeleted()
        {
            _track = new Track { XCoordinate = 89999, YCoordinate = 90001, Altitude = 19999 };

            _tracklist.Add(_track);

            _uut.FilterTrack(_tracklist);

            Assert.That(_tracklist.Count, Is.EqualTo(0));

        }

        [Test]
        public void FilterTrack_AltIsToHigh_TrackDeleted()
        {
            _track = new Track { XCoordinate = 89999, YCoordinate = 89999, Altitude = 20001 };

            _tracklist.Add(_track);

            _uut.FilterTrack(_tracklist);

            Assert.That(_tracklist.Count, Is.EqualTo(0));

        }

        [Test]
        public void FilterTrack_TrackIsInAirspace_TrackIsOkm()
        {
            _track = new Track { XCoordinate = 89999, YCoordinate = 89999, Altitude = 19999 };

            _tracklist.Add(_track);

            _uut.FilterTrack(_tracklist);

            _sortingTracks.Received().SortTracksInAirspace(_tracklist);
        }
    }
}