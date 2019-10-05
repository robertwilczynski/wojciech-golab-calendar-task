using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Calendar.Tests.Events
{
    public class EventDateCalculatorTestCases
    {
        public static IEnumerable WeeklyOccurenceTestCases
        {
            get
            {
                yield return new TestCaseData(
                    new DateTime(2019, 10, 1, 10, 0, 0), 
                    1,
                    120,
                    7,
                    new List<DayOfWeek>{ DayOfWeek.Tuesday, DayOfWeek.Wednesday },
                    new DateTime(2019, 10, 22, 12, 0, 0));
                yield return new TestCaseData(
                    new DateTime(2019, 10, 2, 10, 0, 0), 
                    1,
                    120,
                    7,
                    new List<DayOfWeek>{ DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday },
                    new DateTime(2019, 10, 16, 12, 0, 0));  
                yield return new TestCaseData(
                    new DateTime(2019, 10, 1, 10, 0, 0), 
                    1,
                    120,
                    3,
                    new List<DayOfWeek>{ DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday },
                    new DateTime(2019, 10, 4, 12, 0, 0));    
            }

        }
    }
}