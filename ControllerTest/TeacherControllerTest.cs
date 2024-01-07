using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Controller;
using Domain;
using System.Linq;
using MoreLinq;
using System.Data.SqlClient;

namespace ControllerTest
{
    [TestClass]
    public class TeacherControllerTest
    {
        
        private CourseController cc = new CourseController();
        private TeacherController tc = new TeacherController();

        [TestMethod]
        public void GetTeachersTest()
        {
            //Arrange
            cc.ResetDb();
            int expected = 8;
            List<Teacher> teachers = tc.GetTeachers().ToList();
            //Act
            int actual = teachers.Count;
            //Assert
            cc.ResetDb();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTeacherCollegeBySemesterTest()
        {
            //Arrange
            cc.ResetDb();
            string semesterStart ="2019-02-09";
            string semesterEnd= "2019-07-03";
            int teacherId = 2;
            string expectedCollegeName = "TAFE NSW - Granville";
            //Act
            List<College> actual = tc.GetTeacherCollegeBySemester(teacherId, semesterStart, semesterEnd).ToList();
            //Assert
            cc.ResetDb();
            Assert.AreEqual(expectedCollegeName, actual[0].Name1);

        }

        [TestMethod]
        public void GetTeacherCourseBySemesterTest()
        {
            //Arrange
            cc.ResetDb();
            string semesterStart = "2019-02-09";
            string semesterEnd = "2019-07-03";
            int teacherId = 1;
            string expected = "Web Development Diploma";
            //Act
            string actual = tc.GetTeacherCourseBySemester(teacherId, semesterStart, semesterEnd).ToList()[0].Name1;
            //Assert
            cc.ResetDb();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTeacherCoursesTest()
        {
            //Arrange
            cc.ResetDb();
            int teacherId = 1;
            int expected = 2;
            //Act
            int actual = tc.GetTeacherCourses(teacherId).DistinctBy(c => c.CourseId1).ToList().Count;
            //Assert
            cc.ResetDb();
            Assert.AreEqual(expected, actual);

        }

        
        [TestMethod]
        public void GetTeacherByLocationTest()
        {
            //Arrange
            cc.ResetDb();
            int expected = 3;
            string collegeName = "TAFE NSW - Granville";
            //Act
            int actual = tc.GetTeachersByLocation(collegeName).DistinctBy(t => t.TeacherId1).ToList().Count;
            //Assert
            cc.ResetDb();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTeacherByLocationAndEmploymentStatusTest()
        {
            //Arrange
            cc.ResetDb();
            int expected = 3;
            string collegeName = "TAFE NSW - Granville";
            string employementStatus = "full-time";
            //Act
            int actual = tc.GetTeachersByLocationAndEmploymentStatus(employementStatus, collegeName).DistinctBy(t => t.TeacherId1).ToList().Count;
            //Assert
            cc.ResetDb();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTeacherBySemesterAndEmploymentTest()
        {
            //Arrange
            cc.ResetDb();
            string semesterStart = "2019-02-09";
            string semesterEnd = "2019-07-03";
            string employementStatus = "part-time";
            int expected = 1;
            //Act
            int actual = tc.GetTeachersBySemesterAndEmployment(employementStatus, semesterStart, semesterEnd).DistinctBy(t => t.TeacherId1).ToList().Count;
            //Assert
            cc.ResetDb();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTeacherBySemesterAndLocationTest()
        {
            //Arrange
            cc.ResetDb();
            string semesterStart = "2019-02-09";
            string semesterEnd = "2019-07-03";
            string collegeName = "TAFE NSW - Granville";
            int expected = 2;
            //Act
            int actual = tc.GetTeachersBySemesterAndLocation(collegeName, semesterStart, semesterEnd).DistinctBy(t => t.TeacherId1).ToList().Count;
            //Assert
            cc.ResetDb();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTeachersBySemesterAndLocationAndEmploymentStatusTest()
        {
            //Arrange
            cc.ResetDb();
            string collegeName = "TAFE NSW - Granville";
            string employementStatus = "full-time";
            string semesterStart = "2019-02-09";
            string semesterEnd = "2019-07-03";
            int expected = 2;
            //Act
            int actual = tc.GetTeachersBySemesterAndLocationAndEmploymentStatus(employementStatus, collegeName, semesterStart, semesterEnd).DistinctBy(t => t.TeacherId1).ToList().Count;
            //Assert
            cc.ResetDb();
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void GetTeachersByEmploymentTest()
        {
            //Arrange
            string employementStatus = "part-time";
            int expected = 6;
            //Act
            int actual = tc.GetTeachersByEmployment(employementStatus).DistinctBy(t => t.TeacherId1).ToList().Count;
            //Assert
            cc.ResetDb();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTeachersBySemesterTest()
        {
            //Arrange
            string semesterStart = "2019-02-09";
            string semesterEnd = "2019-07-03";
            int expected = 5;
            //Act
            int actual = tc.GetTeachersBySemester(semesterStart, semesterEnd).DistinctBy(t => t.TeacherId1).ToList().Count;
            //Assert
            cc.ResetDb();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteTeacherTest()
        {
            bool expected = false;
            
            bool actual = true;
            try { 
            //Arrange
            int teacherId = 1;
            //Act
            tc.DeleteTeacher(teacherId);
            List<Teacher> teachers = tc.GetTeachers().DistinctBy(t => t.TeacherId1).ToList();
            foreach (Teacher t in teachers)
            {
                if (t.TeacherId1 == teacherId)
                {
                    
                }
            }
           
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
        public void AddTeacherTest()
        {
            //Arrange 
            cc.ResetDb();
            //Act
            bool actual = false;
            Teacher NewTeacher = new Teacher();
            NewTeacher.FirstName1 = "Connor";
            NewTeacher.LastName1 = "Steven";
            NewTeacher.Mobile1 = "0426348732";
            NewTeacher.Suburb1 = "Landsvalle";
            NewTeacher.StreetAddress1 = "24 Teller St";
            NewTeacher.State1 = "NSW";
            NewTeacher.PostCode1 = "2353";
            NewTeacher.Password1 = "Connor";
            NewTeacher.Gender1 = "M";
            NewTeacher.Email1 = "ConnorSteven@tafensw.com";
            NewTeacher.BasedLocation1 = "TAFE NSW - Meadowbank";
            NewTeacher.DOB1 = DateTime.Parse("1980-07-03");
            tc.AddTeacher(NewTeacher.FirstName1, NewTeacher.LastName1, NewTeacher.DOB1, NewTeacher.StreetAddress1, NewTeacher.Suburb1,
                NewTeacher.State1, NewTeacher.PostCode1, NewTeacher.Mobile1, NewTeacher.Gender1, NewTeacher.Email1, NewTeacher.Password1, NewTeacher.BasedLocation1);
            List<Teacher> teachers = tc.GetTeachers().DistinctBy(t => t.TeacherId1).ToList();
            foreach (Teacher t in teachers)
            {
                if(t.FirstName1 == NewTeacher.FirstName1 && t.LastName1 == NewTeacher.LastName1 && t.StreetAddress1 == NewTeacher.StreetAddress1)
                {
                    actual = true;
                }
            }
            cc.ResetDb();
            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void UpdateTeacherTest()
        {
            //Arrange DeleteTeacher
            cc.ResetDb();
            Teacher UpdatedTeacher = new Teacher();
            //All the variables that are left blank will not be updated;
            UpdatedTeacher.TeacherId1 = 1;
            UpdatedTeacher.FirstName1 = "";
            UpdatedTeacher.LastName1 = "";
            UpdatedTeacher.Suburb1 = "";
            UpdatedTeacher.StreetAddress1 = "";
            UpdatedTeacher.State1 = "";
            UpdatedTeacher.PostCode1 = "";
            UpdatedTeacher.Password1 = "";
            UpdatedTeacher.Gender1 = "";
            UpdatedTeacher.Email1 = "";
            UpdatedTeacher.BasedLocation1 = "";
            UpdatedTeacher.DOB1 = DateTime.Parse("9999-11-11");//This is the default dob that will be passed in the store procedure if the teacher dob is not being changed 
            //The above line of code makes sure that the original teacher dob will not be changed
            UpdatedTeacher.Mobile1 = "0418374658"; //Only the teaccher mobile mobile will be updated
            //Act
            tc.UpdateTeacher(UpdatedTeacher.TeacherId1,UpdatedTeacher.FirstName1,UpdatedTeacher.LastName1,
                UpdatedTeacher.DOB1,UpdatedTeacher.StreetAddress1,UpdatedTeacher.Suburb1,
                UpdatedTeacher.State1,UpdatedTeacher.PostCode1,UpdatedTeacher.Mobile1,
                UpdatedTeacher.Gender1,UpdatedTeacher.Email1,UpdatedTeacher.Password1,UpdatedTeacher.BasedLocation1);
            List <Teacher> teachers = tc.GetTeachers().DistinctBy(t => t.TeacherId1).ToList();
            bool actual = false;
            foreach (Teacher t in teachers)
            {
                if (t.TeacherId1 == 1 && t.Mobile1 == "0418374658")
                {
                    actual = true;
                }
            }
            //Assert
            cc.ResetDb();
            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void GetTeachersByNotInBasedLocation()
        {
            //Arrange
            cc.ResetDb();
            string now = DateTime.Now.ToString();
            int expected = 2;
            //Act
            int actual = tc.GetTeachersByNotInBasedLocation(now).DistinctBy(t => t.TeacherId1).ToList().Count;
            //Assert
            cc.ResetDb();
            Assert.AreEqual(expected, actual);
        }

    }
}
