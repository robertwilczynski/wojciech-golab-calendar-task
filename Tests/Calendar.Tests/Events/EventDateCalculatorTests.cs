using NUnit.Framework;
using Calendar.Events;
using System;
using Calendar.Common.Events;
using System.Collections.Generic;


namespace Calendar.Tests.Events
{
    [TestFixture]
    public class EventDateCalculatorTests
    {
        private EventDateCalculator _eventDateCalculator;
        [SetUp]
        public void SetUp()
        {
            _eventDateCalculator = new EventDateCalculator();
        }

        [Test]
        public void CalculateEventEndDate_When_Recurrence_Is_None_Result_Should_Be_Same_As_End_Date_Input()
        {
            var startDate = new DateTime(2000, 1, 1, 10, 0, 0);
            var endDate = new DateTime(2000, 1, 1, 12, 0, 0);
            var recurrenceType = RecurrenceType.None;
            int interval = 0;
            int duration = 0;
            int? occurrences = null;
            var frequencyType = FrequencyType.None;
            var days = new List<DayOfWeek>();
            
            var result = _eventDateCalculator.CalculateEventEndDate(startDate, endDate, recurrenceType, interval, duration, occurrences, frequencyType, days);

            Assert.AreEqual(endDate, result);
        }

        [Test]
        public void CalculateEventEndDate_When_Recurrence_Is_TillDate_Result_Should_Be_Same_As_End_Date_Input()
        {
            var startDate = new DateTime(2000, 1, 1, 10, 0, 0);
            var endDate = new DateTime(2000, 1, 1, 12, 0, 0);
            var recurrenceType = RecurrenceType.TillDate;
            int interval = 0;
            int duration = 0;
            int? occurrences = null;
            var frequencyType = FrequencyType.None;
            var days = new List<DayOfWeek>();

            var result = _eventDateCalculator.CalculateEventEndDate(startDate, endDate, recurrenceType, interval, duration, occurrences, frequencyType, days);
            
            Assert.AreEqual(endDate, result);
        }

        [TestCaseSource(typeof(EventDateCalculatorTestCases), "WeeklyOccurenceTestCases")]
        public void CalculateEventEndDate_When_Recurrence_Is_Occurrence_And_Frequency_Is_Weekly_Should_Return_Expected_Result(DateTime startDate,
            int interval, int duration, int? occurrences, List<DayOfWeek> days, DateTime expectedResult)
        {
            DateTime? endDate = null;
            var recurrenceType = RecurrenceType.Occurrence;
            var frequencyType = FrequencyType.Weekly;

            var result = _eventDateCalculator.CalculateEventEndDate(startDate, endDate, recurrenceType, interval, duration, occurrences, frequencyType, days);
            
            Assert.AreEqual(expectedResult, result);
        }

        [TestCaseSource(typeof(EventDateCalculatorTestCases), "DailyOccurenceTestCases")]
        public void CalculateEventEndDate_When_Recurrence_Is_Occurrence_And_Frequency_Is_Daily_Should_Return_Expected_Result(DateTime startDate,
            int interval, int duration, int? occurrences, DateTime expectedResult)
        {
            DateTime? endDate = null;
            var recurrenceType = RecurrenceType.Occurrence;
            var frequencyType = FrequencyType.Daily;
            var days = new List<DayOfWeek>();

            var result = _eventDateCalculator.CalculateEventEndDate(startDate, endDate, recurrenceType, interval, duration, occurrences, frequencyType, days);
            
            Assert.AreEqual(expectedResult, result);
        }

        [TestCaseSource(typeof(EventDateCalculatorTestCases), "MonthlyOccurenceTestCases")]
        public void CalculateEventEndDate_When_Recurrence_Is_Occurrence_And_Frequency_Is_Monthly_Should_Return_Expected_Result(DateTime startDate,
            int interval, int duration, int? occurrences, DateTime expectedResult)
        {
            DateTime? endDate = null;
            var recurrenceType = RecurrenceType.Occurrence;
            var frequencyType = FrequencyType.Monthly;
            var days = new List<DayOfWeek>();

            var result = _eventDateCalculator.CalculateEventEndDate(startDate, endDate, recurrenceType, interval, duration, occurrences, frequencyType, days);
            
            Assert.AreEqual(expectedResult, result);
        }

        [TestCaseSource(typeof(EventDateCalculatorTestCases), "YearlyOccurenceTestCases")]
        public void CalculateEventEndDate_When_Recurrence_Is_Occurrence_And_Frequency_Is_Yearly_Should_Return_Expected_Result(DateTime startDate,
            int interval, int duration, int? occurrences, DateTime expectedResult)
        {
            DateTime? endDate = null;
            var recurrenceType = RecurrenceType.Occurrence;
            var frequencyType = FrequencyType.Yearly;
            var days = new List<DayOfWeek>();

            var result = _eventDateCalculator.CalculateEventEndDate(startDate, endDate, recurrenceType, interval, duration, occurrences, frequencyType, days);
            
            Assert.AreEqual(expectedResult, result);
        }                        
    }
}