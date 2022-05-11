﻿namespace APIProject.Consumer.Models;
public class Book
{
    public string IBAN { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Author { get; set; } = string.Empty;

    public int PagesNo { get; set; }
}
