using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Books
{
    internal class Program
    {
        private List<Book> books = new List<Book>()
        {
            new Book("bk101", "XML Developer's Guide", "Computer",44.95, new DateTime(2000, 10, 01), new Author("Gambardella", "Matthew", new DateTime(1976, 10, 10)),"An in-depth look at creating applications with XML."),
            new Book("bk102", "Midnight Rain", "Fantasy" ,5.95, new DateTime(1982, 02, 13), new Author("Ralls", "Kim", new DateTime(2000, 12, 16)), " former architect battles corporate zombies, an evil sorceress, and her own childhood to become queen of the world."),
        };
        static void Main(string[] args)
        {
            Program prg = new Program();
            prg.createXml(prg, "books.xml");

            Console.ReadKey();
        }
        private void createXml(Program prg, string filename)
        {
            XElement booksElements = new XElement("Books",
                from books in prg.books
                select new XElement("Book", new XAttribute("Id", books.Id),
                    new XElement("Title", books.Title),
                    new XElement("Author", 
                        new XElement("FirstName", books.Author.FirstName),
                        new XElement("LastName", books.Author.LastName),
                        new XElement("BirthDate", books.Author.BirthDate)),
                    new XElement("Category", books.Category),
                    new XElement("Price", books.Price),
                    new XElement("PublishDate", books.PublishDate),
                    new XElement("Description", books.Description)));

            booksElements.Save(filename);
            Console.WriteLine("File Saved");
        }
    }
}
