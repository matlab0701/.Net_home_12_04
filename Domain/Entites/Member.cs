using System.ComponentModel.DataAnnotations;

namespace Domain.Entites;

public class Member
{
    [Key]
    public int Id { get; set; }
    [StringLength(55)]
    public string Name { get; set; }

    [StringLength(100), EmailAddress]
    public string Email { get; set; }
    public DateTime MembershipDate { get; set; }

    public List<BorrowRecord> borrowRecords { get; set; }
}
