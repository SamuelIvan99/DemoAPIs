using APIProject.Models;
using APIProject.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIProject.REST.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LibraryController : ControllerBase
{
    ILibraryRepository _libraryRepository;

    public LibraryController(ILibraryRepository libraryRepository)
    {
        _libraryRepository = libraryRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Library>>> GetAll()
    {
        var result = await _libraryRepository.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<Library>>> GetById([FromQuery] int id)
    {
        var result = await _libraryRepository.GetAsync(id);
        return Ok(result);
    }

    /// <summary>
    /// Create Library model and store it in the container.
    /// </summary>
    /// <param name="library"></param>
    /// <returns>Created Library model</returns>
    /// <example>
    /// Example
    /// POST api/library
    /// {
    ///     "id": 1,
    ///     "name": "test",
    ///     "address" : {
    ///         "street": "street",
    ///         "city": "city",
    ///         "country": "country"
    ///     }
    /// }
    /// </example>
    /// <response code="201">Returns the newly created model</response>
    /// <response code="400">Returns bad request</response>
    [HttpPost()]
    public async Task<ActionResult<Library>> Create([FromBody] Library library)
    {
        var result = await _libraryRepository.CreateAsync(library);
        if (result)
            return CreatedAtAction(nameof(GetById), new { id = library.Id }, library);
        else
        {
            return BadRequest();
        }
    }
}
