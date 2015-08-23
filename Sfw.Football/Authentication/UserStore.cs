using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Sfw.Football.DataAccess.Repositories;
using Sfw.Football.DataAccess.Entities;

namespace Sfw.Football.Authentication
{
    public class UserStore<TUser> : IUserStore<TUser>,
        IUserPasswordStore<TUser>
        where TUser : AuthenticatedUser
    {
        private IIdentityRepository<User> _identities;

        public UserStore(IIdentityRepository<User> identities)
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
            var result = new AuthenticatedUser(_identities.FindById(userId));
            return await Task.FromResult(result as TUser);
        }

        public async Task<TUser> FindByNameAsync(string userName)
        {
            var result = new AuthenticatedUser(_identities.FindByName(userName));
            return await Task.FromResult(result as TUser);
        }

        public async Task<string> GetPasswordHashAsync(TUser user)
        {
            return await Task.FromResult(user.PasswordHash);
        }

        public async Task<bool> HasPasswordAsync(TUser user)
        {
            return await Task.FromResult(user.PasswordHash != null);
        }

        public Task SetPasswordHashAsync(TUser user, string passwordHash)
        {
            _identities.SetPasswordHash(user.Id, passwordHash);
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }

        public Task UpdateAsync(TUser user)
        {
            var userEntity = _identities.FindById(user.Id);
            userEntity.Email = user.Email;
            userEntity.PasswordHash = user.PasswordHash;
            _identities.SaveUser(userEntity);
            return Task.FromResult(0);
        }
    }
}