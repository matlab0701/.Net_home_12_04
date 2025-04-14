using Domain.DTOs.Books;
using Domain.Responses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController(IBookService bookService)
{
    [HttpPost]
    public async Task<Response<GetBookDto>> AddBook(CreateBookDto createBook)
    {
        return await bookService.AddBook(createBook);
    }

    [HttpPut]
    public async Task<Response<GetBookDto>> UpdateBook(int BookId, UpdateBookDto updateBook)
    {
        return await bookService.UpdateBook(BookId, updateBook);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteBook(int BookId)
    {
        return await bookService.DeleteBook(BookId);
    }

    [HttpGet("id")]
    public async Task<Response<GetBookDto>> GetBook(int BookId)
    {
        return await bookService.GetBook(BookId);
    }

    [HttpGet("Author")]
    public async Task<Response<List<GetBookDto>>> GetBooksByAuthor(string Name)
    {
        return await bookService.GetBookByAuthor( Name);
    }

    [HttpGet("Genre")]
    public async Task<Response<List<GetBookDto>>> GetBooksByGenre(string Genre)
    {
        return await bookService.GetBookByGenre(Genre);
    }

    [HttpGet("RecentBooks")]
    public async Task<Response<List<GetBookDto>>> GetRecentlyPublishedBooks(int years)
    {
        return await bookService.GetRecentlyPublishedBooks(years);
    }
}
