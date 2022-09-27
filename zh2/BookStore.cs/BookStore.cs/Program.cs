using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace BookStore.cs
{
    public class Program
    {
        private List<Book> books = new List<Book>()
        {
            new Book("bk101", "XML Developer's Guide", "Computer",44.95, new DateTime(2000, 10, 01), new Author("Gambardella", "Matthew", new DateTime(1976, 10, 10)),"An in-depth look at creating applications with XML."),
            new Book("bk102", "Midnight Rain", "Fantasy" ,5.95, new DateTime(2000, 12, 16), new Author("Ralls", "Kim",new DateTime(1982, 02, 13)), "A former architect battles corporate zombies, an evil sorceress, and her own childhood to become queen of the world."),
            new Book("bk103", "Maeve Ascendant","Fantasy",5.95, new DateTime(2000,11,17),new Author("Corets", "Eva", new DateTime(1956, 06, 12)),"After the collapse of a nanotechnology society in England, the young survivors lay the foundation for a new society."),
            new Book("bk104", "Paradox Lost", "Science Fiction",null, new DateTime(2000, 11, 02), new Author("Kress", "Peter", new DateTime(1965, 01, 24)),"After an inadvertant trip through a Heisenberg Uncertainty Device, James Salway discoversthe problems of being quantum."),
            new Book("bk105", "Microsoft .NET: The Programming Bible", "Computer", 36.95, new DateTime(2000, 12, 09), new Author("O'Brien", "Tim",new DateTime(1977, 04, 12)), "Microsoft's .NET initiative is explored in detail in this deep programmer'sreference."),
        };
        private static void Main(string[] args)
        {
            Program prg = new Program();
            prg.createXml("books.xml");

            Console.ReadKey();
        }
        private void createXml(string fileName)
        {
            XElement booksXElements = new XElement("Bookstore",
                from books in books
                select new XElement("Book", new XAttribute("Id", books.Id),
                    new XElement("Title", books.Title),
                    new XElement("Author",
                        new XElement("FirstName", books.Author.FirstName),
                        new XElement("LastName", books.Author.LastName),
                        new XElement("BirthDate", books.Author.BirthDate)),
                    new XElement("Category", books.Category),
                    books.Price != null ? new XElement("Price", books.Price) : null,
                    new XElement("PublishDate", books.PublishDate),
                    new XElement("Description", books.Description)));

            booksXElements.Save(fileName);
            Console.WriteLine("File Saved!");
        }
    }
}
