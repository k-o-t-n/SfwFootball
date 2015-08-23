using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Sfw.Football.Models
{
    public class LoginModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [HiddenInput]
        public string ReturnUrl { get; set; }
    }
}