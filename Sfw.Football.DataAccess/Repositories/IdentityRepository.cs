using Sfw.Football.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfw.Football.DataAccess.Repositories
{
    public class IdentityRepository : IIdentityRepository<User>
    {
        private readonly PetaPoco.Database db = new PetaPoco.Database("defaultConnection");

        public User FindById(string userId)
        {
            var query = PetaPoco.Sql.Builder.Select("*").From("users").Where("Id = @userId", new { userId });
            return db.Query<User>(query).Single();
        }

        public User FindByName(string userName)
        {
            var query = PetaPoco.Sql.Builder.Select("*").From("users").Where("UserName = @userName", new { userName });
            var result = db.Query<User>(query).Single();
            return result;
        }

        public void SaveUser(User user)
        {
            db.Update("users", "Id", user);
        }

        public void SetPasswordHash(string userId, string passwordHash)
        {
            var user = FindById(userId);
            user.PasswordHash = passwordHash;
            db.Update("users", "Id", user);
        }
    }
}
