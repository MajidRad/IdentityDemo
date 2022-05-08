using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityDemo.DTOs
{

    public class LoginDto
    {
        public string UserName { get; set; }
        //public string Email { get; set; }
        public string Password { get; set; }
    }
}
