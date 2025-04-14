using System.Net;
using Domain.DTOs.Members;
using Domain.Entites;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class MemberService(DataContext context) : IMemberService
{
    public async Task<Response<GetMemberDto>> AddMember(CreateMemberDto memberDto)
    {
        var memberdto = new Member()
        {
            Name = memberDto.Name,
            Email = memberDto.Email,
        };

        await context.Members.AddAsync(memberdto);
        var res = await context.SaveChangesAsync();

        var get = new GetMemberDto()
        {
            Email = memberDto.Email,
            Name = memberDto.Name,
        };

        return res == 0
            ? new Response<GetMemberDto>(HttpStatusCode.BadRequest, "Not added")
            : new Response<GetMemberDto>(get);

    }

    public async Task<Response<GetMemberDto>> UpdateMember(int id, UpdateMemberDto memberDto)
    {
        var member = await context.Members.FindAsync(id);

        if (member == null)
        {
            return new Response<GetMemberDto>(HttpStatusCode.NotFound, "Member not found");
        }

        member.Email = memberDto.Email;
        member.Name = memberDto.Name;

        var res = await context.SaveChangesAsync();

        var result = new GetMemberDto()
        {
            Email = memberDto.Email,
            Name = memberDto.Name,
        };

        return new Response<GetMemberDto>(result);

    }

    public async Task<Response<string>> DeleteMember(int id)
    {
        var exists = context.Members.Find(id);

        context.Members.Remove(exists);

        var res = await context.SaveChangesAsync();

        return res == 0
            ? new Response<string>(HttpStatusCode.BadRequest, "Did not delete")
            : new Response<string>(HttpStatusCode.OK, "Member deleted");
    }

    public async Task<Response<GetMemberDto>> GetMember(int id)
    {
        var member = await context.Members.FindAsync(id);

        if (member == null)
        {
            return new Response<GetMemberDto>(HttpStatusCode.NotFound, "Member not found");
        }

        var res = new GetMemberDto()
        {
            Email = member.Email,
            Name = member.Name,
        };

        return new Response<GetMemberDto>(res);
    }

    public async Task<Response<List<GetMemberDto>>> GetMemberWithRecentBorrows(int days)
    {
        var day = DateTime.Now.AddDays(-days);
        var data = await context.Members
        .Where(m => m.MembershipDate >= day)
        .Select(m => new GetMemberDto()
        {
            Id = m.Id,
            Email = m.Email,
            Name = m.Name,
            MembershipDate = m.MembershipDate
        }).ToListAsync();
        return new Response<List<GetMemberDto>>(data);
    }


    public async Task<Response<List<TopMemberDto>>> GetTopNMemberByBorrows(int top)
    {
        var topMembers = await context.BorrowRecords
           .GroupBy(br => br.MemberId)
           .Select(group => new
           {
               MemberId = group.Key,
               TotalBorrows = group.Count()
           })
           .OrderByDescending(g => g.TotalBorrows)
           .Take(top)
           .Join(
               context.Members,
               g => g.MemberId,
               m => m.Id,
               (g, m) => new TopMemberDto
               {
                   Id = m.Id,
                   Name = m.Name,
                   TotalBorrows = g.TotalBorrows
               }
           ).ToListAsync();

        return new Response<List<TopMemberDto>>(topMembers);
    }
}
