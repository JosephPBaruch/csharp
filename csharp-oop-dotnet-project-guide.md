# Learning C# and Object-Oriented Programming with .NET

This guide walks through setting up a beginner C# project, learning basic syntax, practicing object-oriented programming concepts, and building a small console app.

## Goal

You will build a simple **Library Manager** console application using C# and .NET.

This project is meant to help you practice:

- Classes and objects
- Properties and constructors
- Encapsulation
- Inheritance
- Interfaces
- Lists and collections
- Basic console input/output
- Program organization

---

## 1. Install the Required Tools

You can use either Visual Studio Code or Visual Studio.

### Option A: Visual Studio Code

Install:

1. [.NET SDK](https://dotnet.microsoft.com/en-us/download)
2. [Visual Studio Code](https://code.visualstudio.com/)
3. The **C# Dev Kit** extension in VS Code

### Option B: Visual Studio

Install:

1. [Visual Studio 2022](https://visualstudio.microsoft.com/)
2. Select one of these workloads during installation:
   - **.NET desktop development**
   - **ASP.NET and web development**

---

## 2. Create a New Console Project

Open a terminal and run:

```bash
mkdir CSharpOopPractice
cd CSharpOopPractice
dotnet new console -n LibraryManager
cd LibraryManager
dotnet run
```

This creates and runs a basic C# console application.

Your project folder should look something like this:

```text
LibraryManager/
├── LibraryManager.csproj
├── Program.cs
└── obj/
```

To run the project again:

```bash
dotnet run
```

To build the project without running it:

```bash
dotnet build
```

---

## 3. Basic C# Syntax Guidelines

### Variables

```csharp
string name = "Joseph";
int age = 22;
bool isStudent = true;
double price = 19.99;
```

C# is strongly typed, which means variables have specific types.

You can also use `var` when the type is obvious:

```csharp
var title = "Clean Code";
var pages = 464;
```

---

### Console Output

```csharp
Console.WriteLine("Hello, World!");
```

String interpolation:

```csharp
string name = "Joseph";
Console.WriteLine($"Hello, {name}!");
```

---

### Console Input

```csharp
Console.Write("Enter your name: ");
string? name = Console.ReadLine();

Console.WriteLine($"Hello, {name}");
```

The `?` in `string?` means the value could be `null`.

---

### If Statements

```csharp
int age = 20;

if (age >= 18)
{
    Console.WriteLine("Adult");
}
else
{
    Console.WriteLine("Minor");
}
```

---

### Loops

```csharp
for (int i = 0; i < 5; i++)
{
    Console.WriteLine(i);
}
```

```csharp
int count = 0;

while (count < 5)
{
    Console.WriteLine(count);
    count++;
}
```

---

### Methods

```csharp
static void SayHello(string name)
{
    Console.WriteLine($"Hello, {name}!");
}
```

Call the method:

```csharp
SayHello("Joseph");
```

A method that returns a value:

```csharp
static int Add(int a, int b)
{
    return a + b;
}
```

---

## 4. Object-Oriented Programming Concepts

Object-oriented programming, or OOP, is a way of organizing code around objects.

An object usually has:

- Data, also called state
- Behavior, usually methods

For example, a `Book` object might have:

- Title
- Author
- Checked-out status
- A method to check it out
- A method to return it

---

## 5. Classes and Objects

A class is a blueprint for an object.

```csharp
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsCheckedOut { get; private set; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
        IsCheckedOut = false;
    }

    public void CheckOut()
    {
        IsCheckedOut = true;
    }

    public void ReturnBook()
    {
        IsCheckedOut = false;
    }
}
```

Create an object from the class:

```csharp
Book book = new Book("The Pragmatic Programmer", "Andrew Hunt");

book.CheckOut();

Console.WriteLine(book.Title);
```

---

## 6. Properties

Prefer properties instead of public fields.

```csharp
public string Title { get; set; }
```

Use `private set` when only the class itself should change the value:

```csharp
public bool IsCheckedOut { get; private set; }
```

This protects the internal state of the object.

---

## 7. Encapsulation

Encapsulation means hiding internal details and controlling how outside code interacts with an object.

Example:

```csharp
public class BankAccount
{
    public decimal Balance { get; private set; }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be positive.");
        }

        Balance += amount;
    }
}
```

Outside code can read the balance, but it cannot directly set it.

```csharp
BankAccount account = new BankAccount();
account.Deposit(100);

// This would not work because the setter is private:
// account.Balance = 500;
```

---

## 8. Inheritance

Inheritance lets one class reuse and extend another class.

```csharp
public class LibraryItem
{
    public string Title { get; set; }

    public LibraryItem(string title)
    {
        Title = title;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
    }
}
```

A `Book` can inherit from `LibraryItem`:

```csharp
public class Book : LibraryItem
{
    public string Author { get; set; }

    public Book(string title, string author) : base(title)
    {
        Author = author;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Book: {Title} by {Author}");
    }
}
```

Important keywords:

- `base` calls the parent class constructor
- `virtual` allows a method to be overridden
- `override` changes the behavior in the child class

---

## 9. Interfaces

An interface defines behavior that a class must implement.

```csharp
public interface ICheckoutable
{
    void CheckOut();
    void ReturnItem();
}
```

A class can implement an interface:

```csharp
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
        IsCheckedOut = true;
    }

    public void ReturnItem()
    {
        IsCheckedOut = false;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"{Title} by {Author}");
    }
}
```

Interfaces are useful when different classes should share the same behavior.

For example:

- `Book`
- `DVD`
- `Magazine`

could all implement `ICheckoutable`.

---

## 10. Project Idea: Library Manager

Build a console app that manages a small library.

### Features

Start with these features:

1. Add a book
2. View all books
3. Check out a book
4. Return a book
5. Search for a book by title
6. Exit the program

---

## 11. Suggested Project Structure

Create these files:

```text
LibraryManager/
├── Program.cs
├── Book.cs
├── Library.cs
├── LibraryItem.cs
└── ICheckoutable.cs
```

You can create files manually in VS Code or run:

```bash
touch Book.cs Library.cs LibraryItem.cs ICheckoutable.cs
```

On Windows PowerShell:

```powershell
New-Item Book.cs
New-Item Library.cs
New-Item LibraryItem.cs
New-Item ICheckoutable.cs
```

---

## 12. Code for the Project

### LibraryItem.cs

```csharp
public abstract class LibraryItem
{
    public string Title { get; set; }

    protected LibraryItem(string title)
    {
        Title = title;
    }

    public abstract void DisplayInfo();
}
```

Explanation:

- `abstract` means you cannot create a plain `LibraryItem`.
- Other classes, like `Book`, inherit from it.
- `DisplayInfo` must be implemented by child classes.

---

### ICheckoutable.cs

```csharp
public interface ICheckoutable
{
    void CheckOut();
    void ReturnItem();
}
```

Explanation:

- Any class that implements this interface must have `CheckOut` and `ReturnItem` methods.

---

### Book.cs

```csharp
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
```

---

### Library.cs

```csharp
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
```

Explanation:

- `_books` is private because the `Library` class should manage the list.
- `AddBook` safely adds books.
- `DisplayBooks` shows all books.
- `FindBookByTitle` searches for one book.

---

### Program.cs

```csharp
Library library = new Library();

while (true)
{
    Console.WriteLine();
    Console.WriteLine("Library Manager");
    Console.WriteLine("1. Add book");
    Console.WriteLine("2. View books");
    Console.WriteLine("3. Check out book");
    Console.WriteLine("4. Return book");
    Console.WriteLine("5. Exit");
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
        break;
    }
    else
    {
        Console.WriteLine("Invalid option.");
    }
}
```

---

## 13. How to Run the Project

From inside the `LibraryManager` folder:

```bash
dotnet run
```

Example interaction:

```text
Library Manager
1. Add book
2. View books
3. Check out book
4. Return book
5. Exit
Choose an option:
```

---

## 14. Suggested Learning Order

Follow this order as you learn:

1. Console input and output
2. Variables and types
3. Strings and string interpolation
4. Conditionals
5. Loops
6. Methods
7. Classes and objects
8. Properties and constructors
9. Lists
10. Encapsulation
11. Interfaces
12. Inheritance
13. Polymorphism
14. Unit testing
15. ASP.NET Core Web APIs

---

## 15. Stretch Goals

After the basic project works, add these features:

### Easy

- Prevent duplicate book titles
- Add a menu option to delete a book
- Add a menu option to list only available books
- Add a menu option to list only checked-out books

### Medium

- Add a `Magazine` class
- Add a `DVD` class
- Make `Library` store `List<LibraryItem>` instead of `List<Book>`
- Use polymorphism to call `DisplayInfo` on different item types

### Harder

- Save books to a file
- Load books from a file when the app starts
- Add unit tests
- Convert the console app into an ASP.NET Core Web API

---

## 16. Next Project After This

After finishing the console version, build an **ASP.NET Core Web API** version.

Possible endpoints:

```text
GET /books
GET /books/{id}
POST /books
PUT /books/{id}/checkout
PUT /books/{id}/return
DELETE /books/{id}
```

This will teach:

- Controllers
- Services
- Dependency injection
- HTTP endpoints
- JSON
- Basic API design

---

## 17. Key Takeaways

- C# is strongly typed.
- Classes are blueprints for objects.
- Objects combine data and behavior.
- Encapsulation protects object state.
- Interfaces define shared behavior.
- Inheritance lets classes reuse and extend other classes.
- Polymorphism lets different object types be used through a common base type or interface.
- Small console apps are a great way to practice OOP before moving to web APIs.
