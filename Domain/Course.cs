using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Course
    {
        private int CourseId;
        private string Desc;
        private int HoursPerWeek;
        private int Cost;
        private string Name;
        private List<Cluster> clusters = new List<Cluster>();
        public Course(int courseId1, string desc1, int hoursPerWeek1, int cost1, string name1)
        {
            CourseId1 = courseId1;
            Desc1 = desc1;
            HoursPerWeek1 = hoursPerWeek1;
            Cost1 = cost1;
            Name1 = name1;
        }

        public Course()
        {

        }

        public int CourseId1 { get => CourseId; set => CourseId = value; }
        public string Desc1 { get => Desc; set => Desc = value; }
        public int HoursPerWeek1 { get => HoursPerWeek; set => HoursPerWeek = value; }
        public int Cost1 { get => Cost; set => Cost = value; }
        public string Name1 { get => Name; set => Name = value; }
        public List<Cluster> Clusters { get => clusters; set => clusters = value; }
        public void addCluster(Cluster cluster)
        {
            Clusters.Add(cluster);
        }
    }
}
