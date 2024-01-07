using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ControllerTest
{
    [TestClass]
    public class CollegeControllerTest
    {
        
        private CourseController cc = new CourseController();
        private CollegeController collegeController = new CollegeController();
        /// <summary>
        /// This method first Resets the database and then gets a list of colleges from the database
        /// and compares the length of the list to the expect result
        /// </summary>
        [TestMethod]
        public void GetGollegesTest()
        {
            //Arrange
            cc.ResetDb();
            int expected = 8;
            //Act
            List<College> colleges = collegeController.GetColleges().ToList();
            int actual = colleges.Count;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// This method adds to the database a new college and if the AddCollege method returns a 1
        /// it means that the college was succesfully added to the database
        /// </summary>
        [TestMethod]
        public void AddCollegeTest()
        {
            //Arrange
            string collegeName = "testName";
            string collegeLocation = "testLocation";
            int expected = 1;
            //Act
            int actual =collegeController.AddCollege(collegeName, collegeLocation);
            //Assert
            Assert.AreEqual(actual, expected);

        }

        /// <summary>
        /// This method first adds a college then gets the added colleges ID by calling all colleges in the database
        /// and then deletes the added college. 
        /// If the DeleteCollege method returns a 1 it means that the college was succesfully deleted
        /// The database is reset so that there is no foreign key contraint exception
        /// </summary>
        [TestMethod]
        public void DeleteCollege()
        {
            //Arrange
            int CollegeId = 0;
            cc.ResetDb();
            int expected = 1;
            string collegeName = "testName";
            string collegeLocation = "testLocation";
            //Act
            collegeController.AddCollege(collegeName, collegeLocation);
            List<College> colleges = collegeController.GetColleges().ToList();
            foreach(College c in colleges)
            {
                if(c.Name1== collegeName && c.CollegeLocation1 == collegeLocation)
                {
                    CollegeId = c.CollegeId1;
                }
            }
            int actual = collegeController.DeleteCollege(CollegeId);
            //Assert
            Assert.AreEqual(expected, actual);
        }


    }
}
