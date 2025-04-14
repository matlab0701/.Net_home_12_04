using System.ComponentModel.DataAnnotations;

namespace Domain.Entites;

public class Author
{
    [Key]
    public int Id { get; set; }
    [StringLength(80)]
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public List<Book> Books { get; set; } 
}

