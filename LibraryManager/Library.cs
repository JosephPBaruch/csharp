public class Library
{
    private List<Book> _books = new List<Book>();

    public void AddBook(Book book)
    {
        _books.Add(book);
    }

    public void DisplayBooks()
    {
        if (_books.Count == 0)
        {
            Console.WriteLine("No books in the library.");
            return;
        }

        foreach (Book book in _books)
        {
            book.DisplayInfo();
        }
    }

    public Book? FindBookByTitle(string title)
    {
        return _books.FirstOrDefault(book =>
            book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }
}