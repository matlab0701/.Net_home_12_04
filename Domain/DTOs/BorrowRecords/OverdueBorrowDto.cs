namespace Domain.DTOs.BorrowRecords;

public class OverdueBorrowDto
{
    public int Id { get; set; }
    public string MemberName { get; set; }
    public string BookTitle { get; set; }
    public DateTime BorrowDate { get; set; }
}

