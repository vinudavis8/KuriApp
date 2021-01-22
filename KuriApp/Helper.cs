using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuriApp
{
    public static class CommonHelper
    {
        public static string ParseDate(string date)
        {
            try
            {
                DateTime dt = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                return dt.ToString("MM/dd/yyyy HH:mm:ss");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DateTime ParseDateToDate(string date)
        {
            try
            {
                DateTime dt = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string ParseDateFromDB(string date)
        {
            try
            {
                DateTime dt = Convert.ToDateTime(date);
                //DateTime.ParseExact(date, "M/dd/yyyy", CultureInfo.InvariantCulture);
                return dt.ToString("dd/MM/yyyy");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DateTime ParseDateFromDBtoDate(string date)
        {
            try
            {
                DateTime dt = Convert.ToDateTime(date);
                //DateTime.ParseExact(date, "M/dd/yyyy", CultureInfo.InvariantCulture);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string convertDateToDBFormat(DateTime dt)
        {
            try
            {
                return dt.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
}
