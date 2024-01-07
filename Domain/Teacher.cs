using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Teacher
    {
        private int TeacherId;
        private string FirstName;
        private string LastName;
        private DateTime DOB;
        private string StreetAddress;
        private string Suburb;
        private string State;
        private string PostCode;
        private string Mobile;
        private string Gender;
        private string Email;
        private string Password;
        private string BasedLocation;
        public Teacher()
        {

        }
        public Teacher(int teacherId,string firstName1, string lastName1, DateTime dOB1, string streetAddress1, string suburb1, string state1, string postCode1, string mobile1, string gender1, string email1, string password1, string basedLocation)
        {
            FirstName1 = firstName1;
            LastName1 = lastName1;
            DOB1 = dOB1;
            StreetAddress1 = streetAddress1;
            Suburb1 = suburb1;
            State1 = state1;
            PostCode1 = postCode1;
            Mobile1 = mobile1;
            Gender1 = gender1;
            Email1 = email1;
            Password1 = password1;
            TeacherId1 = teacherId;
            BasedLocation1 = basedLocation;
        }

        public string FirstName1 { get => FirstName; set => FirstName = value; }
        public string LastName1 { get => LastName; set => LastName = value; }
        public DateTime DOB1 { get => DOB; set => DOB = value; }
        public string StreetAddress1 { get => StreetAddress; set => StreetAddress = value; }
        public string Suburb1 { get => Suburb; set => Suburb = value; }
        public string State1 { get => State; set => State = value; }
        public string PostCode1 { get => PostCode; set => PostCode = value; }
        public string Mobile1 { get => Mobile; set => Mobile = value; }
        public string Gender1 { get => Gender; set => Gender = value; }
        public string Email1 { get => Email; set => Email = value; }
        public string Password1 { get => Password; set => Password = value; }
        public int TeacherId1 { get => TeacherId; set => TeacherId = value; }
        public string BasedLocation1 { get => BasedLocation; set => BasedLocation = value; }
    }
}
