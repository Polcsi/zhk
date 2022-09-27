using System;

namespace Books
{
    public class Author
    {
        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Author(string firstname, string lastname, DateTime birthDate)
        {
            FirstName = firstname;
            LastName = lastname;
            BirthDate = birthDate;
        }
    }
}
