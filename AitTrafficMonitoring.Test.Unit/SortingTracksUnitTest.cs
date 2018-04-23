using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using NSubstitute;
using NUnit.Framework;

namespace AitTrafficMonitoring.Test.Unit
{
    [TestFixture]
    internal class SortingTracksUnitTest
    {
        private ICalculateCourse _calculateCourse;
        private ICalculateVelocity _calculateVelocity;
        private IWriter _writer;
        private ISeperationTracks _seperationTracks; 
        private SortingTracks _uut;
        private Track _track1;
        private Track _track2;
        private Track _track3;
        private List<Track> _myCurrentList;
        private List<Track> _myNewList;
        private DateTime _date1;
        private DateTime _date2;
        private DateTime _date3;

        [SetUp]
        public void SetUp()
        {
            _myNewList = new List<Track>();
            _myCurrentList = new List<Track>();
            _date1 = new DateTime(2018, 4, 17, 20, 15, 12);
            _date2 = new DateTime(2018, 4, 17, 20, 15, 14);
            _date3 = new DateTime(2018, 4, 17, 20, 15, 14);
            _track1 = new Track
            {
                Tag = "JHL878",
                XCoordinate = 12345,
                YCoordinate = 98765,
                Altitude = 19987,
                Timestamp = _date1
            };
            _track2 = new Track
            {
                Tag = "JHL878",
                XCoordinate = 12345,
                YCoordinate = 98765,
                Altitude = 19987,
                Timestamp = _date2
            };
            _track3 = new Track
            {
                Tag = "HHH878",
                XCoordinate = 12345,
                YCoordinate = 98765,
                Altitude = 19987,
                Timestamp = _date3
            };

            _myCurrentList.Add(_track1);         
            _calculateCourse = Substitute.For<ICalculateCourse>();
            _calculateVelocity = Substitute.For<ICalculateVelocity>();
            _writer = Substitute.For<IWriter>();
            _seperationTracks = Substitute.For<ISeperationTracks>(); 
            _uut = new SortingTracks(_calculateVelocity,_calculateCourse,_writer,_seperationTracks);
        }

        [Test]
        public void SortingTracksInAirspace_TwoTracksWithSameTag_CalcVelocityIsCalled()
        {
            _uut.SortTracksInAirspace(_myCurrentList);
            _myNewList.Add(_track2);
            _uut.SortTracksInAirspace(_myNewList);
            _calculateVelocity.Received().CalcVelocity(_myCurrentList[0],_myNewList[0]);
        }

        [Test]
        public void SortingTracksInAirspace_TwoTracksWithSameTag_CalcCourseIsCalled()
        {
            _uut.SortTracksInAirspace(_myCurrentList);
            _myNewList.Add(_track2);
            _uut.SortTracksInAirspace(_myNewList);
            _calculateCourse.Received().CalcCourse(_myCurrentList[0], _myNewList[0]);
        }

        [Test]
        public void SortingTracksInAirspace_TwoTracksWithDifferentTags_CalcVelocityIsNotCalled()
        {
            _uut.SortTracksInAirspace(_myCurrentList);
            _myNewList.Add(_track3);
            _uut.SortTracksInAirspace(_myNewList);
            _calculateVelocity.DidNotReceive().CalcVelocity(_myCurrentList[0], _myNewList[0]);
        }

        [Test]
        public void SortingTracksInAirspace_TwoTracksWithDifferentTags_CalcCourseIsNotCalled()
        {
            _uut.SortTracksInAirspace(_myCurrentList);
            _myNewList.Add(_track3);
            _uut.SortTracksInAirspace(_myNewList);
            _calculateCourse.DidNotReceive().CalcCourse(_myCurrentList[0], _myNewList[0]);
        }

        [Test]
        public void SortingTracksInAirspace_OneTrackInCurrentTrackList_WriteTrackIsCalled()
        {    
            _uut.SortTracksInAirspace(_myCurrentList);
            _writer.Received().WriteTrack(_myCurrentList[0]);         
        }

        [Test]
        public void SortingTracksInAirspace_TwoTracksInCurrentTrackList_WriteTrackIsCalled()
        {
            _uut.SortTracksInAirspace(_myCurrentList);
            _myNewList.Add(_track2);
            _uut.SortTracksInAirspace(_myNewList);
            _writer.Received().WriteTrack(_myCurrentList[0]);
        }

        [Test]
        public void SortingTracksInAirspace_OneTrackInCurrentTrackList_SeprationCheckIsCalled()
        {
            _uut.SortTracksInAirspace(_myCurrentList);
            _seperationTracks.Received().SeperationCheck(_myCurrentList);
        }

        [Test]
        public void SortingTracksInAirspace__TwoTracksInCurrentTrackList_SeprationCheckIsCalled()
        {
            _uut.SortTracksInAirspace(_myCurrentList);
            _myNewList.Add(_track2);
            _uut.SortTracksInAirspace(_myNewList);
            _seperationTracks.Received().SeperationCheck(_myCurrentList);
        }
    }
}
