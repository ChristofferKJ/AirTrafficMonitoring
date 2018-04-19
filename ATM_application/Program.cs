using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using TransponderReceiver;

namespace ATM_application
{
    class Program
    {
        static void Main(string[] args)
        {
            IConvertTrackData convertTrackData = new ConvertTrackData();
            IWriter writer = new ConsoleWriter();
            ICalculateVelocity calculateVelocity = new CalculateVelocity();
            ICalculateCourse calculateCourse = new CalculateCourse();
            IFilterAirspace filterAirspace = new FilterAirspace();
            ISortingTracks sortingTracks = new SortingTracks(calculateVelocity, calculateCourse);
            ILogWriter logWriterToFile = new LogWriter();
            ILogWriter logWriterToConsole = new LogWriter();
            ISeperationTracks seperationTracks = new SeperationTracks(logWriterToFile, logWriterToConsole);
            var myReciever = TransponderReceiverFactory.CreateTransponderDataReceiver();    
            Controller myDisplayTrack = new Controller(myReciever, convertTrackData, writer, filterAirspace, sortingTracks, seperationTracks);
         
            Console.ReadKey();
        }
    }
}
