using System;
using System.Collections.Generic;

namespace Calendar.Common.Events
{
    public static class DaysExtensions {
        public static List<Days> ToEnumList(this Days days)
        {
            var flagList = new List<Days>();
            foreach (Days value in Enum.GetValues(typeof(Days)))
            {
                if ((value & days) != 0)
                    flagList.Add(value);
            }
            return flagList;
        }
    }
}