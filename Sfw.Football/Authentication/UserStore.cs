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
            return _identities.CreateUserAsync(MapUser(user));
        }

        public Task DeleteAsync(TUser user)
        {
            return _identities.DeleteUserAsync(MapUser(user));
        }

        public void Dispose()
        {
            _identities.Dispose();
        }

        public async Task<TUser> FindByIdAsync(string userId)
        {
            return new AuthenticatedUser(await _identities.FindByIdAsync(userId)) as TUser;
        }

        public async Task<TUser> FindByNameAsync(string userName)
        {
            var result = await _identities.FindByNameAsync(userName);
            if (result != null)
            {
                return new AuthenticatedUser(result) as TUser;
            }
            return new AuthenticatedUser(userName) as TUser;
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
            return Task.FromResult(user.PasswordHash = passwordHash);
        }

        public async Task UpdateAsync(TUser user)
        {
            await _identities.SaveUserAsync(MapUser(user));
        }

        private User MapUser(TUser user)
        {
            return new User
            {
                Id = user.Id,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                Email = user.Email
            };
        }
    }
}