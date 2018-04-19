using System;

namespace AirTrafficMonitoring
{
    public interface IConvertStringToDateTime
    {
        DateTime ConvertToDateTime(string dateString);
    }
}