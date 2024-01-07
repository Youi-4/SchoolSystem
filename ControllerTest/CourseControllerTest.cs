using System;
using System.Collections.Generic;
using System.Text;
using Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using System.Linq;
using MoreLinq;
using System.Data.SqlClient;

namespace ControllerTest
{
    [TestClass]
    public class CourseControllerTest
    {
        private CourseController cc = new CourseController();
        /// <summary>
        ///  resets the database and checks to see if the default amount of units is correct
        /// </summary>
        [TestMethod]
        public void ResetDbTest()
        {
            //Arrange
            cc.ResetDb();
            int expected = 32; //default amount of  unit 
            //Act
            int actual = cc.GetUnits().ToList().Count;
            //Assert
            cc.ResetDb();
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///  resets the database and checks to see if the default amount of clusters is correct
        /// </summary>
        [TestMethod]
        public void GetClustersTest()
        {
            //Arrange
            cc.ResetDb();
            int expected = 12; //default amount of clusters
            //Act
            int actual = cc.GetClusters().ToList().Count;
            //Assert
            cc.ResetDb();
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///  resets the database and checks to see if the default amount of clusters for the given semester is correct
        /// </summary>
        [TestMethod]
        public void GetClustersBySemesterTest()
        {
            //Arrange
            cc.ResetDb();
            string semesterStart = "2019-07-18";
            string semesterEnd = "2019-12-04";
            int expected = 3; //default amount of clusters for semester above
            //Act
            int actual = cc.GetClustersBySemester(semesterStart, semesterEnd).ToList().Count;
            //Assert
            cc.ResetDb();
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void DeleteClusterTest()
        {
            bool actual = true;
            bool expected = false;
            try
            {
                //Arrange
                int clusterId = 1;

                //Act
                cc.DeleteCluster(clusterId);
                //Assert
                cc.ResetDb();
                Assert.AreEqual(expected, actual);
            }
            catch (SqlException)
            {
                //Assert
                cc.ResetDb();
                actual = false;
                Assert.AreEqual(expected, actual);
            }

        }

        [TestMethod]
        public void DeleteCourseTest()
        {
            bool actual = true;
            bool expected = false;
            try
            {
                //Arrange
                int courseId = 1;

                //Act
                cc.DeleteCourse(courseId);
                //Assert
                cc.ResetDb();
                Assert.AreEqual(expected, actual);
            }
            catch (SqlException)
            {
                //Assert
                cc.ResetDb();
                actual = false;
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void AddClusterTest()
        {
            //Arrange
            cc.ResetDb();
            bool actual = false;
            int[] unitIdArray = { 1, 2, 3 };
            string clusterName = "Cluster Test";
            string clusterDesc = "Cluster Description Test";
            //Act
            cc.AddCluster(clusterName, clusterDesc, unitIdArray[0], unitIdArray[1], unitIdArray[2]);
            List<Cluster> clusters = cc.GetClusters().ToList();
            foreach(Cluster c in clusters)
            {
                if(c.Name1 == clusterName && c.Desc1 == clusterDesc)
                {
                    actual = true;
                }
            }
            //Assert
            cc.ResetDb();
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void AddCourseTest()
        {
            //Arrange
            cc.ResetDb();
            bool expected = true;
            int[] clusterIdArray = { 1, 2, 3 };
            string courseName = "Course Test";
            string courseDesc = "Course Description Test";
            int hourPerWeek = 20;
            int cost = 850;
            //Act
            cc.AddCourse(courseName,courseDesc,hourPerWeek,cost, clusterIdArray[0], clusterIdArray[1], clusterIdArray[2]);
            bool actual = false;
            List<Course> courses = cc.GetCourses().ToList();
            foreach (Course c in courses)
            {
                if (c.Name1 == courseName && c.Desc1 == courseDesc &&c.Cost1 == cost && c.HoursPerWeek1 == hourPerWeek)
                {
                    actual = true;
                }
            }
            //Assert
            cc.ResetDb();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetCoursesTest()
        {
            //Arrange
            cc.ResetDb();
            int expected = 4; //default amount of courses
            //Act
            int actual = cc.GetCourses().ToList().Count;
            //Assert
            cc.ResetDb();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetCoursesNotInSemesterTest()
        {
            //Arrange
            cc.ResetDb();
            string expected = "CertIV In Knitting";
            //Act
            string actual = cc.GetCoursesNotInAnySemester().ToList()[0].Name1;
            //Assert
            cc.ResetDb();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetUnitsTest()
        {
            //Arrange
            cc.ResetDb();
            int expected = 32; //default amount of  unit 
            //Act
            int actual = cc.GetUnits().ToList().Count;
            //Assert
            cc.ResetDb();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetUnitsNotInCourseOrSemesterTest()
        {
            //Arrange
            cc.ResetDb();
            string expected = "Apply simple HTML";
            //Act
            string actual = cc.GetUnitsNotInCourseOrSemester().ToList()[0].Desc1;
            //Assert
            cc.ResetDb();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteUnitTest()
        {
            //Arrange
            cc.ResetDb();
            bool actual = true;
            string unitCode = "IDT27392";
            string unitDesc = "Advanced Networking";
            string unitType = "elective";
            //Act
            
            cc.AddUnit(unitCode, unitDesc, unitType);
            List<Unit> units = cc.GetUnits().ToList();
            foreach (Unit u in units)
            {
                if (u.Code1 == unitCode && u.Desc1 == unitDesc && u.Type1 == unitType)
                {
                    cc.DeleteUnit(u.UnitId1);
                }
            }
            units = cc.GetUnits().ToList();
            foreach (Unit u in units)
            {
                if (u.Code1 == unitCode && u.Desc1 == unitDesc && u.Type1 == unitType)
                {
                    actual = false;
                }
            }
            //Assert
            cc.ResetDb();
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void AddUnitTest()
        {
            //Arrange
            cc.ResetDb();
            bool expected = true;
            string unitCode = "IDT27392";
            string unitDesc = "Advanced Networking";
            string unitType = "elective";
            //Act
            bool actual = false;
            cc.AddUnit(unitCode, unitDesc, unitType);
            List<Unit> units = cc.GetUnits().ToList();
            foreach(Unit u in units)
            {
                if(u.Code1 == unitCode && u.Desc1 == unitDesc && u.Type1 == unitType)
                {
                    actual = true;
                }
            }
            //Assert
            cc.ResetDb();
            Assert.AreEqual(expected, actual);
        }
    }
}
