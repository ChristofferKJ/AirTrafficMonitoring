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
        public DateTime ConvertToDateTime(string dateString)
        {
            var dt = DateTime.ParseExact(dateString, "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);

            return dt;
        }
    }
}
