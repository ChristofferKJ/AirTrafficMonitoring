using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace AirTrafficMonitoring
{
    public  class Controller
    {
        private readonly IWriter _writer;
        private readonly ICalculateVelocity _calculateVelocity;
        private readonly ICalculateCourse _calculateCourse;
        private IFilterAirspace _filterAirspace;

        public Controller(ITransponderReceiver myReciever, IWriter writer, ICalculateVelocity calculateVelocity, ICalculateCourse calculateCourse,IFilterAirspace filterAirspace)
        {
            _writer = writer;
            _calculateVelocity = calculateVelocity;
            _calculateCourse = calculateCourse;
            _filterAirspace = filterAirspace;
            myReciever.TransponderDataReady += _myReciever_TransponderDataReady;
        }

        private void _myReciever_TransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            var myTrack = new Track();
            ConvertTrackData convertTrackData = new ConvertTrackData(myTrack);
            var myList = e.TransponderData;

                for (int i = 0; i < myList.Count; i++)
                {
                    convertTrackData.ConvertData(myList[i]);
                    if (_filterAirspace.FilterTrack(myTrack))
                    {
                        _calculateVelocity.CalcVelocity(myTrack);
                        _calculateCourse.CalcCourse(myTrack);
                        _writer.WriteTrack(myTrack);
                    }
                }
        }
    }
}
