using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MtbVisualizer.Data;
using MtbVisualizer.Models.Activities;
using MtbVisualizer.Models.MonthSummary;
using MtbVisualizerTest.Doubles;

namespace MtbVisualizerTest
{
    [TestClass]
    public class MonthSummaryTest
    {
        ICollection<VisualActivity> visualActivities;
        DateTime today;
        DateTime thisMonday; 

        [TestInitialize]
        public void Setup()
        {
            visualActivities = TestData.MonthVisualActivitiesList();
            today = new DateTime(2019, 10, 17);
            thisMonday = new DateTime(2019, 10, 14);
        }

        [TestMethod]
        public void Test_Get_Current_Month()
        {
            MonthSummary month = new MonthSummary(today, (List<VisualActivity>) visualActivities);
            
            Assert.AreEqual(today.Month, month.Month);
        }

        [TestMethod]
        public void Test_Get_Activities_For_Month()
        {
            MonthSummary month = new MonthSummary(today, (List<VisualActivity>) visualActivities);

            var result = (List<VisualActivity>) month.Activites;

            Assert.AreEqual(30, result.Count);
            Assert.AreEqual(today.Month, result[0].Summary.StartDate.Value.Month);
        }

        [TestMethod]
        public void Test_Get_Current_Week_Start_Date()
        {
            MonthSummary month = new MonthSummary(today, (List<VisualActivity>) visualActivities);
           
            var result = month.WeekStartDate;
            
            Assert.AreEqual( thisMonday.Date, result.Date);
        }

        [TestMethod]
        public void Test_Get_Current_Week_Start_Date_On_Sunday()
        {
            var sunday = new DateTime(2019, 10, 20);
            MonthSummary month = new MonthSummary(sunday, (List<VisualActivity>)visualActivities);

            var result = month.WeekStartDate;

            Assert.AreEqual(thisMonday.Date, result.Date);
        }

        [TestMethod]
        public void Test_Get_Current_Week_Start_Date_On_A_New_MOnth()
        {
            var dateOnNewMonth = new DateTime(2019, 11, 01);
            var startOfTheWeek = new DateTime(2019, 10, 28);
            MonthSummary month = new MonthSummary(dateOnNewMonth, (List<VisualActivity>)visualActivities);

            var result = month.WeekStartDate;

            Assert.AreEqual(startOfTheWeek.Date, result.Date);
        }

        [TestMethod]
        public void Test_Get_Activities_For_Week()
        {
            MonthSummary month = new MonthSummary(today, (List<VisualActivity>)visualActivities);

            var result = month.getActivitiesForThisWeek((List<VisualActivity>)visualActivities);

            Assert.AreEqual(7, result.Count);
        }



        [TestMethod]
        public void Test_Get_Activities_For_Week_On_A_New_Month()
        {

            var dateOnNewMonth = new DateTime(2019, 11, 01);            
            var month = ExampleData.GetMonthSummary();
                       
            var result = month.getActivitiesForThisWeek(month.Activites);

            Assert.AreEqual(1, result.Count);
        }        
    }
}
