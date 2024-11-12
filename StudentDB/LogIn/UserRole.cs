using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB.LogIn
{
    internal class UserRole
    {
        public int UserRoleId { get; set; }
        public string RoleName { get; set; }
        public bool SetGrade { get; set; } = false;
        public bool RegisterNew { get; set; } = false;
        public bool ChangeExisting { get; set; } = false;
        public bool DeleteExisting { get; set; } = false;
        public int SystemUserId { get; set; }
    }
}
