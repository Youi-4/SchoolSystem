using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Domain;
namespace Controller
{
    /// <summary>
    /// This Class is the business of the application related to the students.
    /// This class uses the data access layer to interact with the database,
    /// and is used by the Presentation layer to create, delete, update and display the objects obtained
    /// by the data access layer
    /// </summary>
    public class StudentController
    {

        public IEnumerable<Student> GetStudents()
        {

            var repo = new StudentRepo();
            //calling to return list of students
            var students = repo.DisplayAllStudents();
            //return the students

            return students;

        }

        public int DeleteStudent(int id)
        {
            var repo = new StudentRepo();
            //calling repo to delete student database instance with the provided id 
            int result = repo.deleteStudent(id);
            //return 1 if it executed correctly else 0 or -1

            return result;
        }
        public int AddStudent(string fName, string lName, DateTime DOB, string Address, string Suburb, string State, string PostCode, string Mobile, string Gender, string Email)
        {
            var repo = new StudentRepo();
            //calling repo to add to Student to database table
            int result = repo.insertStudent(fName, lName, DOB, Address, Suburb, State, PostCode, Mobile, Gender, Email);
            //return 1 if it executed correctly else 0 or -1

            return result;
        }
        public IEnumerable<Student> GetStudentsByLocation(string location)
        {

            var repo = new StudentRepo();
            //call to return list of students by location
            var students = repo.StudentsByLocation(location);
            //return the students

            return students;

        }

        public IEnumerable<Student> GetStudentsEnrolledNotPaid()
        {

            var repo = new StudentRepo();
            //call to return list of students by those who have not paid
            var students = repo.StudentsEnrolledNotPaid();
            //return the students

            return students;

        }
        public Student GetStudentEnrolments(Student student)
        {

            var repo = new StudentRepo();
            //call to return student enrolments
            Student studentEnrolments = repo.StudentEnrolments(student);
            //return the student

            return studentEnrolments;

        }

        public IEnumerable<Student> GetStudentsByStudyStatus(string studyStatus)
        {

            var repo = new StudentRepo();
            //call to return list of students by with full-time or part-time
            var students = repo.StudentsByStudyStatus(studyStatus);
            //return the students

            return students;

        }

        public List<Student> GetStudentsByStudyStatusAndLocation(string location, string studyStatus)
        {
            var repo = new StudentRepo();
            //call to return list of students by  study status and location
            var students = repo.StudentsByStudyStatusAndLocation(location, studyStatus);
            //return the students

            return students;
        }
        public List<Student> GetStudentsBySemesterAndLocationAndStudyStatus(string studyStatus, string location, string start, string end)
        {
            var repo = new StudentRepo();
            //call to return list of students by  study status,location and semester
            var students = repo.StudentsBySemesterAndLocationAndStudyStatus(studyStatus, location,start,end);
            //return the students

            return students;
        }
        public List<Student> GetStudentsBySemesterAndStudyStatus(string studyStatus, string start, string end)
        {
            var repo = new StudentRepo();
            //call to return list of students by Semester and study status
            var students = repo.StudentsBySemesterAndStudyStatus(studyStatus, start, end);
            //return the students

            return students;
        }
        public IEnumerable<Student> GetStudentsBySemesterAndLocation(string location,string start, string end)
        {

            var repo = new StudentRepo();
            //call to return list of students by Semester and location
            var students = repo.StudentsBySemesterAndLocation(location,start, end);
            //return the students

            return students;

        }
        public IEnumerable<Student> GetStudentsBySemester(string start, string end)
        {

            var repo = new StudentRepo();
            //call to return list of students by Semester
            var students = repo.StudentsBySemester(start, end);
            //return the students

            return students;

        }
        public int UpdateStudent(int id, string fName, string lName, DateTime DOB, string Address, string Suburb, string State, string PostCode, string Mobile, string Gender, string Email)
        {
            var repo = new StudentRepo();
            //calling repo to update Student in database table
            int result = repo.updateStudent(id, fName, lName, DOB, Address, Suburb, State, PostCode, Mobile, Gender, Email);
            //return 1 if it executed correctly else 0 or -1

            return result;
        }
    }
}
