using System;

namespace AirTrafficMonitoring
{
    public interface IConvertStringToDateTime
    {
        DateTime DT { get; set; }
        DateTime ConvertToDateTime(string dateString);
    }
}