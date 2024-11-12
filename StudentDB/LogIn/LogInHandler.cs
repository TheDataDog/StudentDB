using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB.LogIn
{
    internal class LogInHandler
    {
        private SystemUserDbContext dbContext;

        public LogInHandler(SystemUserDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        
        private List<SystemUser> GetAllUsers()
        {
            return dbContext.SystemUsers.Include(x => x.UserRole).ToList();
        }

        public SystemUser ValidateUser(string userName, string password)
        {
            List<SystemUser> systemUsers = GetAllUsers();
            foreach (SystemUser systemUser in systemUsers)
            {
                if (systemUser.UserName == userName)
                {
                    if (systemUser.Password == password)
                    {
                        return systemUser;
                    }
                    else
                    {
                        throw new Exception("Fel lösenord");
                    }
                }
                //else
                //{
                //    throw new Exception("Fel användarnamn");
                //}
            }
            return null;
        }
    }
}
