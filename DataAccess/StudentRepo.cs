using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Domain;
namespace DataAccess
{
    /// <summary>
    /// This Class is the Data Access layer of the application related to the students in the database
    /// </summary>
    public class StudentRepo
    {
        /// <summary>
        /// connection to database
        /// </summary>
        private string connectionString = @"Data Source=DESKTOP-GVF1QR7\SQLEXPRESS;Initial Catalog=TafeSystem;Integrated Security=True";

        /// <summary>
        /// returns all a list of students in the database 
        /// </summary>
        /// <returns></returns>
        public List<Student> DisplayAllStudents()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            List<Student> students = new List<Student>();
            SqlCommand command = new SqlCommand("sp_SelectAllStudents", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    int id = reader.GetInt32(0);
                    string firstn = reader.GetString(1);
                    string lastn = reader.GetString(2);
                    DateTime dob = reader.GetDateTime(3);
                    string streetAd = reader.GetString(4);
                    string suburb = reader.GetString(5);
                    string state = reader.GetString(6);
                    string postcode = reader.GetString(7);
                    string mobile = reader.GetString(8);
                    string gender = reader.GetString(9);
                    string email = reader.GetString(10);
                    students.Add(new Student(id, firstn, lastn, dob, streetAd, suburb, state, postcode, mobile, gender, email));

                }

            }
            connection.Close();
            return students;
        }
        /// <summary>
        /// Deletes the student with the specified ID
        /// </summary>
        /// <param name="studentId">student ID that will be deleted from the database</param>
        /// <returns></returns>
        public int deleteStudent(int studentId)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            SqlCommand command = new SqlCommand("sp_DeleteStudent", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@studentId", studentId));
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;
        }
        /// <summary>
        /// inserts a new student into the database with the following parameters
        /// </summary>
        /// <param name="fName">first name</param>
        /// <param name="lName">last name</param>
        /// <param name="DOB">date of birth</param>
        /// <param name="Address">street address</param>
        /// <param name="Suburb">suburb of address</param>
        /// <param name="State">state of addresss</param>
        /// <param name="PostCode">postcode of address</param>
        /// <param name="Mobile">Student Mobile</param>
        /// <param name="Gender">Student Gender</param>
        /// <param name="Email">Student Email</param>
        /// <returns></returns>
        public int insertStudent(string fName, string lName, DateTime DOB, string Address, string Suburb, string State, string PostCode, string Mobile, string Gender, string Email)
        {
            if (fName == "" || fName.Equals(null) || lName == "" || lName.Equals(null)|| DOB == null || Address == "" || Address.Equals(null) || Suburb == "" || Suburb.Equals(null)
                || State == "" || State.Equals(null) || PostCode == "" || PostCode.Equals(null) || Mobile == "" || Mobile.Equals(null) || Gender == "" || Gender.Equals(null)
                || Email == "" || Email.Equals(null)
                )
            {
                return 0;
            }
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            SqlCommand command = new SqlCommand("sp_InsertStudent", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@fname", fName));
            command.Parameters.Add(new SqlParameter("@lname", lName));
            command.Parameters.Add(new SqlParameter("@dob", DOB));
            command.Parameters.Add(new SqlParameter("@streetAdd",Address ));
            command.Parameters.Add(new SqlParameter("@suburb", Suburb));
            command.Parameters.Add(new SqlParameter("@state", State));
            command.Parameters.Add(new SqlParameter("@postcode", PostCode));
            command.Parameters.Add(new SqlParameter("@mobile", Mobile));
            command.Parameters.Add(new SqlParameter("@gender", Gender));
            command.Parameters.Add(new SqlParameter("@email", Email));
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;

        }
        /// <summary>
        /// Updates the student with following parameters but if parameter is left blank that specific parameter will not be updated
        /// </summary>
        /// <param name="id">Student ID</param>
        /// <param name="fName">first name</param>
        /// <param name="lName">last name</param>
        /// <param name="DOB">date of birth</param>
        /// <param name="Address">street address</param>
        /// <param name="Suburb">suburb of address</param>
        /// <param name="State">state of addresss</param>
        /// <param name="PostCode">postcode of address</param>
        /// <param name="Mobile">Student Mobile</param>
        /// <param name="Gender">Student Gender</param>
        /// <param name="Email">Student Email</param>
        /// <returns></returns>
        public int updateStudent(int id, string fName, string lName, DateTime DOB, string Address, string Suburb, string State, string PostCode, string Mobile, string Gender, string Email)
        {

            if (
                string.IsNullOrEmpty(fName) && string.IsNullOrEmpty(lName) && DOB == DateTime.Parse("9999-11-11") && string.IsNullOrEmpty(Address) && string.IsNullOrEmpty(Suburb)
                && string.IsNullOrEmpty(State) && string.IsNullOrEmpty(PostCode) && string.IsNullOrEmpty(Mobile) && string.IsNullOrEmpty(Gender)
                && string.IsNullOrEmpty(Email) 
                )
            {
                return 4;
            }
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            SqlCommand command = new SqlCommand("sp_UpdateStudent", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Id", id));
            command.Parameters.Add(new SqlParameter("@fname", fName));
            command.Parameters.Add(new SqlParameter("@lname", lName));
            command.Parameters.Add(new SqlParameter("@dob", DOB));
            command.Parameters.Add(new SqlParameter("@streetAdd", Address));
            command.Parameters.Add(new SqlParameter("@suburb", Suburb));
            command.Parameters.Add(new SqlParameter("@state", State));
            command.Parameters.Add(new SqlParameter("@postcode", PostCode));
            command.Parameters.Add(new SqlParameter("@mobile", Mobile));
            command.Parameters.Add(new SqlParameter("@gender", Gender));
            command.Parameters.Add(new SqlParameter("@email", Email));
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;

        }
        /// <summary>
        /// Returns a list of students according to their studyStatus, either full-time or part-time
        /// </summary>
        /// <param name="studyStatus"></param>
        /// <returns></returns>
        public List<Student> StudentsByStudyStatus(string studyStatus)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            List<Student> students = new List<Student>();
            SqlCommand command = new SqlCommand("sp_StudentsByStudyStatus", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@studyStatus", studyStatus));
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    int id = reader.GetInt32(0);
                    string firstn = reader.GetString(1);
                    string lastn = reader.GetString(2);
                    DateTime dob = reader.GetDateTime(3);
                    string streetAd = reader.GetString(4);
                    string suburb = reader.GetString(5);
                    string state = reader.GetString(6);
                    string postcode = reader.GetString(7);
                    string mobile = reader.GetString(8);
                    string gender = reader.GetString(9);
                    string email = reader.GetString(10);
                    students.Add(new Student(id, firstn, lastn, dob, streetAd, suburb, state, postcode, mobile, gender, email));
                }

            }
            connection.Close();
            return students;
        }
        /// <summary>
        /// returns a list of students according to a specific semester
        /// </summary>
        /// <param name="start">start date of the semester</param>
        /// <param name="end">end date of the semester</param>
        /// <returns></returns>
        public List<Student> StudentsBySemester(string start, string end)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            List<Student> students = new List<Student>();
            SqlCommand command = new SqlCommand("sp_StudentsBySemester", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@startDate", DateTime.Parse(start)));
            command.Parameters.Add(new SqlParameter("@endDate", DateTime.Parse(end)));
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    int id = reader.GetInt32(0);
                    string firstn = reader.GetString(1);
                    string lastn = reader.GetString(2);
                    DateTime dob = reader.GetDateTime(3);
                    string streetAd = reader.GetString(4);
                    string suburb = reader.GetString(5);
                    string state = reader.GetString(6);
                    string postcode = reader.GetString(7);
                    string mobile = reader.GetString(8);
                    string gender = reader.GetString(9);
                    string email = reader.GetString(10);
                    students.Add(new Student(id, firstn, lastn, dob, streetAd, suburb, state, postcode, mobile, gender, email));
                }

            }
            connection.Close();
            return students;
        }
        /// <summary>
        /// returns a list of students according to a specific semester and their studystatus
        /// </summary>
        /// <param name="studyStatus">this is either full-time or part-time</param>
        /// <param name="start">start date of the semester</param>
        /// <param name="end">end date of the semester</param>
        /// <returns></returns>
        public List<Student> StudentsBySemesterAndStudyStatus(string studyStatus, string start, string end)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            List<Student> students = new List<Student>();
            SqlCommand command = new SqlCommand("sp_StudentsBySemesterAndStudyStatus", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@startDate", DateTime.Parse(start)));
            command.Parameters.Add(new SqlParameter("@endDate", DateTime.Parse(end)));
            command.Parameters.Add(new SqlParameter("@studyStatus", studyStatus));
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    int id = reader.GetInt32(0);
                    string firstn = reader.GetString(1);
                    string lastn = reader.GetString(2);
                    DateTime dob = reader.GetDateTime(3);
                    string streetAd = reader.GetString(4);
                    string suburb = reader.GetString(5);
                    string state = reader.GetString(6);
                    string postcode = reader.GetString(7);
                    string mobile = reader.GetString(8);
                    string gender = reader.GetString(9);
                    string email = reader.GetString(10);
                    students.Add(new Student(id, firstn, lastn, dob, streetAd, suburb, state, postcode, mobile, gender, email));
                }

            }
            connection.Close();
            return students;
        }

        /// <summary>
        /// returns a list of students according to a specific semester, studystatus and the location that they studied
        /// </summary>
        /// <param name="studyStatus">this is either full-time or part-time</param>
        /// <param name="start">start date of the semester</param>
        /// <param name="end">end date of the semester</param>
        /// <param name="location">the college</param>
        /// <returns></returns>
        public List<Student> StudentsBySemesterAndLocationAndStudyStatus(string studyStatus,string location, string start, string end)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            List<Student> students = new List<Student>();
            SqlCommand command = new SqlCommand("sp_StudentsBySemesterAndLocationAndStudyStatus", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@startDate", DateTime.Parse(start)));
            command.Parameters.Add(new SqlParameter("@endDate", DateTime.Parse(end)));
            command.Parameters.Add(new SqlParameter("@studyStatus", studyStatus));
            command.Parameters.Add(new SqlParameter("@location", location));
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    int id = reader.GetInt32(0);
                    string firstn = reader.GetString(1);
                    string lastn = reader.GetString(2);
                    DateTime dob = reader.GetDateTime(3);
                    string streetAd = reader.GetString(4);
                    string suburb = reader.GetString(5);
                    string state = reader.GetString(6);
                    string postcode = reader.GetString(7);
                    string mobile = reader.GetString(8);
                    string gender = reader.GetString(9);
                    string email = reader.GetString(10);
                    students.Add(new Student(id, firstn, lastn, dob, streetAd, suburb, state, postcode, mobile, gender, email));
                }

            }
            connection.Close();
            return students;
        }
        /// <summary>
        /// This returns a list of students that have not paid thier course fees
        /// It does this by comparing the payment table connected to the enrolment table to the course table cost column
        /// </summary>
        /// <returns></returns>
        public List<Student> StudentsEnrolledNotPaid()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            List<Student> students = new List<Student>();
            SqlCommand command = new SqlCommand("sp_StudentsEnrolledNotPaid", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    int id = reader.GetInt32(0);
                    string firstn = reader.GetString(1);
                    string lastn = reader.GetString(2);
                    DateTime dob = reader.GetDateTime(3);
                    string streetAd = reader.GetString(4);
                    string suburb = reader.GetString(5);
                    string state = reader.GetString(6);
                    string postcode = reader.GetString(7);
                    string mobile = reader.GetString(8);
                    string gender = reader.GetString(9);
                    string email = reader.GetString(10);
                    students.Add(new Student(id, firstn, lastn, dob, streetAd, suburb, state, postcode, mobile, gender, email));
                }

            }
            connection.Close();
            return students;
        }
        /// <summary>
        /// Returns a list of students according to a specific location and study status
        /// </summary>
        /// <param name="studyStatus">this is either full-time or part-time</param>
        /// <param name="location">the college</param>
        /// <returns></returns>
        public List<Student> StudentsByStudyStatusAndLocation(string location, string studyStatus)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            List<Student> students = new List<Student>();
            SqlCommand command = new SqlCommand("sp_StudentsByStudyStatusAndLocation", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@studyStatus", studyStatus));
            command.Parameters.Add(new SqlParameter("@location", location));
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    int id = reader.GetInt32(0);
                    string firstn = reader.GetString(1);
                    string lastn = reader.GetString(2);
                    DateTime dob = reader.GetDateTime(3);
                    string streetAd = reader.GetString(4);
                    string suburb = reader.GetString(5);
                    string state = reader.GetString(6);
                    string postcode = reader.GetString(7);
                    string mobile = reader.GetString(8);
                    string gender = reader.GetString(9);
                    string email = reader.GetString(10);
                    students.Add(new Student(id, firstn, lastn, dob, streetAd, suburb, state, postcode, mobile, gender, email));
                }

            }
            connection.Close();
            return students;
        }
        /// <summary>
        /// takes a student object and then searchs for their enrolments and adds them to the student object
        /// then it returns the student object with the added enrolments
        /// </summary>
        /// <param name="student">this parameter is the student which enrolments will be search and added</param>
        /// <returns></returns>
        public Student StudentEnrolments(Student student)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            SqlCommand command = new SqlCommand("sp_StudentEnrolments", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@studentId", student.StudentId1));
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int enrolId = reader.GetInt32(0);
                    int studentId = reader.GetInt32(1);
                    int courseId = reader.GetInt32(2);
                    int collegeId = reader.GetInt32(3);
                    int semesterId = reader.GetInt32(4);
                    int paymentId = reader.GetInt32(5);
                    DateTime enrolDate = reader.GetDateTime(6);
                    string result = reader.GetString(7);
                    string courseName=reader.GetString(8);
                    string collegeName = reader.GetString(9);
                    student.addEnrolment(new Enrolment(enrolId, studentId, courseId, semesterId, enrolDate, collegeId, paymentId, courseName, result, collegeName));

                }

            }
            connection.Close();
            return student;
        }
        /// <summary>
        /// Returns a list of students according to a specific location and semester
        /// </summary>
        /// <param name="start">start date of the semester</param>
        /// <param name="end">end date of the semester</param>
        /// <param name="location">the college</param>
        /// <returns></returns>
        public List<Student> StudentsBySemesterAndLocation(string location,string start, string end)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            List<Student> students = new List<Student>();
            SqlCommand command = new SqlCommand("sp_StudentsBySemesterAndLocation", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@startDate", DateTime.Parse(start)));
            command.Parameters.Add(new SqlParameter("@endDate", DateTime.Parse(end)));
            command.Parameters.Add(new SqlParameter("@location", location));
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    int id = reader.GetInt32(0);
                    string firstn = reader.GetString(1);
                    string lastn = reader.GetString(2);
                    DateTime dob = reader.GetDateTime(3);
                    string streetAd = reader.GetString(4);
                    string suburb = reader.GetString(5);
                    string state = reader.GetString(6);
                    string postcode = reader.GetString(7);
                    string mobile = reader.GetString(8);
                    string gender = reader.GetString(9);
                    string email = reader.GetString(10);
                    students.Add(new Student(id, firstn, lastn, dob, streetAd, suburb, state, postcode, mobile, gender, email));
                }

            }
            connection.Close();
            return students;
        }
        /// <summary>
        /// Returns a list of students according to a specific location
        /// </summary>
        /// <param name="location">the college</param>
        /// <returns></returns>
        public List<Student> StudentsByLocation(string location)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            List<Student> students = new List<Student>();
            SqlCommand command = new SqlCommand("sp_StudentsByLocation", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@location", location));
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    int id = reader.GetInt32(0);
                    string firstn = reader.GetString(1);
                    string lastn = reader.GetString(2);
                    DateTime dob = reader.GetDateTime(3);
                    string streetAd = reader.GetString(4);
                    string suburb = reader.GetString(5);
                    string state = reader.GetString(6);
                    string postcode = reader.GetString(7);
                    string mobile = reader.GetString(8);
                    string gender = reader.GetString(9);
                    string email = reader.GetString(10);
                    students.Add(new Student(id, firstn, lastn, dob, streetAd, suburb, state, postcode, mobile, gender, email));
                }

            }
            connection.Close();
            return students;
        }

    }
}
