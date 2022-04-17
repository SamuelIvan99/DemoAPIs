namespace APIProject.Models;
public class Book
{
    public string IBAN { get; set; } = Guid.NewGuid().ToString();

    public string Title { get; set; } = "Book1";

    public string Author { get; set; } = "Author1";

    public int PagesNo { get; set; } = 100;
}
