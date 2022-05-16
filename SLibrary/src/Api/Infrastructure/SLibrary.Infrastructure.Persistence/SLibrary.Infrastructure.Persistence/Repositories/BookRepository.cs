using SLibrary.Api.Domain.Models;
using SLibrary.Application.Interfaces.Repositories;
using SLibrary.Infrastructure.Persistence.Context;

namespace SLibrary.Infrastructure.Persistence.Repositories;
public class BookRepository : GenericRepository<Book>, IBookRepository
{
    #region Constructor
    public BookRepository(SLibraryContext sLibraryContext) : base(sLibraryContext)
    {
    }
    #endregion
}

