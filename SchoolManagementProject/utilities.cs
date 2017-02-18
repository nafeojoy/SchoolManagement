using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Reflection;
using System.Data;


namespace SchoolManagementProject
{
    public class Utilities
    {

        public string ToDayInString()
        {
            return String.Format("{0:dd/MM/yyyy}", DateTime.Today).Replace('-', '/');
        }

        public string ToDateTimeInString()
        {
            return String.Format("{0:dd/MM/yyyy}", DateTime.Today).Replace('-', '/') + " " + DateTime.Now.ToShortTimeString();            
        }

        public string DateToString(DateTime dateTime)
        {
            return String.Format("{0:dd/MM/yyyy}", dateTime).Replace('-', '/');
        }
        public string DateToString2(DateTime dateTime)
        {
            return String.Format("{0:dd.MM.yyyy}", dateTime).Replace('-', '.');
        }
        private static decimal PrerecordNo = 0;
        private static decimal _autoNo = 1;
        public  decimal GenerateJobNumber(decimal prefix)
        {
            decimal pre=0;
            _autoNo = _autoNo + 1;
            string mJobNumber = string.Empty;
            if (prefix.ToString().Length > 4)
            {
                pre = decimal.Parse(prefix.ToString().Substring(0, 2));
            }
            else
                pre = prefix;
            mJobNumber = string.Format("{0}{1}{2}{3}", pre, DateTime.Today.Day.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Year.ToString().Substring(2,2), DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString(), System.DateTime.Now.Millisecond);
        
            if (PrerecordNo == 0)
                PrerecordNo = Convert.ToDecimal(mJobNumber);
            else if (PrerecordNo == Convert.ToDecimal(mJobNumber))
                mJobNumber = mJobNumber + _autoNo;

            return Convert.ToDecimal(mJobNumber);
        }
        public string DateToStringInSql(DateTime dateTime)
        {
            return String.Format("{0:yyyy-MM-dd}", dateTime);
        }
    }
}
