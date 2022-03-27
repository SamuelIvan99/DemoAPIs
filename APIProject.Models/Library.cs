namespace APIProject.Models;
public class Library
{
    public int Id { get; set; }


    public string Name { get; set; } = string.Empty;

    public Address Address { get; set; } = new();

    public IList<Book> Books { get; set; } = new List<Book>();
}