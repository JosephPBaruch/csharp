public class Library
{
    private List<Book> _books = new List<Book>();
    private List<Magazine> _magazines = new List<Magazine>();

    public void AddBook(Book book)
    {
        foreach (Book existingBook in _books){
            if(existingBook.Title == book.Title){
                Console.Write("Cannot add duplicate books");
                return;
            }
        }
        _books.Add(book);
    }

    public void AddMagazine(Magazine magazine)
    {
        foreach (Book existingMags in _magazines){
            if(existingMags.Title == magazine.Title){
                Console.Write("Cannot add duplicate magazines");
                return;
            }
        }
        _magazines.Add(magazine);
    }

    public void DeleteBook(Book book){
        _books.Remove(book);
        Console.WriteLine($"{book.Title} has been deleted.");
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

    public void DisplayMagazines()
    {
        if (_magazines.Count == 0)
        {
            Console.WriteLine("No magazines in the library.");
            return;
        }

        foreach (Book mag in _magazines)
        {
            mag.DisplayInfo();
        }
    }

    public Book? FindBookByTitle(string title)
    {
        return _books.FirstOrDefault(book =>
            book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }

    public Magazine? FindMagazineByTitle(string title)
    {
        return _magazines.FirstOrDefault(magazine =>
            magazine.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }
}