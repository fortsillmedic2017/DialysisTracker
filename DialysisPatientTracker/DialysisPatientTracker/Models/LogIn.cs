using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DialysisPatientTracker.Models
{
    public class LogIn
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        private static int nextId = 1;

        public LogIn()
        {
            UserId = nextId;
            nextId++;
        }
    }
}