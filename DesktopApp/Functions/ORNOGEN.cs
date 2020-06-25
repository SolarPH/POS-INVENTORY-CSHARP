using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.Functions
{
    class ORNOGEN
    {
        public string ORNOGENstring()
        {
            string output = DateTime.Now.ToString("yyyyMMddhhmmss");
            return output;
        }

        public DateTime ORNOstringToDT(string ORNOstring)
        {
            return Convert.ToDateTime(ORNOGENtoString(ORNOstring));
        }

        public string ORNOGENtoString(string ORNOstring)
        {
            string ORNO_YEAR = ORNOstring.Substring(0, 4);
            string ORNO_MONTH = ORNOstring.Substring(4, 2);
            string ORNO_DAY = ORNOstring.Substring(6, 2);
            string ORNO_HOUR = ORNOstring.Substring(8, 2);
            string ORNO_MIN = ORNOstring.Substring(10, 2);
            string ORNO_SEC = ORNOstring.Substring(12, 2);

            string ORNO_DATE = ORNO_YEAR + "-" + ORNO_MONTH + "-" + ORNO_DAY;
            string ORNO_TIME = ORNO_HOUR + ":" + ORNO_MIN + ":" + ORNO_SEC;

            return ORNO_DATE + " " + ORNO_TIME;
        }
    }
}
