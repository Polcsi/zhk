using System;

namespace HospitalApp
{
    class Patient : Person
    {
        public string Sickness { get; set; }
        public Patient(PersonType personType, Gender gender, string firstName, string lastName, DateTime birthDate, string phone, string sickness)
            : base(personType, gender, firstName, lastName, birthDate, phone)
        {
            Sickness = sickness;
        }
        public override int calculateAge()
        {
            return DateTime.Today.Year - BirthDate.Year; ;
        }
        public override string ToString()
        {
            return string.Format($"{FirstName} {LastName};({BirthDate});{calculateAge()};{Gender};{Phone};{Sickness}");
        }
    }
}
