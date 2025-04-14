using Domain.DTOs.BorrowRecords;
using Domain.Responses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;



[ApiController]
[Route("api/[controller]")]
public class BorrowRecordController(IBorrowRecordService borrowService) : ControllerBase
{
    [HttpPost]
    public async Task<Response<GetBorrowRecordDto>> AddBorrowRecord(CreateBorrowRecordDto createBorrowRecord)
    {
        return await borrowService.AddBorrowRecord(createBorrowRecord);
    }

    [HttpPut]
    public async Task<Response<GetBorrowRecordDto>> UpdateBorrowRecord(int borrowRecordId, UpdateBorrowRecordDto updateBorrowRecord)
    {
        return await borrowService.UpdateBorrowRecord(borrowRecordId, updateBorrowRecord);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteBorrowRecord(int borrowRecordId)
    {
        return await borrowService.DeleteBorrowRecord(borrowRecordId);
    }

    [HttpGet("id")]
    public async Task<Response<GetBorrowRecordDto>> GetBorrowRecord(int borrowRecordId)
    {
        return await borrowService.GetBorrowRecord(borrowRecordId);
    }

    [HttpGet("Overdue")]
    public async Task<Response<List<OverdueBorrowDto>>> GetOverdueBorrowRecord()
    {
        return await borrowService.GetOverdueBorrowRecord();
    }

    [HttpGet("memberId")]
    public async Task<Response<List<GetBorrowRecordDto>>> GetBorrowHistoryByMember(int memberId)
    {
        return await borrowService.GetBorrowHistoryByMember(memberId);
    }

    [HttpGet("bookId")]
    public async Task<Response<List<GetBorrowRecordDto>>> GetBorrowHistoryByBook(int bookId)
    {
        return await borrowService.GetBorrowHistoryByBook(bookId);
    }
}
