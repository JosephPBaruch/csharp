Library library = new Library();

while (true)
{
    Console.WriteLine();
    Console.WriteLine("Library Manager");
    Console.WriteLine("1. Add book");
    Console.WriteLine("2. View books");
    Console.WriteLine("3. Check out book");
    Console.WriteLine("4. Return book");
    Console.WriteLine("5. Delete book");
    Console.WriteLine("6. Exit");
    Console.Write("Choose an option: ");

    string? choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.Write("Title: ");
        string? title = Console.ReadLine();

        Console.Write("Author: ");
        string? author = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(author))
        {
            library.AddBook(new Book(title, author));
            Console.WriteLine("Book added.");
        }
        else
        {
            Console.WriteLine("Title and author are required.");
        }
    }
    else if (choice == "2")
    {
        library.DisplayBooks();
    }
    else if (choice == "3")
    {
        Console.Write("Enter title: ");
        string? title = Console.ReadLine();

        Book? book = library.FindBookByTitle(title ?? "");

        if (book == null)
        {
            Console.WriteLine("Book not found.");
        }
        else
        {
            book.CheckOut();
        }
    }
    else if (choice == "4")
    {
        Console.Write("Enter title: ");
        string? title = Console.ReadLine();

        Book? book = library.FindBookByTitle(title ?? "");

        if (book == null)
        {
            Console.WriteLine("Book not found.");
        }
        else
        {
            book.ReturnItem();
        }
    }
    else if (choice == "5")
    {
        Console.Write("Enter title: ");
        string? title = Console.ReadLine();

        Book? book = library.FindBookByTitle(title ?? "");

        if (book == null)
        {
            Console.WriteLine("Book not found.");
        }
        else if(book.IsCheckedOut == true){
            Console.WriteLine("Cannot delete books that is checked out.");
        }
        else
        {
            // Deleting book should be a method in the library class and not the book class. 
            // You cannot tell a book to delete itself 
            library.DeleteBook(book);
        }
    }
    else if (choice == "6"){
        break;
    }
    else
    {
        Console.WriteLine("Invalid option.");
    }
}