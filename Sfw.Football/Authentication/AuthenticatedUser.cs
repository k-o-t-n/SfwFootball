using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace Sfw.Football.Authentication
{
    public class AuthenticatedUser : IUser<string>
    {
        public string Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string UserName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}