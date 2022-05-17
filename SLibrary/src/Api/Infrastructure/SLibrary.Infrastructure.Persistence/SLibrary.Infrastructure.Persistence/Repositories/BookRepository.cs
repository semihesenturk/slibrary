using SLibrary.Api.Domain.Models;
using SLibrary.Application.Interfaces.Repositories;
using SLibrary.Common.Models.RequestModels;
using SLibrary.Infrastructure.Persistence.Context;

namespace SLibrary.Infrastructure.Persistence.Repositories;
public class BookRepository : GenericRepository<Book>, IBookRepository
{
    #region Constructor
    public BookRepository(SLibraryContext sLibraryContext) : base(sLibraryContext)
    {
    }

    public Task<bool> CheckInBook(BookCheckinRequestModel bookCheckinRequestModel)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CheckoutBook(BookCheckoutRequestModel bookCheckoutRequestModel)
    {
        throw new NotImplementedException();
    }
    #endregion
}

