using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Domain;
namespace DataAccess
{
    /// <summary>
    /// This Class is the Data Access layer of the application related to the Login confirmation
    /// </summary>
    public class LoginRepo
    {
        /// <summary>
        /// these two parameters will be used as inputs to check if user if an admin
        /// </summary>
        SqlParameter Email, Password;
        /// <summary>
        /// connection to database
        /// </summary>
        private string connectionString = @"Data Source=DESKTOP-GVF1QR7\SQLEXPRESS;Initial Catalog=TafeSystem;Integrated Security=True";
        /// <summary>
        /// This method searchs the database to check whether or not the login details are an admins (teacher)
        /// and approves them if correct and denys them entry if incorrect
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public int LoginVerify(Login login) 
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            Email =new SqlParameter();
            Email.SqlDbType = SqlDbType.NVarChar;
            Email.Size = 50;
            Email.ParameterName = "@email";
            Email.Value = login.Email;
            Email.Direction = ParameterDirection.Input;
            Password = new SqlParameter();
            Password.SqlDbType = SqlDbType.NVarChar;
            Password.Size = 50;
            Password.ParameterName = "@password";
            Password.Value = login.Passsword;
            Password.Direction = ParameterDirection.Input;
            SqlCommand command = new SqlCommand("sp_UserLogin", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(Email);
            command.Parameters.Add(Password);
            int r = Convert.ToInt16(command.ExecuteScalar());
            connection.Close();
            return r;
        }

    }
}
