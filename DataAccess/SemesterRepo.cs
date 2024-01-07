using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Domain;
namespace DataAccess
{
    /// <summary>
    /// This Class is the Data Access layer of the application related to the semesters in the database 
    /// </summary>
    public class SemesterRepo
    {
        /// <summary>
        /// connection to database
        /// </summary>
        private string connectionString = @"Data Source=DESKTOP-GVF1QR7\SQLEXPRESS;Initial Catalog=TafeSystem;Integrated Security=True";
        /// <summary>
        /// Deletes the semester in the database with the specified semester ID
        /// </summary>
        /// <param name="semesterId">the semester ID that will be deleted</param>
        /// <returns></returns>
        public int deleteSemester(int semesterId)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            SqlCommand command = new SqlCommand("sp_DeleteSemester", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@semesterId", semesterId));
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;
        }
        /// <summary>
        /// inserts semester into the database
        /// </summary>
        /// <param name="start">start of inserted semester</param>
        /// <param name="end">end of inserted semester</param>
        /// <returns></returns>
        public int insertSemester(DateTime start, DateTime end)
        {

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            SqlCommand command = new SqlCommand("sp_InsertSemester", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@start", start));
            command.Parameters.Add(new SqlParameter("@end", end));
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;
        }
        /// <summary>
        /// list of all the semesters in the database
        /// </summary>
        /// <returns></returns>
        public List<Semester> DisplayAllSemesters()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            List<Semester> semesters = new List<Semester>();
            SqlCommand command = new SqlCommand("sp_SelectAllSemesters", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int Semesterid = reader.GetInt32(0);
                    DateTime start = reader.GetDateTime(1);
                    DateTime end = reader.GetDateTime(2);
                    int DurationDays = reader.GetInt32(03);
                    semesters.Add(new Semester(Semesterid, start, end, DurationDays));
                }

            }
            connection.Close();
            return semesters;

        }


    }
}
