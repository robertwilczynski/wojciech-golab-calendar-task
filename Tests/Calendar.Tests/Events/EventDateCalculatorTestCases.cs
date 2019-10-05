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
                    new DateTime(2019, 10, 22, 12, 0, 0)).SetName("When interval is not divided by the days count without the rest");
                yield return new TestCaseData(
                    new DateTime(2019, 10, 1, 10, 0, 0), 
                    1,
                    120,
                    3,
                    new List<DayOfWeek>{ DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday },
                    new DateTime(2019, 10, 3, 12, 0, 0)).SetName("When amount of occurrences is less than days");    
                yield return new TestCaseData(
                    new DateTime(2019, 10, 1, 10, 0, 0), 
                    1,
                    120,
                    1,
                    new List<DayOfWeek>{ DayOfWeek.Tuesday },
                    new DateTime(2019, 10, 1, 12, 0, 0)).SetName("When there is only one occurrence");    
                yield return new TestCaseData(
                    new DateTime(2019, 10, 1, 10, 0, 0), 
                    1,
                    120,
                    10,
                    new List<DayOfWeek>{ DayOfWeek.Tuesday, DayOfWeek.Wednesday },
                    new DateTime(2019, 10, 30, 12, 0, 0)).SetName("When interval is divided by days without the rest");
                yield return new TestCaseData(
                    new DateTime(2019, 10, 1, 10, 0, 0), 
                    1,
                    120,
                    2,
                    new List<DayOfWeek>{ DayOfWeek.Tuesday, DayOfWeek.Wednesday },
                    new DateTime(2019, 10, 2, 12, 0, 0)).SetName("When occurrences are only in one week");       
                yield return new TestCaseData(
                    new DateTime(2019, 10, 1, 10, 0, 0), 
                    2,
                    120,
                    4,
                    new List<DayOfWeek>{ DayOfWeek.Tuesday, DayOfWeek.Wednesday },
                    new DateTime(2019, 10, 16, 12, 0, 0)).SetName("When interval is every 2 weeks");                            
            }

        }
        public static IEnumerable DailyOccurenceTestCases
        {
            get
            {
                yield return new TestCaseData(
                    new DateTime(2019, 10, 1, 10, 0, 0), 
                    1,
                    120,
                    12,
                    new DateTime(2019, 10, 12, 12, 0, 0)).SetName("Everyday for 12 days");
                yield return new TestCaseData(
                    new DateTime(2019, 10, 1, 10, 0, 0), 
                    1,
                    120,
                    1,
                    new DateTime(2019, 10, 1, 12, 0, 0)).SetName("Only once");
                yield return new TestCaseData(
                    new DateTime(2019, 10, 1, 10, 0, 0), 
                    2,
                    120,
                    6,
                    new DateTime(2019, 10, 11, 12, 0, 0)).SetName("Every second day, 6 times");
            }

        }
        public static IEnumerable MonthlyOccurenceTestCases
        {
            get
            {
                yield return new TestCaseData(
                    new DateTime(2019, 10, 1, 10, 0, 0), 
                    1,
                    120,
                    6,
                    new DateTime(2020, 3, 1, 12, 0, 0)).SetName("Every month, 6 times");
                yield return new TestCaseData(
                    new DateTime(2019, 10, 1, 10, 0, 0), 
                    1,
                    120,
                    1,
                    new DateTime(2019, 10, 1, 12, 0, 0)).SetName("Every month once");
                yield return new TestCaseData(
                    new DateTime(2019, 10, 1, 10, 0, 0), 
                    3,
                    120,
                    5,
                    new DateTime(2020, 10, 1, 12, 0, 0)).SetName("Every third month, 5 times");
            }

        }
        public static IEnumerable YearlyOccurenceTestCases
        {
            get
            {
                yield return new TestCaseData(
                    new DateTime(2019, 10, 1, 10, 0, 0), 
                    1,
                    120,
                    1,
                    new DateTime(2019, 10, 1, 12, 0, 0)).SetName("Once a year, one time");
                yield return new TestCaseData(
                    new DateTime(2019, 10, 1, 10, 0, 0), 
                    4,
                    120,
                    2,
                    new DateTime(2023, 10, 1, 12, 0, 0)).SetName("Every 4 years, twice");
            }

        }
    }
}