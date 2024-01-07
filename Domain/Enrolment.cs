using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Enrolment
    {
        private int EnrolmentID;
        private int StudentID;
        private int CourseID;
        private int CollegeID;
        private int PaymentID;
        private string CourseName;
        private string Result;
        private int SemesterID;
        DateTime EnrolmentDate;
        private string CollegeName;

       
        public Enrolment()
        {

        }

        public Enrolment(int enrolmentID1, int studentID1, int courseID1, int semesterID1, DateTime enrolmentDate1, int collegeID1, int paymentID1, string courseName1, string result1, string collegeName1)
        {
            EnrolmentID1 = enrolmentID1;
            StudentID1 = studentID1;
            CourseID1 = courseID1;
            SemesterID1 = semesterID1;
            EnrolmentDate1 = enrolmentDate1;
            CollegeID1 = collegeID1;
            PaymentID1 = paymentID1;
            CourseName1 = courseName1;
            Result1 = result1;
            CollegeName1 = collegeName1;
        }

        public int EnrolmentID1 { get => EnrolmentID; set => EnrolmentID = value; }
        public int StudentID1 { get => StudentID; set => StudentID = value; }
        public int CourseID1 { get => CourseID; set => CourseID = value; }
        public int SemesterID1 { get => SemesterID; set => SemesterID = value; }
        public DateTime EnrolmentDate1 { get => EnrolmentDate; set => EnrolmentDate = value; }
        public int CollegeID1 { get => CollegeID; set => CollegeID = value; }
        public int PaymentID1 { get => PaymentID; set => PaymentID = value; }
        public string CourseName1 { get => CourseName; set => CourseName = value; }
        public string Result1 { get => Result; set => Result = value; }
        public string CollegeName1 { get => CollegeName; set => CollegeName = value; }
    }
}
