using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Domain;
namespace Controller
{
    /// <summary>
    /// This Class is the business of the application related to Semesters
    /// This class uses the data access layer to interact with the database,
    /// and is used by the Presentation layer to create,delete and display the objects obtained
    /// by the data access layer
    /// </summary>
    public class SemesterController
    {
        public IEnumerable<Semester> GetSemesters()
        {

            var repo = new SemesterRepo();
            //calling to return list of Semesters
            var semesters = repo.DisplayAllSemesters();
            //return the Semesters

            return semesters;
        }
        public int AddSemester(DateTime start, DateTime end)
        {
            var repo = new SemesterRepo();
            //calling repo to add to Semester database table 
            int result = repo.insertSemester(start, end);
            //return 1 if it executed correctly else 0 or -1

            return result;
        }
        public int DeleteSemester(int id)
        {
            var repo = new SemesterRepo();
            //calling repo to delete Semeter database instance with the provided id 
            int result = repo.deleteSemester(id);
            //return 1 if it executed correctly else 0 or -1

            return result;
        }
    }
}
