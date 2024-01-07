using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Domain;
namespace DataAccess
{
    /// <summary>
    /// This Class is the Data Access layer of the application related to the teachers in the database 
    /// </summary>
    public class TeacherRepo
    {
        /// <summary>
        /// connection to database
        /// </summary>
        private string connectionString = @"Data Source=DESKTOP-GVF1QR7\SQLEXPRESS;Initial Catalog=TafeSystem;Integrated Security=True";
        
        /// <summary>
        /// calls a stored procedure to get a list of all teachers
        /// </summary>
        /// <returns>All teachers in the database</returns>
        public List<Teacher> DisplayAllTeachers()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            List<Teacher> teachers = new List<Teacher>();
            SqlCommand command = new SqlCommand("sp_SelectAllTeachers", connection);
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
                    string password = reader.GetString(11);
                    string basedLocation = reader.GetString(12);
                    teachers.Add(new Teacher(id, firstn, lastn, dob, streetAd, suburb, state, postcode, mobile, gender, email, password, basedLocation));
                }

            }
            connection.Close();
            return teachers;
        }

        /// <summary>
        /// returns a list of teachers according to the location parameter
        /// </summary>
        /// <param name="location">College name</param>
        /// <returns></returns>
        public List<Teacher> TeachersByLocation(string location)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            List<Teacher> teachers = new List<Teacher>();
            SqlCommand command = new SqlCommand("sp_TeachersByLocation", connection);
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
                    string password = reader.GetString(11);
                    string basedLocation = reader.GetString(12);
                    teachers.Add(new Teacher(id, firstn, lastn, dob, streetAd, suburb, state, postcode, mobile, gender, email, password, basedLocation));
                }

            }
            connection.Close();
            return teachers;
        }

        /// <summary>
        /// returns a list of teachers that teach courses according to the start and end parameters of a semesters
        /// </summary>
        /// <param name="start">start of the semester</param>
        /// <param name="end">end of the semester</param>
        /// <returns></returns>
        public List<Teacher> TeachersBySemester(string start, string end)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            List<Teacher> teachers = new List<Teacher>();
            SqlCommand command = new SqlCommand("sp_TeachersBySemester", connection);
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
                    string password = reader.GetString(11);
                    string basedLocation = reader.GetString(12);
                    teachers.Add(new Teacher(id, firstn, lastn, dob, streetAd, suburb, state, postcode, mobile, gender, email, password, basedLocation));
                }

            }
            connection.Close();
            return teachers;
        }
        /// <summary>
        /// returns a list of teachers that teach courses according to their employment status such as full-time and part-time
        /// </summary>
        /// <param name="EmploymentStatus"></param>
        /// <returns></returns>
        public List<Teacher> TeachersByEmploymentStatus(string EmploymentStatus)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            List<Teacher> teachers = new List<Teacher>();
            SqlCommand command = new SqlCommand("sp_TeachersEmploymentStatus", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@employmentStatus", EmploymentStatus));
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
                    string password = reader.GetString(11);
                    string basedLocation = reader.GetString(12);
                    teachers.Add(new Teacher(id, firstn, lastn, dob, streetAd, suburb, state, postcode, mobile, gender, email, password, basedLocation));
                }

            }
            connection.Close();
            return teachers;
        }
        /// <summary>
        /// returns a list of college according to specific teacher in a semester
        /// </summary>
        /// <param name="TeacherID">the specific teacher ID. this will be used to identify which teacher to look for</param>
        /// <param name="start">semester start</param>
        /// <param name="end">semester end</param>
        /// <returns></returns>
        public List<College> DisplayTeacherCollegeBySemester(int TeacherID, string start, string end)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            List<College> colleges = new List<College>();
            SqlCommand command = new SqlCommand("sp_TeacherSemesterLocation", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@start", DateTime.Parse(start)));
            command.Parameters.Add(new SqlParameter("@end", DateTime.Parse(end)));
            command.Parameters.Add(new SqlParameter("@teacherId",TeacherID));
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int Collgeid = reader.GetInt32(0);
                    string CollegeName = reader.GetString(1);
                    string CollegeLocation = reader.GetString(2);
                    colleges.Add(new College(Collgeid, CollegeName, CollegeLocation));


                }

            }
            connection.Close();
            return colleges;

        }
        /// <summary>
        /// returns a list of courses according to a specific teacher
        /// </summary>
        /// <param name="TeacherID">this will be used to identify which teacher to look for</param>
        /// <returns></returns>
        public List<Course> DisplayTeacherCourses(int TeacherID)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            List<Course> courses = new List<Course>();
            SqlCommand command = new SqlCommand("sp_TeacherCourses", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@teacherId", TeacherID));
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int Courseid = reader.GetInt32(0);
                    string CourseName = reader.GetString(1);
                    string CourseDescription = reader.GetString(2);
                    int HoursPerWeek = reader.GetInt32(3);
                    int Cost = reader.GetInt32(4);
                    courses.Add(new Course(Courseid, CourseDescription, HoursPerWeek, Cost, CourseName));


                }

            }
            connection.Close();
            return courses;
        }
        /// <summary>
        /// returns a list of courses according to a teacher and the semester they taught that course
        /// </summary>
        /// <param name="TeacherID">this will be used to identify which teacher to look for</param>
        /// <param name="start">semester start date</param>
        /// <param name="end">semester end date</param>
        /// <returns></returns>
        public List<Course> DisplayTeacherCourseBySemester(int TeacherID, string start, string end)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            List<Course> courses = new List<Course>();
            SqlCommand command = new SqlCommand("sp_TeacherSemesterCourse", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@start", DateTime.Parse(start)));
            command.Parameters.Add(new SqlParameter("@end", DateTime.Parse(end)));
            command.Parameters.Add(new SqlParameter("@teacherId", TeacherID));
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int Courseid = reader.GetInt32(0);
                    string CourseName = reader.GetString(1);
                    string CourseDescription = reader.GetString(2);
                    int HoursPerWeek = reader.GetInt32(3);
                    int Cost = reader.GetInt32(4);
                    courses.Add(new Course(Courseid, CourseDescription, HoursPerWeek, Cost, CourseName));


                }

            }
            connection.Close();
            return courses;

        }
        /// <summary>
        /// returns a list of teachers by the location they taught and their employmentstatus such as part-time or full-time
        /// </summary>
        /// <param name="EmploymentStatus">full-time or part-time</param>
        /// <param name="location">where they taught</param>
        /// <returns></returns>
        public List<Teacher> TeachersByLocationAndEmploymentStatus(string EmploymentStatus,string location)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            List<Teacher> teachers = new List<Teacher>();
            SqlCommand command = new SqlCommand("sp_TeachersByLocationAndEmploymentStatus", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@employmentStatus", EmploymentStatus));
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
                    string password = reader.GetString(11);
                    string basedLocation = reader.GetString(12);
                    teachers.Add(new Teacher(id, firstn, lastn, dob, streetAd, suburb, state, postcode, mobile, gender, email, password, basedLocation));
                }

            }
            connection.Close();
            return teachers;
        }
        /// <summary>
        /// returns a list of teachers acording to employment status such as full-time or part-time and the semester they taught
        /// </summary>
        /// <param name="EmploymentStatus"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<Teacher> TeachersBySemesterAndEmploymentStatus(string EmploymentStatus,string start,string end)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            List<Teacher> teachers = new List<Teacher>();
            SqlCommand command = new SqlCommand("sp_TeachersBySemesterAndEmploymentStatus", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@employmentStatus", EmploymentStatus));
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
                    string password = reader.GetString(11);
                    string basedLocation = reader.GetString(12);
                    teachers.Add(new Teacher(id, firstn, lastn, dob, streetAd, suburb, state, postcode, mobile, gender, email, password, basedLocation));
                }

            }
            connection.Close();
            return teachers;
        }
        /// <summary>
        /// returns a list of teachers according to the location they taught and the semester they taught
        /// </summary>
        /// <param name="Location">College</param>
        /// <param name="start">semester start date</param>
        /// <param name="end">semester end date</param>
        /// <returns></returns>
        public List<Teacher> TeachersBySemesterAndLocation(string Location, string start, string end)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            List<Teacher> teachers = new List<Teacher>();
            SqlCommand command = new SqlCommand("sp_TeachersBySemesterAndLocation", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@location", Location));
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
                    string password = reader.GetString(11);
                    string basedLocation = reader.GetString(12);
                    teachers.Add(new Teacher(id, firstn, lastn, dob, streetAd, suburb, state, postcode, mobile, gender, email, password, basedLocation));
                }

            }
            connection.Close();
            return teachers;
        }
        /// <summary>
        /// returns a list of teacher according to a specified location, semester and employmentstatus
        /// </summary>
        /// <param name="EmploymentStatus"></param>
        /// <param name="Location"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<Teacher> TeachersBySemesterAndLocationAndEmploymentStatus(string EmploymentStatus, string Location, string start, string end)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            List<Teacher> teachers = new List<Teacher>();
            SqlCommand command = new SqlCommand("sp_TeachersBySemesterAndLocationAndEmploymentStatus", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@location", Location));
            command.Parameters.Add(new SqlParameter("@employmentStatus", EmploymentStatus));
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
                    string password = reader.GetString(11);
                    string basedLocation = reader.GetString(12);
                    teachers.Add(new Teacher(id, firstn, lastn, dob, streetAd, suburb, state, postcode, mobile, gender, email, password, basedLocation));
                }

            }
            connection.Close();
            return teachers;
        }




        public List<Teacher> TeachersByNotInBasedLocation(string date)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            List<Teacher> teachers = new List<Teacher>();
            SqlCommand command = new SqlCommand("sp_TeachersByNotInBasedLocation", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@date", DateTime.Parse(date)));
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
                    string password = reader.GetString(11);
                    string basedLocation = reader.GetString(12);
                    teachers.Add(new Teacher(id, firstn, lastn, dob, streetAd, suburb, state, postcode, mobile, gender, email, password, basedLocation));
                }

            }
            connection.Close();
            return teachers;
        }
        /// <summary>
        /// inserts a new teacher into the database with the following parameters
        /// </summary>
        /// <param name="fName">first name</param>
        /// <param name="lName">last name</param>
        /// <param name="DOB">date of birth</param>
        /// <param name="Address">street address</param>
        /// <param name="Suburb">suburb of address</param>
        /// <param name="State">state of addresss</param>
        /// <param name="PostCode">postcode of address</param>
        /// <param name="Mobile">teacher mobile</param>
        /// <param name="Gender">teacher gender</param>
        /// <param name="Email">teacher email</param>
        /// <param name="Password">teacher password</param>
        /// <param name="basedLocation">teachers based location</param>
        /// <returns></returns>
        public int insertTeacher(string fName, string lName, DateTime DOB, string Address, string Suburb, string State, string PostCode, string Mobile, string Gender, string Email, string Password, string basedLocation)
        {
            if (fName == "" || fName.Equals(null) || lName == "" || lName.Equals(null) || DOB == null || Address == "" || Address.Equals(null) || Suburb == "" || Suburb.Equals(null)
                || State == "" || State.Equals(null) || PostCode == "" || PostCode.Equals(null) || Mobile == "" || Mobile.Equals(null) || Gender == "" || Gender.Equals(null)
                || Email == "" || Email.Equals(null) || Password == "" || Password.Equals(null) || string.IsNullOrEmpty(basedLocation)
                )
            {
                return 0;
            }
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            SqlCommand command = new SqlCommand("sp_InsertTeacher", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

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
            command.Parameters.Add(new SqlParameter("@password", Password));
            command.Parameters.Add(new SqlParameter("@basedLocation", basedLocation));
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;

        }
        /// <summary>
        /// updates the teacher with the given teacher ID 
        /// and if it is left blank it will not be updated
        /// </summary>
        /// <param name="id">Teacher ID</param>
        /// <param name="lName">last name</param>
        /// <param name="DOB">date of birth</param>
        /// <param name="Address">street address</param>
        /// <param name="Suburb">suburb of address</param>
        /// <param name="State">state of addresss</param>
        /// <param name="PostCode">postcode of address</param>
        /// <param name="Mobile">teacher mobile</param>
        /// <param name="Gender">teacher gender</param>
        /// <param name="Email">teacher email</param>
        /// <param name="Password">teacher password</param>
        /// <param name="basedLocation">teachers based location</param>
        /// <returns></returns>
        public int updateTeacher(int id,string fName, string lName, DateTime DOB, string Address, string Suburb, string State, string PostCode, string Mobile, string Gender, string Email, string Password, string basedLocation)
        {

            if (
                string.IsNullOrEmpty(fName) && string.IsNullOrEmpty(lName)  && DOB == DateTime.Parse("9999-11-11") && string.IsNullOrEmpty(Address)  && string.IsNullOrEmpty(Suburb)
                && string.IsNullOrEmpty(State) && string.IsNullOrEmpty(PostCode)  && string.IsNullOrEmpty(Mobile) && string.IsNullOrEmpty(Gender)
                && string.IsNullOrEmpty(Email)  && string.IsNullOrEmpty(Password) && string.IsNullOrEmpty(basedLocation)
                )
            {
                return 4;
            }
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            SqlCommand command = new SqlCommand("sp_UpdateTeacher", connection);
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
            command.Parameters.Add(new SqlParameter("@password", Password));
            command.Parameters.Add(new SqlParameter("@basedLocation", basedLocation));
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;

        }
        /// <summary>
        /// Deletes the teacher with the specified parameter teacherID
        /// </summary>
        /// <param name="TeacherId">ID of the teacher that will be deleted</param>
        /// <returns></returns>
        public int deleteTeacher(int TeacherId)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            SqlCommand command = new SqlCommand("sp_DeleteTeacher", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@teacherId", TeacherId));
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;
        }
    }
}
