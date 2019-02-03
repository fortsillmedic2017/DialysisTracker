using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DialysisPatentTracker.Models.SignUp
{
    public class SignUp
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ComfirmPassword { get; set; }
        public string Email { get; set; }

        public SignUp()
        { }
    }
}