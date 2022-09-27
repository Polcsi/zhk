using System;

namespace Hospital
{
    class Patient : Person
    {
        public string Sickness { get; set; }
        public Patient(PersonType personType, Gender gender, string firstName, string lastName, DateTime birthDate, string phone, string sickness)
            :base(personType, gender, firstName, lastName, birthDate, phone)
        {
            Sickness = sickness;
        }
        public override string ToString()
        {
            return string.Format($"{FirstName} {LastName};{calculateAge()};{BirthDate};{Phone};{Sickness}");
        }
        public override int calculateAge()
        {
            int YearsPassed = DateTime.Now.Year - BirthDate.Year;
            if (DateTime.Now.Month < BirthDate.Month || (DateTime.Now.Month == BirthDate.Month && DateTime.Now.Day < BirthDate.Day))
            {
                YearsPassed--;
            }
            return YearsPassed;
        }
    }
}
