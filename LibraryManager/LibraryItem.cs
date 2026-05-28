public abstract class LibraryItem
{
    public string Title { get; set; }

    protected LibraryItem(string title)
    {
        Title = title;
    }

    public abstract void DisplayInfo();
}