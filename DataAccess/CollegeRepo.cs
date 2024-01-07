using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Domain;
namespace DataAccess
{
    /// <summary>
    /// This Class is the Data Access layer of the application related to the colleges in the database 
    /// </summary>
    public class CollegeRepo
    {
        /// <summary>
        /// connection to database
        /// </summary>
        private string connectionString = @"Data Source=DESKTOP-GVF1QR7\SQLEXPRESS;Initial Catalog=TafeSystem;Integrated Security=True";
        /// <summary>
        /// returns a list of all the colleges in the database
        /// </summary>
        /// <returns>colleges in the database</returns>
        public List<College> DisplayAllColleges()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            List<College> colleges = new List<College>();
            SqlCommand command = new SqlCommand("sp_SelectAllColleges", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

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
        /// inserts college into the databse
        /// </summary>
        /// <param name="Name">college name</param>
        /// <param name="Location">college location</param>
        /// <returns></returns>
        public int insertCollege(string Name, string Location)
        {
            if (Name == "" || Name.Equals(null) || Location == "" || Location.Equals(null))
            {
                return 0;
            }
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            SqlCommand command = new SqlCommand("sp_InsertCollege", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@name", Name));
            command.Parameters.Add(new SqlParameter("@location", Location));
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;

        }
        /// <summary>
        /// deletes the college in the database with the provided collegeId
        /// </summary>
        /// <param name="collegeId">ID of the college that will be deleted</param>
        /// <returns></returns>
        public int deleteCollege(int collegeId)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            SqlCommand command = new SqlCommand("sp_DeleteCollege", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@collegeId", collegeId));
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;
        }

    }
}
