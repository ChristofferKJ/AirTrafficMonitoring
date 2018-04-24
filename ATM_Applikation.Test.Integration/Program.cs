using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;

namespace ATM_Applikation.Test.Integration
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> transponderdataList = new List<string>();
            var track1 = "BIJ515;12345;54321;17891;20180409153742853";
            var track2 = "BIJ516;12345;54322;17891;20180409153742853";
            transponderdataList.Add(track1);
            transponderdataList.Add(track2);

            Faketransponderreciever myReciever = new Faketransponderreciever(transponderdataList);
            //var myReciever = Faketransponderreciever.ITransponderReceiver.CreateTransponderDataReceiver();

            IConvertStringToDateTime convertStringToDateTime = new ConvertStringToDateTime();
            ICalculateVelocity calculateVelocity = new CalculateVelocity();
            ICalculateCourse calculateCourse = new CalculateCourse();
            IWriter writer = new ConsoleWriter();
            ILogWriter logWriterToFile = new LogWriter();
            ILogWriter logWriterToConsole = new LogWriter();
            SeperationEvent seperationEvent = new SeperationEvent();
            IEventController eventController = new EventController(logWriterToFile, logWriterToConsole);
            ISeperationTracks seperationTracks = new SeperationTracks(seperationEvent, eventController);
            ISortingTracks sortingTracks = new SortingTracks(calculateVelocity, calculateCourse, writer, seperationTracks);
            IFilterAirspace filterAirspace = new FilterAirspace(sortingTracks);
            IConvertTrackData convertTrackData = new ConvertTrackData(myReciever, convertStringToDateTime, filterAirspace);

            Console.ReadKey();
        }
    }
}
