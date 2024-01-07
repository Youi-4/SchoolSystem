using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Controller;
using Domain;
using System.Linq;

namespace ControllerTest
{
    [TestClass]
    public class SemesterControllerTest
    {

       
        private SemesterController sc = new SemesterController();
        private CourseController cc = new CourseController();

        /// <summary>
        /// This method first Resets the database and then gets a list of semesters from the database
        /// and compares the length of the list to the expect result
        /// </summary>
        [TestMethod]
        public void GetSemestersTest()
        {
            //Arrange
            cc.ResetDb();
            int expected = 8;

            //Act
            List<Semester> semesters = sc.GetSemesters().ToList();
            int actual = semesters.Count;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// This method adds to the database a new semester and if the AddSememster method returns a 1
        /// it means that the semester was succesfully added
        /// </summary>
        [TestMethod]
        public void AddSemesterTest()
        {
            //Arrange
            DateTime startDate = DateTime.Parse("2000-11-11");
            DateTime endDate = DateTime.Parse("2001-11-11");
            int expected = 1;
            //Act
            int actual = sc.AddSemester(startDate, endDate);
            //Assert
            cc.ResetDb();
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// This method first adds a semester then gets the added semesters ID by calling all semesters and then deletes the added semester. 
        /// If the DeleteSememster method returns a 1 it means that the semester was succesfully deleted 
        /// The database is reset so that there is no foreign key contraint exception
        /// </summary>
        [TestMethod]
        public void DeleteSemesterTest()
        {
            //Arrange
            cc.ResetDb();
            int SemesterID = 0;
            int expected = 1;
            DateTime startDate = DateTime.Parse("2000-11-11");
            DateTime endDate = DateTime.Parse("2001-11-11");
            //Act
            sc.AddSemester(startDate, endDate);
            List<Semester> semesters = sc.GetSemesters().ToList();
            foreach(Semester s in semesters)
            {
                if(s.StartDate1 == startDate && s.EndDate1 == endDate)
                {
                    SemesterID = s.SemesterId1;
                }
            }
            int actual =sc.DeleteSemester(SemesterID);
            //Assert
            cc.ResetDb();
            Assert.AreEqual(expected, actual);
        }
    }
}
