using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfw.Football.DataAccess.Repositories
{
    public class IdentityRepository<TUser> : IIdentityRepository<TUser>
    {
        private readonly PetaPoco.Database db = new PetaPoco.Database("defaultConnection");

        public Task<TUser> FindByIdAsyc(int userId)
        {
            var query = PetaPoco.Sql.Builder.Select("*").From("users").Where("Id = @userId", userId);
            return Task.FromResult(db.Query<TUser>(query).Single());
        }

        public Task<TUser> FindByNameAsync(string username)
        {
            var query = PetaPoco.Sql.Builder.Select("*").From("users").Where("UserName = @username", username);
            return Task.FromResult(db.Query<TUser>(query).Single());
        }
    }
}
