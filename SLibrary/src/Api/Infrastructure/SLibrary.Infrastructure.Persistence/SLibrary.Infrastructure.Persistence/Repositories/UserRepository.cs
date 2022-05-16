using SLibrary.Api.Domain.Models;
using SLibrary.Application.Interfaces.Repositories;
using SLibrary.Infrastructure.Persistence.Context;

namespace SLibrary.Infrastructure.Persistence.Repositories;
public class UserRepository : GenericRepository<User>, IUserRepository
{
    #region Constructor
    public UserRepository(SLibraryContext sozlukContext) : base(sozlukContext)
    {
    }
    #endregion
}
