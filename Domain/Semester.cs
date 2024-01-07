using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Semester
    {
        private int SemesterId;
        private DateTime StartDate;
        private DateTime EndDate;
        private int DurationDays;

        public Semester(int semesterId1, DateTime startDate1, DateTime endDate1, int durationDays1)
        {
            SemesterId1 = semesterId1;
            StartDate1 = startDate1;
            EndDate1 = endDate1;
            DurationDays1 = durationDays1;
        }

        public int SemesterId1 { get => SemesterId; set => SemesterId = value; }
        public DateTime StartDate1 { get => StartDate; set => StartDate = value; }
        public DateTime EndDate1 { get => EndDate; set => EndDate = value; }
        public int DurationDays1 { get => DurationDays; set => DurationDays = value; }
    }
}
