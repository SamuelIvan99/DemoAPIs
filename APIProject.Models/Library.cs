namespace APIProject.Models;
public class Library : Entity
{
    public string Name { get; set; } = string.Empty;

    public Address Address { get; set; } = new();

    public IList<Book> Books { get; set; } = new List<Book>();
}