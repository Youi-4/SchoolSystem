using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class College
    {
        private int CollegeId;
        private string Name;
        private string CollegeLocation;

        public College(int collegeId1, string name1, string collegeLocation1)
        {
            CollegeId1 = collegeId1;
            Name1 = name1;
            CollegeLocation1 = collegeLocation1;
        }

        public int CollegeId1 { get => CollegeId; set => CollegeId = value; }
        public string Name1 { get => Name; set => Name = value; }
        public string CollegeLocation1 { get => CollegeLocation; set => CollegeLocation = value; }
    }
}
