using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazeIt_Commander
{
    static class Conversions
    {
        public static string BytesConversion(double bytes)
        {
            //zdroj: stackoverflow 
            //vezme velikost v bytech a převede na jednotky dle velikosti... vrátí jako string 
            var culture = CultureInfo.CurrentUICulture;
            const string format = "#,0.0";

            if (bytes < 1024)
                return bytes.ToString("#,0", culture);
            bytes /= 1024;
            if (bytes < 1024)
                return bytes.ToString(format, culture) + " KB";
            bytes /= 1024;
            if (bytes < 1024)
                return bytes.ToString(format, culture) + " MB";
            bytes /= 1024;
            if (bytes < 1024)
                return bytes.ToString(format, culture) + " GB";
            bytes /= 1024;
            return bytes.ToString(format, culture) + " TB";
        }
    }
}
