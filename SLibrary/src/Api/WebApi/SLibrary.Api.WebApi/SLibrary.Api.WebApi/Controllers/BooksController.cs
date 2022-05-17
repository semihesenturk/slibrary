using Microsoft.AspNetCore.Mvc;
using SLibrary.Application.Interfaces.Repositories;
using SLibrary.Common.Models.ViewModels;
using System.Net;

namespace SLibrary.Api.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    #region Variables
    private readonly IBookRepository _bookRepository;
    private readonly ILogger<BooksController> _logger;
    #endregion

    #region Constructor
    public BooksController(IBookRepository bookRepository, ILogger<BooksController> logger)
    {
        _bookRepository = bookRepository;
        _logger = logger;
    } 
    #endregion


    // GET: api/<BooksController>
    [ProducesResponseType(typeof(BookListViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [HttpGet]
    public async Task<ActionResult<BookListViewModel>> Get()
    {
        var result = await _bookRepository.GetAll();

        if (result is null)
        {
            _logger.LogError("Book list is empty!");
            return BadRequest("Book list is empty!");
        }

        return Ok(result);
    }

    // GET api/<BooksController>/5
    [ProducesResponseType(typeof(BookViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [HttpGet("{id}")]
    public async Task<ActionResult<BookViewModel>> Get(Guid id)
    {
        var result = await _bookRepository.GetByIdAsync(id);

        if (result is null)
        {
            _logger.LogError("Book not found!");
            return BadRequest("Book not found!");
        }

        return Ok(result);
    }

    // POST api/<BooksController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<BooksController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<BooksController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}

