using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites;

public class BorrowRecord
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Member")]
    public int MemberId { get; set; }

    [ForeignKey("Book")]
    public int BookId { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public Member Member { get; set; }
    public Book Book { get; set; }
}
