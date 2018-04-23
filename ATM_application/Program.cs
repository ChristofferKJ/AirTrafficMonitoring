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
            var myReciever = TransponderReceiverFactory.CreateTransponderDataReceiver();
            IConvertStringToDateTime convertStringToDateTime = new ConvertStringToDateTime();
            ICalculateVelocity calculateVelocity = new CalculateVelocity();
            ICalculateCourse calculateCourse = new CalculateCourse();
            IWriter writer = new ConsoleWriter();
            ILogWriter logWriterToFile = new LogWriter();
            ILogWriter logWriterToConsole = new LogWriter();
            SeperationEvent seperationEvent = new SeperationEvent();
            IEventController eventController = new EventController(logWriterToFile,logWriterToConsole);
            ISeperationTracks seperationTracks = new SeperationTracks(seperationEvent, eventController);
            ISortingTracks sortingTracks = new SortingTracks(calculateVelocity, calculateCourse,writer,seperationTracks);
            IFilterAirspace filterAirspace = new FilterAirspace(sortingTracks);
            IConvertTrackData convertTrackData = new ConvertTrackData(myReciever,convertStringToDateTime,filterAirspace);
           
            Console.ReadKey();
        }
    }
}
