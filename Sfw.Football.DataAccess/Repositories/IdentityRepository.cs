using Sfw.Football.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;
using NPoco.Expressions;

namespace Sfw.Football.DataAccess.Repositories
{
    public class IdentityRepository : IIdentityRepository<User>
    {
        private readonly Database db = new Database("defaultConnection");

        public Task CreateUserAsync(User user)
        {
            return Task.FromResult(db.Insert(user));
        }
        
        public Task DeleteUserAsync(User user)
        {
            return Task.FromResult(db.Delete(user));
        }

        public void Dispose()
        {
            db.Dispose();
        }
        
        public Task<User> FindByIdAsync(string userId)
        {
            return Task.FromResult(db.SingleById<User>(userId));
        }

        public Task<User> FindByNameAsync(string userName)
        {
            return Task.FromResult(
                db.FetchBy<User>(sql => sql.Where(x => x.UserName == userName)).SingleOrDefault());
        }

        public Task SaveUserAsync(User user)
        {
            return Task.FromResult(db.Update(user));
        }
    }
}
