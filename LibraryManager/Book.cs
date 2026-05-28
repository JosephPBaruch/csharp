public class Book : LibraryItem, ICheckoutable
{
    public string Author { get; set; }
    public bool IsCheckedOut { get; private set; }

    public Book(string title, string author) : base(title)
    {
        Author = author;
        IsCheckedOut = false;
    }

    public void CheckOut()
    {
        if (IsCheckedOut)
        {
            Console.WriteLine("This book is already checked out.");
            return;
        }

        IsCheckedOut = true;
        Console.WriteLine($"{Title} has been checked out.");
    }

    public void ReturnItem()
    {
        if (!IsCheckedOut)
        {
            Console.WriteLine("This book was not checked out.");
            return;
        }

        IsCheckedOut = false;
        Console.WriteLine($"{Title} has been returned.");
    }

    public override void DisplayInfo()
    {
        string status = IsCheckedOut ? "Checked out" : "Available";
        Console.WriteLine($"{Title} by {Author} - {status}");
    }
}