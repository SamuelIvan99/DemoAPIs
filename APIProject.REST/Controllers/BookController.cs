using APIProject.Models;
using APIProject.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIProject.REST.Controllers;

/// <summary>
/// API controller for Book entity class.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    IBookRepository _bookRepository;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public BookController(IBookRepository bookRepository)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        _bookRepository = bookRepository;
    }

    /// <summary>
    /// Get all Book entities from the container.
    /// </summary>
    /// <returns>List of Book entities.</returns>
    /// <response code="200">Returns list of all entities.</response>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetAll()
    {
        var result = await _bookRepository.GetAllAsync();
        return Ok(result);
    }

    /// <summary>
    /// Get Book by id from the container.
    /// </summary>
    /// <param name="id">Id of a Book entity</param>
    /// <returns>Found Book entity.</returns>
    /// <response code="200">Returns entity, else null if not found.</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<Book>>> GetById(int id)
    {
        var result = await _bookRepository.GetAsync(id);
        if (result is not null)
            return Ok(result);
        else
            return Ok("null");
    }

    /// <summary>
    /// Get Book by title from the container.
    /// </summary>
    /// <param name="title">Title of a Book entity</param>
    /// <returns>Found Book entity.</returns>
    /// <response code="200">Returns entity, else null if not found.</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetById(string title)
    {
        var result = await _bookRepository.GetByTitleAsync(title);
        if (result is not null)
            return Ok(result);
        else
            return Ok("null");
    }

    /// <summary>
    /// Create Book entity and store it in the container.
    /// </summary>
    /// <param name="book">Book entity to be created</param>
    /// <returns>Created Book entity.</returns>
    /// <response code="201">Returns newly created entity.</response>
    /// <response code="400">Returns bad request.</response>
    [HttpPost()]
    public async Task<ActionResult<Book>> Create([FromBody] Book book)
    {
        var result = await _bookRepository.CreateAsync(book);
        if (result)
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        else
            return BadRequest();
    }

    /// <summary>
    /// Update Book entity in the container.
    /// </summary>
    /// <param name="book">Book entity to be updated</param>
    /// <returns>Boolean if it was updated or not.</returns>
    /// <response code="200">Returns updated entity.</response>
    /// <response code="400">Entity was not updated.</response>
    [HttpPatch]
    public async Task<ActionResult<Book>> Update([FromBody] Book book)
    {
        var result = await _bookRepository.UpdateAsync(book);
        if (result)
            return Ok(book);
        else
            return BadRequest();
    }

    /// <summary>
    /// Delete Book entity from the container.
    /// </summary>
    /// <param name="id">Id of a Book entity</param>
    /// <returns>Nothing if deleted successfully, otherwise false.</returns>
    /// <response code="204">Entity delete successfully.</response>
    /// <response code="200">Entity was not deleted.</response>
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        var result = await _bookRepository.DeleteAsync(id);
        if (result)
            return NoContent();
        else
            return Ok(result);
    }
}
