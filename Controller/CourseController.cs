using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Domain;
namespace Controller
{
    /// <summary>
    /// This Class is the business of the application related to the Courses, Clusters and Units.
    /// This class uses the data access layer to interact with the database,
    /// and is used by the Presentation layer to create,delete and display the objects obtained
    /// by the data access layer
    /// </summary>
    public class CourseController
    {
        public void ResetDb()
        {
            var repo = new CourseRepo();
            //Resests the database
            repo.ResetDatabase();
        }
        public IEnumerable<Course> GetCourses()
        {

            var repo = new CourseRepo();
            //calling to return list of Courses
            var courses = repo.DisplayAllCourses();
            //return the Courses

            return courses;

        }
        public IEnumerable<Course> GetCoursesNotInAnySemester()
        {

            var repo = new CourseRepo();
            //calling to return list of Courses
            var courses = repo.DisplayAllCoursesNotInSemester();
            //return the Courses

            return courses;

        }
        public IEnumerable<Unit> GetUnits()
        {

            var repo = new CourseRepo();
            //calling to return list of Units
            var units = repo.DisplayAllUnits();
            //return the Units

            return units;
        }
        public IEnumerable<Unit> GetUnitsNotInCourseOrSemester()
        {

            var repo = new CourseRepo();
            //calling to return list of Units
            var units = repo.DisplayAllUnitsNotInCourseOrSemester();
            //return the Units

            return units;
        }
        public IEnumerable<Cluster> GetClusters()
        {

            var repo = new CourseRepo();
            //calling to return list of Clusters
            var clusters = repo.DisplayAllClusters();
            //return the Clusters

            return clusters;
        }
        public IEnumerable<Cluster> GetClustersBySemester(string start,string end)
        {

            var repo = new CourseRepo();
            //calling to return list of Clusters by semester
            var clusters = repo.DisplayAllClustersBySemester(start,end);
            //return the Clusters

            return clusters;
        }
       
        
        public int AddCluster(string clusterName, string clusterDesc, int unit1Id, int unit2Id, int unit3Id)
        {
            var repo = new CourseRepo();
            //calling repo to add to Cluster database table 
            int result = repo.insertCluster(clusterName, clusterDesc, unit1Id,unit2Id,unit3Id);
            //return 1 if it executed correctly else 0 or -1

            return result;
        }

        public int AddCourse(string courseName, string courseDesc, int hoursPerWeek, int cost, int cluster1Id, int cluster2Id, int cluster3Id)
        {
            var repo = new CourseRepo();
            //calling repo to add to Course database table 
            int result = repo.insertCourse(courseName, courseDesc, hoursPerWeek, cost, cluster1Id, cluster2Id, cluster3Id);
            //return 1 if it executed correctly else 0 or -1

            return result;
        }

        public int AddUnit(string unitCode, string unitDesc, string unitType)
        {
            var repo = new CourseRepo();
            //calling repo to add to Unit database table 
            int result = repo.insertUnit(unitCode,unitDesc,unitType);
            //return 1 if it executed correctly else 0 or -1

            return result;
        }

       

        public int DeleteUnit(int id)
        {
            var repo = new CourseRepo();
            //calling repo to delete unit database instance with the provided id 
            int result = repo.deleteUnit(id);
            //return 1 if it executed correctly else 0 or -1

            return result;
        }
        
        
        public int DeleteCluster(int id)
        {
            var repo = new CourseRepo();
            //calling repo to delete cluster database instance with the provided id 
            int result = repo.deleteCluster(id);
            //return 1 if it executed correctly else 0 or -1

            return result;
        }
        public int DeleteCourse(int id)
        {
            var repo = new CourseRepo();
            //calling repo to delete course database instance with the provided id 
            int result = repo.deleteCourse(id);
            //return 1 if it executed correctly else 0 or -1

            return result;
        }
    }
}
