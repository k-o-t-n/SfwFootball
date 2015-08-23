using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Sfw.Football.DataAccess.Repositories;

namespace Sfw.Football.Authentication
{
    public class UserStore<TUser> : IUserStore<TUser>,
        IUserPasswordStore<TUser>
        where TUser : AuthenticatedUser
    {
        private IIdentityRepository<TUser> _identities;

        public UserStore(IIdentityRepository<TUser> identities)
        {
            _identities = identities;
        }

        public Task CreateAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<TUser> FindByIdAsync(string userId)
        {
            return await Task.FromResult(_identities.FindById(userId));
        }

        public async Task<TUser> FindByNameAsync(string userName)
        {
            return await Task.FromResult(_identities.FindByName(userName));
        }

        public async Task<string> GetPasswordHashAsync(TUser user)
        {
            return await Task.FromResult(_identities.GetPasswordHashByUserId(user.Id));
        }

        public async Task<bool> HasPasswordAsync(TUser user)
        {
            return await Task.FromResult(_identities.HasPassword(user.Id));
        }

        public Task SetPasswordHashAsync(TUser user, string passwordHash)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TUser user)
        {
            throw new NotImplementedException();
        }
    }
}