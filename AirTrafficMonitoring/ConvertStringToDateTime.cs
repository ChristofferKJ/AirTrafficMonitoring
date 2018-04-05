using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{

    //https://stackoverflow.com/questions/7580809/parse-c-sharp-string-to-datetime

    public class ConvertStringToDateTime
    {
        private DateTime _dt;

        public DateTime ConvertToDateTime(string dateString)
        {
            var year = Convert.ToInt32(dateString.Substring(0, 4));
            var month = Convert.ToInt32(dateString.Substring(4, 2));
            var day = Convert.ToInt32(dateString.Substring(6, 2));
            var hour = Convert.ToInt32(dateString.Substring(8, 2));
            var minute = Convert.ToInt32(dateString.Substring(10, 2));
            var second = Convert.ToInt32(dateString.Substring(12, 2));
            var millisecond = Convert.ToInt32(dateString.Substring(14, 3));

           // _dt = new DateTime(year,month,day,hour,minute,second,millisecond);
            _dt = DateTime.ParseExact($"{year}/{month}/{day} {hour}:{minute}:{second}:{millisecond}", "yy/MM/dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
            return _dt;
        }
    }
}
