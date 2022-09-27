using System;
using System.Collections.Generic;

namespace HospitalApp
{
    class Doctor : Person, IDoctor
    {
        public List<string> Specialities { get; set; }
        public Doctor(PersonType personType, Gender gender, string firstName, string lastName, DateTime birthDate, string phone, List<string> specialities)
            :base(personType, gender, firstName, lastName, birthDate, phone)
        {
            Specialities = specialities;
        }
        public override int calculateAge()
        {
            return BirthDate.Year - DateTime.Today.Year;
        }
        public override string ToString()
        {
            string specialities = "";
            foreach (var item in Specialities)
            {
                specialities += $"{item},";
            }
            return string.Format($"{FirstName} {LastName};({BirthDate});{Gender};{Phone};{specialities.Substring(0, specialities.Length-1)}");
        }
        public void diagnosePatient()
        {
            Console.WriteLine("Diagnose Patient...");
        }
    }
}
