using System;

namespace BookStore.cs
{
    public class Book
    {
        public Author Author { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public double? Price { get; set; }
        public DateTime PublishDate { get; set; }
        public string Title { get; set; }
        public Book(string id, string title, string category, double? price, DateTime publishDate, Author author, string description)
        {
            Author = author;
            Category = category;
            Description = description;
            Id = id;
            Price = price;
            PublishDate = publishDate;
            Title = title;
        }
    }
}
