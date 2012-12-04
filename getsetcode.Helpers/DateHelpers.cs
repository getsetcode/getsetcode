using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace getsetcode.Helpers
{
    public class DateHelpers
    {
        public static int YearsSince(DateTime date)
        {
            DateTime now = DateTime.Today;
            int years = now.Year - date.Year;
            if (date > now.AddYears(-years)) years--;
            return years;
        }
    }
}
