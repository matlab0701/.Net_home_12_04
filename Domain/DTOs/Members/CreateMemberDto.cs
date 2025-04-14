namespace Domain.DTOs.Members;

public class CreateMemberDto
{
    
    public string Name { get; set; }

    public string Email { get; set; }
    public DateTime MembershipDate { get; set; }

}
