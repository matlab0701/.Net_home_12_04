using Domain.DTOs.Members;
using Domain.Responses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class MemberController(IMemberService memberService) : ControllerBase
{

    [HttpPost]
    public async Task<Response<GetMemberDto>> AddMember(CreateMemberDto createMember)
    {
        return await memberService.AddMember(createMember);
    }

    [HttpPut]
    public async Task<Response<GetMemberDto>> UpdateMember(int MemberId, UpdateMemberDto updateMember)
    {
        return await memberService.UpdateMember(MemberId, updateMember);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteMember(int MemberId)
    {
        return await memberService.DeleteMember(MemberId);
    }

    [HttpGet("id")]
    public async Task<Response<GetMemberDto>> GetMember(int MemberId)
    {
        return await memberService.GetMember(MemberId);
    }

    [HttpGet("RecentBorrows")]
    public async Task<Response<List<GetMemberDto>>> GetMemberWithRecentBorrows(int days)
    {
        return await memberService.GetMemberWithRecentBorrows(days);
    }

    [HttpGet("TopMembersByBorrows")]
    public async Task<Response<List<TopMemberDto>>> GetTopNMemberByBorrows(int Top)
    {
        return await memberService.GetTopNMemberByBorrows(Top);
    }
}

