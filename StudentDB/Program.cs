using StudentDB.LogIn;
using StudentDB.StudentRegistration;

namespace StudentDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentDbContext dbContext = new StudentDbContext();
            //Logic to choose different storage, for example Json, other database
            StudentSQLStore dbHandler = new StudentSQLStore(dbContext);
            StudentHandler studentHandler = new StudentHandler(dbHandler);
            SystemUserDbContext systemUserDbContext = new SystemUserDbContext();
            LogInHandler logInHandler = new LogInHandler(systemUserDbContext);
            LogInManager logInManager = new LogInManager(logInHandler);
            SystemUser systemUser = logInManager.LogIn();
            if (systemUser != null)
            {
                AppManager appManager = new AppManager(studentHandler, systemUser);
                appManager.Run();
            }

        }
    }
}
