using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        BookReadingList readingList = new BookReadingList();
        BookList book1 = new BookList("Book1", "Title1", "Description1", "Author1", "Genre1", 2023);
        BookList book2 = new BookList("Book2", "Title2", "Description2", "Author2", "Genre2", 2021);
        BookList book3 = new BookList("Book3", "Title3", "Description3", "Author3", "Genre3", 2022);
        BookList book4 = new BookList("Book4", "Title4", "Description4", "Author4", "Genre4", 2024);

        readingList += book1;
        readingList += book2;
        readingList += book3;
        readingList += book4;

        readingList.ShowReadingList();

        if (readingList.ContainsBookInReadingList(book2))
        {
            System.Console.WriteLine("Book2 is in the reading list.");
            System.Console.WriteLine();
        }

        readingList -= book1;

        readingList.ShowReadingList();
    }
}

class BookList
{
    private string name;
    private string title;
    private string description;
    private string author;
    private string genre;
    private int yearOfPublication;

    public BookList(string name, string title, string description, string author, string genre, int yearOfPublication)
    {
        this.name = name;
        this.title = title;
        this.author = author;
        this.description = description;
        this.genre = genre;
        this.yearOfPublication = yearOfPublication;
    }
    public BookList()
    {
        this.name = "no name";
        this.title = "no title";
        this.author = "no author";
        this.description = "no description";
        this.genre = "no genre";
        this.yearOfPublication = 0;
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string Title
    {
        get { return title; }
        set { title = value; }
    }
    public string Author
    {
        get { return author; }
        set { author = value; }
    }
    public string Description
    {
        get { return description; }
        set { description = value; }
    }
    public string Genre
    {
        get { return genre; }
        set { genre = value; }
    }
    public int YearOfPublication
    {
        get { return yearOfPublication; }
        set { yearOfPublication = value; }
    }
}

class BookReadingList
{
    private List<BookList> readingList = new List<BookList>();

    public void AddBookToReadingList(BookList book)
    {
        readingList.Add(book);
    }
    public void RemoveBookFromReadingList(BookList book)
    {
        readingList.Remove(book);
    }
    public bool ContainsBookInReadingList(BookList book)
    {
        return readingList.Contains(book);
    }

    public void ShowReadingList()
    {
        System.Console.WriteLine("Books in the reading list:");
        System.Console.WriteLine();
        foreach (var book in readingList)
        {
            System.Console.WriteLine($"Title: {book.Title}, Author: {book.Author}");
        }
        System.Console.WriteLine();
    }

    public static BookReadingList operator +(BookReadingList readingList, BookList book)
    {
        readingList.AddBookToReadingList(book);
        return readingList;
    }

    public static BookReadingList operator -(BookReadingList readingList, BookList book)
    {
        readingList.RemoveBookFromReadingList(book);
        return readingList;
    }
}