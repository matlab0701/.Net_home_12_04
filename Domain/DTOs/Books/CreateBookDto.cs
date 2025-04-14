namespace Domain.DTOs.Books;

public class CreateBookDto
{

    public string Title { get; set; }
    public string Genre { get; set; }
    public DateTime PublishedDate { get; set; }
    public int AuthorId { get; set; }
}
