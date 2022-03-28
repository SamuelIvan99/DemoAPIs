namespace APIProject.Models;
public class Book : Entity
{
    public int IBAN { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Author { get; set; } = string.Empty;

    public int PagesNo { get; set; }
}
