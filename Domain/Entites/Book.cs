using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites;

public class Book
{
    [Key]
    public int Id { get; set; }
    [Required,StringLength(200)]
    public string Title { get; set; }

    [StringLength(200)]
    public string Genre { get; set; }
    public DateTime PublishedDate { get; set; }

    [ForeignKey ("Author") ]
    public int AuthorId { get; set; }
    public Author Author { get; set; }
}
