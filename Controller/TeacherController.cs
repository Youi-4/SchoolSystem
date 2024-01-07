using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using DataAccess;
namespace Controller
{
    /// <summary>
    /// This Class is the business of the application related to the teachers.
    /// This class uses the data access layer to interact with the database,
    /// and is used by the Presentation layer to create, delete, update and display the objects obtained
    /// by the data access layer
    /// </summary>
    public class TeacherController
    {

        public IEnumerable<Teacher> GetTeachers()
        {

            var repo = new TeacherRepo();
            //call to return list of teachers
            var teachers = repo.DisplayAllTeachers();
            //return the Teachers

            return teachers;

        }
        public IEnumerable<College> GetTeacherCollegeBySemester(int id, string start, string end)
        {

            var repo = new TeacherRepo();
            //call to return list of colleges for a semester and teacher ID
            var Colleges = repo.DisplayTeacherCollegeBySemester(id, start, end);
            //return the Teachers

            return Colleges;

        }
        public IEnumerable<Course> GetTeacherCourseBySemester(int id, string start, string end)
        {

            var repo = new TeacherRepo();
            //call to return list of courses for a semester and teacher ID
            var courses = repo.DisplayTeacherCourseBySemester(id, start, end);
            //return the Teachers

            return courses;

        }
        public IEnumerable<Course> GetTeacherCourses(int id)
        {

            var repo = new TeacherRepo();
            //call to return list of courses for a teacher ID
            var courses = repo.DisplayTeacherCourses(id);
            //return the Teachers

            return courses;

        }
        public IEnumerable<Teacher> GetTeachersByLocation(string location)
        {

            var repo = new TeacherRepo();
            //call to return list of teachers
            var teachers = repo.TeachersByLocation(location);
            //return the Teachers

            return teachers;

        }
        public IEnumerable<Teacher> GetTeachersByLocationAndEmploymentStatus(string EmploymentStatus, string location)
        {

            var repo = new TeacherRepo();
            //call to return list of teachers
            var teachers = repo.TeachersByLocationAndEmploymentStatus(EmploymentStatus,location);
            //return the Teachers

            return teachers;

        }
        public IEnumerable<Teacher> GetTeachersBySemesterAndEmployment(string EmploymentStatus, string start, string end)
        {

            var repo = new TeacherRepo();
            //call to return list of teachers
            var teachers = repo.TeachersBySemesterAndEmploymentStatus(EmploymentStatus,start,end);
            //return the Teachers

            return teachers;

        }
        public IEnumerable<Teacher> GetTeachersBySemesterAndLocation(string Location, string start, string end)
        {

            var repo = new TeacherRepo();
            //call to return list of teachers
            var teachers = repo.TeachersBySemesterAndLocation(Location, start, end);
            //return the Teachers

            return teachers;

        }
        public IEnumerable<Teacher> GetTeachersBySemesterAndLocationAndEmploymentStatus(string EmploymentStatus,string Location, string start, string end)
        {

            var repo = new TeacherRepo();
            //call to return list of teachers
            var teachers = repo.TeachersBySemesterAndLocationAndEmploymentStatus(EmploymentStatus, Location, start, end);
            //return the Teachers

            return teachers;

        }
        public IEnumerable<Teacher> GetTeachersByEmployment(string EmployementStatus)
        {

            var repo = new TeacherRepo();
            //call to return list of teachers
            var teachers = repo.TeachersByEmploymentStatus(EmployementStatus);
            //return the Teachers

            return teachers;

        }
        
        public IEnumerable<Teacher> GetTeachersBySemester(string start,string end)
        {

            var repo = new TeacherRepo();
            //call to return list of teachers
            var teachers = repo.TeachersBySemester(start,end);
            //return the Teachers

            return teachers;

        }
        public int DeleteTeacher(int id)
        {
            var repo = new TeacherRepo();
            //calling repo to delete teacher database instance with the provided id 
            int result = repo.deleteTeacher(id);
            //return 1 if it executed correctly else 0 or -1

            return result;
        }
        public int AddTeacher(string fName, string lName, DateTime DOB, string Address, string Suburb, string State, string PostCode, string Mobile, string Gender, string Email,string Password,string basedLocation)
        {
            var repo = new TeacherRepo();
            //calling repo to add to Teacher to database table
            int result = repo.insertTeacher(fName, lName, DOB, Address, Suburb, State, PostCode, Mobile, Gender, Email,Password, basedLocation);
            //return 1 if it executed correctly else 0 or -1

            return result;
        }

        public int UpdateTeacher(int id,string fName, string lName, DateTime DOB, string Address, string Suburb, string State, string PostCode, string Mobile, string Gender, string Email, string Password, string basedLocation)
        {
            var repo = new TeacherRepo();
            //calling repo to update Teacher in database table
            int result = repo.updateTeacher(id,fName, lName, DOB, Address, Suburb, State, PostCode, Mobile, Gender, Email, Password,basedLocation);
            //return 1 if it executed correctly else 0 or -1

            return result;
        }
        public IEnumerable<Teacher> GetTeachersByNotInBasedLocation(string date)
        {
            var repo = new TeacherRepo();
            //calling all full-time teachers currently teaching in locations other than their based location
            var teachers = repo.TeachersByNotInBasedLocation(date);
            return teachers;
        }

    }
}
