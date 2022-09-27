using System;

namespace Hospital
{
    public enum Gender { Male, Female};
    public enum PersonType { Doctor, Patient };
    abstract class Person
    {
        protected DateTime BirthDate { get; set; }
        protected string FirstName { get; set; }
        protected string LastName { get; set; }
        protected string Phone { get; set; }
        protected Gender Gender { get; set; }
        private PersonType PersonType { get; set; }
        protected Person(PersonType personType, Gender gender, string firstName, string lastName, DateTime birthDate, string phone)
        {
            PersonType = personType;
            Gender = gender;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Phone = phone;
        }
        public virtual string ToString()
        {
            return string.Format($"{FirstName};{LastName};{PersonType};{BirthDate};{Phone}");
        }
        public abstract int calculateAge();
    }
}
