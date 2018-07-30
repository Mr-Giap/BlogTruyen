using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BlogTruyen_Simple.ConvertUtil
{
    public class ConvertUtil
    {
        public static int ToInt32(object obj)
        {
            var retVal = 0;
            try
            {
                retVal = Convert.ToInt32(obj);
            }
            catch
            {
                retVal = 0;
            }
            return retVal;
        }

        public static string StringToBoolString(string obj)
        {
            var retVal = "0";
            if (obj.ToLower() == "true")
                retVal = "1";
            return retVal;
        }

        public static int ToInt32(object obj, int defaultValue)
        {
            int retVal = defaultValue;

            if (obj == null || obj == DBNull.Value)
                return retVal;

            try
            {
                retVal = Convert.ToInt32(obj);
            }
            catch
            {
                retVal = defaultValue;
            }

            return retVal;
        }

        public static double ToDouble(object obj)
        {
            double retVal = 0;

            try
            {
                retVal = Convert.ToDouble(obj);
            }
            catch
            {
                retVal = 0;
            }

            return retVal;
        }

        public static long ToLong(object obj)
        {
            long retVal = 0;

            try
            {
                retVal = Convert.ToInt64(obj);
            }
            catch
            {
                retVal = 0;
            }

            return retVal;
        }

        public static decimal ToDecimal(object obj)
        {
            decimal retVal = 0;

            try
            {
                retVal = Convert.ToDecimal(obj);
            }
            catch
            {
                retVal = 0;
            }

            return retVal;
        }

        public static double ToDouble(object obj, double defaultValue)
        {
            double retVal = 0;

            if (obj == null || obj == DBNull.Value)
                return retVal;

            try
            {
                retVal = Convert.ToDouble(obj);
            }
            catch
            {
                retVal = defaultValue;
            }

            return retVal;
        }

        public static string ToString(object obj)
        {
            string retVal = String.Empty;

            try
            {
                retVal = Convert.ToString(obj);
            }
            catch
            {
                retVal = String.Empty;
            }

            return retVal;
        }

        public static string ToString(object obj, string defaultValue)
        {
            string retVal = String.Empty;

            if (obj == null || obj == DBNull.Value)
                return retVal;

            try
            {
                retVal = Convert.ToString(obj);
            }
            catch
            {
                retVal = defaultValue;
            }

            return retVal;
        }

        public static DateTime ToDate(object obj)
        {
            DateTime retVal = DateTime.Now;
            string[] strArr = obj.ToString().Split(' ');
            int lenStrArr = strArr.Length;
            try
            {
                if (lenStrArr >= 1)
                {
                    string str = strArr[0].ToString();
                    string[] strTemp = str.ToString().Split('/');
                    if (strTemp.Length == 3)
                    {
                        string t = string.Empty;
                        if (lenStrArr == 2)
                        {
                            t = strArr[1].ToString();
                        }
                        string input = string.Format("{0}-{1}-{2} {3}", strTemp[2].ToString(), strTemp[1].ToString(), strTemp[0].ToString(), t);

                        retVal = Convert.ToDateTime(input);
                    }
                }
            }
            catch
            {
                retVal = DateTime.Now;
            }

            return retVal;
        }

        public static DateTime ToDateTime(string obj)
        {
            if (!string.IsNullOrEmpty(obj))
            {
                DateTime retVal = DateTime.Now;
                string[] strArr = obj.Split(' ');
                int lenStrArr = strArr.Length;
                try
                {
                    if (lenStrArr >= 1)
                    {
                        string str = strArr[0].ToString();
                        string[] strTemp = str.ToString().Split('/');
                        if (strTemp.Length == 3)
                        {
                            string t = string.Empty;
                            if (lenStrArr == 2)
                            {
                                t = strArr[1].ToString();
                            }
                            string input = string.Format("{0}-{2}-{1} {3}", strTemp[2].ToString(), strTemp[1].ToString(), strTemp[0].ToString(), t);

                            retVal = Convert.ToDateTime(input);
                        }
                    }
                }
                catch
                {
                    retVal = DateTime.Now;
                }

                return retVal;

            }
            else return DateTime.Now;

        }
    }
}
