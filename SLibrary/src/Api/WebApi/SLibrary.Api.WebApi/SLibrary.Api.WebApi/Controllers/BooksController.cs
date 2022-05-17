using Microsoft.AspNetCore.Mvc;
using SLibrary.Application.Interfaces.Repositories;
using SLibrary.Common.Models.RequestModels;
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

    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [HttpPost("checkout")]
    public async Task<ActionResult<bool>> Checkout([FromBody] BookCheckoutRequestModel model)
    {
        var result = await _bookRepository.CheckoutBook(model);

        if (!result)
        {
            _logger.LogError("Book can not checkedout!");
            return BadRequest("Book can not checkedout!");
        }

        return Ok(result);
    }

    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [HttpPost("checkin")]
    public async Task<ActionResult<bool>> Checkin([FromBody] BookCheckinRequestModel model)
    {
        var result = await _bookRepository.CheckInBook(model);

        if (!result)
        {
            _logger.LogError("Book can not checkedin!");
            return BadRequest("Book can not checkedin!");
        }

        return Ok(result);
    }
}

