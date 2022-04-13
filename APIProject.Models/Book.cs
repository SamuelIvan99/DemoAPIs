namespace APIProject.Models;
public class Book : Entity
{
    public string IBAN { get; set; } = Guid.NewGuid().ToString();

    public string Title { get; set; } = string.Empty;

    public string Author { get; set; } = string.Empty;

    public int PagesNo { get; set; }
}
