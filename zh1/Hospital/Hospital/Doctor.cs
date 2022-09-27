using System;
using System.Collections.Generic;

namespace Hospital
{
    class Doctor : Person, IDoctor
    {
        private List<string> Specialities { get; set; }
        public Doctor(PersonType personType, Gender gender, string firstName, string lastName, DateTime birthDate, string phone, List<string> specialities) 
            :base(personType, gender, firstName, lastName, birthDate, phone)
        {
            Specialities = specialities;
        }
        public void diagnosePatient()
        {
            Console.WriteLine("Diagnose Patient");
        }
        public override string ToString()
        {
            string specialities = "";
            foreach (var item in Specialities)
            {
                specialities += $"{item},";
            }
            return string.Format($"{FirstName} {LastName};{calculateAge()};{BirthDate};{Phone};{specialities.Substring(0, specialities.Length - 1)}");
        }
        public override int calculateAge()
        {
            DateTime now = DateTime.Today;
            return (now.Year - BirthDate.Year);
        }
    }
}
