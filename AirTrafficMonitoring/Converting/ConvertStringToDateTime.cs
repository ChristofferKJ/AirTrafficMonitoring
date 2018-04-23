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

    public class ConvertStringToDateTime : IConvertStringToDateTime
    {
        public DateTime DT { get; set; }

        public DateTime ConvertToDateTime(string dateString)
        {
            DT = DateTime.ParseExact(dateString, "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);

            return DT;
        }
    }
}
