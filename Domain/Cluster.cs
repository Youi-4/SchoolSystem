using System;
using System.Collections.Generic;
using System.Text;
using Domain;
namespace Domain
{
    public class Cluster
    {
        private int ClusterId;
        private string Name;
        private string Desc;
        private List<Unit> units = new List<Unit>();

        public Cluster(int clusterId1, string name1, string desc1)
        {
            ClusterId1 = clusterId1;
            Name1 = name1;
            Desc1 = desc1;
        }

        public Cluster()
        {
        }
        public int ClusterId1 { get => ClusterId; set => ClusterId = value; }
        public string Name1 { get => Name; set => Name = value; }
        public string Desc1 { get => Desc; set => Desc = value; }
        public List<Unit> Units { get => units; set => units = value; }

        public void AddUnit(Unit unit) {
            Units.Add(unit);
        }
    }
}
