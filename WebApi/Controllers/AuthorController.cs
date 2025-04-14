using Domain.DTOs.Authors;
using Domain.Responses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthorController(IAuthorService authorService) : ControllerBase
{
    [HttpPost]
    public async Task<Response<GetAuthorDto>> AddAuthor(CreateAuthorDto createAuthor)
    {
        return await authorService.AddAuthorAsync(createAuthor);
    }
    
    [HttpPut]
    public async Task<Response<GetAuthorDto>> UpdateAuthor(int AuthorId, UpdateAuthorDto updateAuthor)
    {
        return await authorService.UpdateAuthorAsync(AuthorId, updateAuthor);
    }
    
    [HttpDelete]
    public async Task<Response<string>> DeleteAuthor(int AuthorId)
    {
        return await authorService.DeleteAuthorAsync(AuthorId);
    }
    
    [HttpGet("id")]
    public async Task<Response<GetAuthorDto>> GetAuthor(int AuthorId)
    {
        return await authorService.GetAuthorAsync(AuthorId);
    }
    
    [HttpGet("AuthorsWithMostBooks")]
    public async Task<Response<List<CountBooksDto>>> GetAuthorsWithMostBooks(int count)
    {
        return await authorService.GetAuthorsWithMostBooksAsync(count);
    }
}
