namespace Domain.DTOs.BorrowRecords;

public class CreateBorrowRecordDto
{
    public int MemberId { get; set; }
    public int BookId { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime ReturnDate { get; set; }
}
