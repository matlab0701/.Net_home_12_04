namespace Domain.DTOs.Authors;

public class CountBooksDto:CreateAuthorDto
{
    public int Count { get; set; }
    public int Id { get; set; }
}
