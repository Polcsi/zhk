using System;

namespace BookStore.cs
{
    public class Author
    {
        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Author(string firstName, string lastName, DateTime birthDate)        {
            BirthDate = birthDate;
            FirstName = firstName;
            LastName = lastName;
        }

    }
}
