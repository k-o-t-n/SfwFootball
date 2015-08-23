using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfw.Football.DataAccess.Repositories
{
    public interface IIdentityRepository<TUser>
    {
        Task<TUser> FindByIdAsync(string userId);
        Task<TUser> FindByNameAsync(string userName);
        Task CreateUserAsync(TUser user);
        Task DeleteUserAsync(TUser user);
        Task SaveUserAsync(TUser user);
        void Dispose();
    }
}
