using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Unit
    {
        private int UnitId;
        private string Code;
        private string Type;
        private string Desc;
        private string Grade;

        public Unit(int unitId1, string code1, string type1, string desc1, string grade1)
        {
            UnitId1 = unitId1;
            Code1 = code1;
            Type1 = type1;
            Desc1 = desc1;
            Grade1 = grade1;
        }

        public int UnitId1 { get => UnitId; set => UnitId = value; }
        public string Code1 { get => Code; set => Code = value; }
        public string Type1 { get => Type; set => Type = value; }
        public string Desc1 { get => Desc; set => Desc = value; }
        public string Grade1 { get => Grade; set => Grade = value; }
    }
}
