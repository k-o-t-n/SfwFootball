using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Sfw.Football.DataAccess.Entities;

namespace Sfw.Football.Authentication
{
    public class AuthenticatedUser : IUser<string>
    {
        private const string SfwFootballUserKey = "SfwFootballUsers/{0}";
        public string Id
        {
            get
            {
                return string.Format(SfwFootballUserKey, UserName);
            }
        }

        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }

        public AuthenticatedUser(string userName)
        {
            this.UserName = userName;
        }

        public AuthenticatedUser(string userName, string email) : this(userName)
        {
            this.Email = email;
        }

        public AuthenticatedUser(User user)
        {
            this.UserName = user.UserName;
            this.PasswordHash = user.PasswordHash;
            this.Email = user.Email;
        }
    }
}