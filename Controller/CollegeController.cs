using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using DataAccess;
namespace Controller
{
    /// <summary>
    /// This Class is the business of the application related to Colleges
    /// This class uses the data access layer to interact with the database,
    /// and is used by the Presentation layer to create,delete and display the objects obtained
    /// by the data access layer
    /// </summary>
    public class CollegeController
    {

        public IEnumerable<College> GetColleges()
        {

            var repo = new CollegeRepo();
            //calling to return list of Colleges
            var colleges = repo.DisplayAllColleges();
            //return the Colleges

            return colleges;
        }
        public int AddCollege(string name, string location)
        {
            var repo = new CollegeRepo();
            //calling repo to add to College database table
            int result = repo.insertCollege(name, location);
            //return 1 if it executed correctly else 0 or -1

            return result;
        }
        public int DeleteCollege(int id)
        {
            var repo = new CollegeRepo();
            //calling repo to delete college database instance with the provided id 
            int result = repo.deleteCollege(id);
            //return 1 if it executed correctly else 0 or -1

            return result;
        }

    }
}
