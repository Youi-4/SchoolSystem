using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Domain;

namespace DataAccess
{
    /// <summary>
    /// This Class is the Data Access layer of the application related to the Courses,Clusters and Units in the database
    /// </summary>
    public class CourseRepo
    {
        /// <summary>
        /// connection to database
        /// </summary>
        private string connectionString = @"Data Source=DESKTOP-GVF1QR7\SQLEXPRESS;Initial Catalog=TafeSystem;Integrated Security=True";

        public void ResetDatabase()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            SqlCommand command = new SqlCommand("sp_ResetDataBase", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            connection.Close();
        }
        /// <summary>
        /// This returns a list of all the clusters in the database
        /// </summary>
        /// <returns></returns>
        public List<Cluster> DisplayAllClusters()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            Cluster c = null;
            List<Cluster> clusters = new List<Cluster>();
            SqlCommand command = new SqlCommand("sp_SelectAllClusters", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int Clusterid = reader.GetInt32(0);
                    if ( c == null || c.ClusterId1 != Clusterid)
                    {
                        string ClusterName = reader.GetString(1);
                        string ClusterDesc = reader.GetString(2);
                        c = new Cluster(Clusterid, ClusterName, ClusterDesc);
                        clusters.Add(c);
                    }
                    if (!reader.IsDBNull(3))
                    {
                        int Unitid = reader.GetInt32(3);
                        string UnitCode = reader.GetString(4);
                        string UnitType = reader.GetString(5);
                        string UnitDesc = reader.GetString(6);
                        string UnitGrade = reader.GetString(7);
                        c.AddUnit(new Unit(Unitid, UnitCode, UnitType, UnitDesc, UnitGrade));
                    }


                }

            }
            connection.Close();
            return clusters;

        }
        /// <summary>
        /// This returns a list of clusters according to a specific a semester that those cluster were taught by the teachers
        /// </summary>
        /// <param name="start">semester start date</param>
        /// <param name="end">semester end date</param>
        /// <returns></returns>
        public List<Cluster> DisplayAllClustersBySemester(string start, string end)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            Cluster c = null;
            List<Cluster> clusters = new List<Cluster>();
            SqlCommand command = new SqlCommand("sp_SelectAllClustersBySemester", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@startDate", DateTime.Parse(start)));
            command.Parameters.Add(new SqlParameter("@endDate", DateTime.Parse(end)));
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int Clusterid = reader.GetInt32(0);
                    if (c == null || c.ClusterId1 != Clusterid)
                    {
                        string ClusterName = reader.GetString(1);
                        string ClusterDesc = reader.GetString(2);
                        c = new Cluster(Clusterid, ClusterName, ClusterDesc);
                        clusters.Add(c);
                    }
                    if (!reader.IsDBNull(3))
                    {
                        int Unitid = reader.GetInt32(3);
                        string UnitCode = reader.GetString(4);
                        string UnitType = reader.GetString(5);
                        string UnitDesc = reader.GetString(6);
                        string UnitGrade = reader.GetString(7);
                        c.AddUnit(new Unit(Unitid, UnitCode, UnitType, UnitDesc, UnitGrade));
                    }


                }

            }
            connection.Close();
            return clusters;

        }
        /// <summary>
        /// this deletes the a cluster with the provided cluster ID
        /// </summary>
        /// <param name="clusterId">this is the clusterID of the cluster that will be deleted</param>
        /// <returns></returns>
        public int deleteCluster(int clusterId)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            SqlCommand command = new SqlCommand("sp_DeleteCluster", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@clusterId", clusterId));
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;
        }

        public int deleteCourse(int clusterId)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            SqlCommand command = new SqlCommand("sp_DeleteCourse", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@courseId", clusterId));
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;
        }
        /// <summary>
        /// This inserts a cluster into the database with following parameters
        /// </summary>
        /// <param name="clusterName">inserted cluster name</param>
        /// <param name="clusterDesc">inserted cluster description</param>
        /// <param name="unit1Id">a unit apart of the cluster</param>
        /// <param name="unit2Id">a unit apart of the cluster</param>
        /// <param name="unit3Id">a unit apart of the cluster</param>
        /// <returns></returns>
        public int insertCluster(string clusterName,string clusterDesc, int unit1Id, int unit2Id, int unit3Id)
        {

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            SqlCommand command = new SqlCommand("sp_InsertCluster", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@clusterName", clusterName));
            command.Parameters.Add(new SqlParameter("@clusterDesc", clusterDesc));
            command.Parameters.Add(new SqlParameter("@unit1Id", unit1Id));
            command.Parameters.Add(new SqlParameter("@unit2Id", unit2Id));
            command.Parameters.Add(new SqlParameter("@unit3Id", unit3Id));
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;

        }

        /// <summary>
        /// This method inserts in course into the database with the following parameters
        /// </summary>
        /// <param name="courseName">Course name</param>
        /// <param name="courseDesc">Course description</param>
        /// <param name="hoursPerWeek">Course hours per a week for studying</param>
        /// <param name="cost">Course cost</param>
        /// <param name="cluster1Id">Cluster one allocated to the course</param>
        /// <param name="cluster2Id">Cluster two  allocated to the course</param>
        /// <param name="cluster3Id">Cluster three allocated to the course</param>
        /// <returns></returns>
        public int insertCourse(string courseName, string courseDesc, int hoursPerWeek,int cost, int cluster1Id, int cluster2Id,int cluster3Id)
        {

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            SqlCommand command = new SqlCommand("sp_InsertCourse", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@courseName", courseName));
            command.Parameters.Add(new SqlParameter("@courseDesc", courseDesc));
            command.Parameters.Add(new SqlParameter("@hoursPerWeek", hoursPerWeek));
            command.Parameters.Add(new SqlParameter("@cost", cost));
            command.Parameters.Add(new SqlParameter("@cluster1Id", cluster1Id));
            command.Parameters.Add(new SqlParameter("@cluster2Id", cluster2Id));
            command.Parameters.Add(new SqlParameter("@cluster3Id", cluster3Id));
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;

        }


        /// <summary>
        /// returns a list of all the courses in the database
        /// </summary>
        /// <returns></returns>
        public List<Course> DisplayAllCourses()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            List<Course> courses = new List<Course>();
            Course course = null;
            Cluster cluster = null;
            SqlCommand command = new SqlCommand("sp_SelectAllCourses", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            int courseChange = 0;
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    
                    int Courseid = reader.GetInt32(0);
                    if (course == null || course.CourseId1 != Courseid)
                    {
                        string CourseDesc = reader.GetString(1);
                        int hoursPerW = reader.GetInt32(2);
                        int Course_cost = reader.GetInt32(3);
                        string Course_Name = reader.GetString(4); 
                        course = new Course(Courseid,CourseDesc,hoursPerW,Course_cost,Course_Name);
                        
                        courses.Add(course);
                    }
                    int Clusterid = reader.GetInt32(5);
                    if (cluster == null || cluster.ClusterId1 != Clusterid || (cluster.ClusterId1 == Clusterid && courseChange != Courseid))
                    {
                        string ClusterName = reader.GetString(6);
                        string ClusterDesc = reader.GetString(7);
                        cluster = new Cluster(Clusterid, ClusterName, ClusterDesc);
                        course.addCluster(cluster);
                    }
                    if (!reader.IsDBNull(8))
                    {
                        int Unitid = reader.GetInt32(8);
                        string UnitCode = reader.GetString(9);
                        string UnitType = reader.GetString(10);
                        string UnitDesc = reader.GetString(11);
                        string UnitGrade = reader.GetString(12);
                        cluster.AddUnit(new Unit(Unitid,UnitCode,UnitType,UnitDesc,UnitGrade));
                    }
                    courseChange = course.CourseId1;
                }

            }
            connection.Close();
            return courses;
        }
        /// <summary>
        /// this returns a list of courses which are not taught by any teacher in any semester
        /// </summary>
        /// <returns></returns>
        public List<Course> DisplayAllCoursesNotInSemester()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            List<Course> courses = new List<Course>();
            Course course = null;
            Cluster cluster = null;
            int courseChange = 0;
            SqlCommand command = new SqlCommand("sp_SelectAllCoursesNotInSemester", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {


                    int Courseid = reader.GetInt32(0);
                    if (course == null || course.CourseId1 != Courseid)
                    {
                        string CourseDesc = reader.GetString(1);
                        int hoursPerW = reader.GetInt32(2);
                        int Course_cost = reader.GetInt32(3);
                        string Course_Name = reader.GetString(4);
                        course = new Course(Courseid, CourseDesc, hoursPerW, Course_cost, Course_Name);

                        courses.Add(course);
                    }
                    int Clusterid = reader.GetInt32(5);
                    if (cluster == null || cluster.ClusterId1 != Clusterid || (cluster.ClusterId1 == Clusterid && courseChange != Courseid))
                    {
                        string ClusterName = reader.GetString(6);
                        string ClusterDesc = reader.GetString(7);
                        cluster = new Cluster(Clusterid, ClusterName, ClusterDesc);
                        course.addCluster(cluster);
                    }
                    if (!reader.IsDBNull(8))
                    {
                        int Unitid = reader.GetInt32(8);
                        string UnitCode = reader.GetString(9);
                        string UnitType = reader.GetString(10);
                        string UnitDesc = reader.GetString(11);
                        string UnitGrade = reader.GetString(12);
                        cluster.AddUnit(new Unit(Unitid, UnitCode, UnitType, UnitDesc, UnitGrade));
                    }
                    courseChange = course.CourseId1;

                }

            }
            connection.Close();
            return courses;
        }
        /// <summary>
        /// This returns a list of all the units in the database
        /// </summary>
        /// <returns></returns>
        public List<Unit> DisplayAllUnits()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            List<Unit> units = new List<Unit>();
            SqlCommand command = new SqlCommand("sp_SelectAllUnits", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int Unitid = reader.GetInt32(0);
                    string UnitCode = reader.GetString(1);
                    string UnitType = reader.GetString(2);
                    string UnitDesc = reader.GetString(3);
                    string UnitGrade = reader.GetString(4);
                    units.Add(new Unit(Unitid, UnitCode, UnitType, UnitDesc, UnitGrade));

                }

            }
            connection.Close();
            return units;

        }
        /// <summary>
        /// This returns a list of units which are not allocated in any course and semester
        /// </summary>
        /// <returns></returns>
        public List<Unit> DisplayAllUnitsNotInCourseOrSemester()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            List<Unit> units = new List<Unit>();
            SqlCommand command = new SqlCommand("sp_SelectAllUnitsNotInCourseOrSemester", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int Unitid = reader.GetInt32(0);
                    string UnitCode = reader.GetString(1);
                    string UnitType = reader.GetString(2);
                    string UnitDesc = reader.GetString(3);
                    string UnitGrade = reader.GetString(4);
                    units.Add(new Unit(Unitid, UnitCode, UnitType, UnitDesc, UnitGrade));

                }

            }
            connection.Close();
            return units;

        }
        /// <summary>
        /// This deletes a specific unit with the provided unit id parameter
        /// </summary>
        /// <param name="unitId">ID of the unit which will be deleted</param>
        /// <returns></returns>
        public int deleteUnit(int unitId)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            SqlCommand command = new SqlCommand("sp_DeleteUnit", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@unitId", unitId));
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;
        }
        /// <summary>
        /// This inserts a new unit into the datebase with the following parameters
        /// </summary>
        /// <param name="unitCode">new inserted Unit Code</param>
        /// <param name="unitDesc">new inserted Unit Description</param>
        /// <param name="unitType">new inserted Unit Type</param>
        /// <returns></returns>
        public int insertUnit(string unitCode, string unitDesc, string unitType)
        {
            if (unitCode == "" || unitCode.Equals(null) || unitDesc == "" || unitDesc.Equals(null) || unitType == "" || unitType.Equals(null))
            {
                return 0;
            }
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            SqlCommand command = new SqlCommand("sp_InsertUnit", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@unitcode", unitCode));
            command.Parameters.Add(new SqlParameter("@unitdesc", unitDesc));
            command.Parameters.Add(new SqlParameter("@unittype", unitType));
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;

        }
    }
}
