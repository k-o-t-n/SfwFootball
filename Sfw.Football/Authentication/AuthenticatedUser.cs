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

        private string _userName;
        public string UserName
        {
            get
            {
                return _userName;
            }

            set
            {
                _userName = value;
            }
        }

        public string PasswordHash { get; set; }

        public string Email { get; set; }

        public AuthenticatedUser(User user)
        {
            this.UserName = user.UserName;
            this.PasswordHash = user.PasswordHash;
            this.Email = user.Email;
        }
    }
}