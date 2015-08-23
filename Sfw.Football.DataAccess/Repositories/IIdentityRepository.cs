using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfw.Football.DataAccess.Repositories
{
    public interface IIdentityRepository<TUser>
    {
        TUser FindById(string userId);
        TUser FindByName(string userName);
        void SetPasswordHash(string userId, string passwordHash);
        void SaveUser(TUser user);
    }
}
