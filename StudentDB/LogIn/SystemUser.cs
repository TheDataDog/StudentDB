using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB.LogIn
{
    internal class SystemUser
    {
        public int SystemUserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; }
    }
}
