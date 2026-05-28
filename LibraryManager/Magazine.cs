public class Magazine: Book {
    public string Company {get; set; }
    
    public Magazine(string title, string author, string company) : base(title, author)
    {
        Company = company;
    }
} 