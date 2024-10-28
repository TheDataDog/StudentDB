namespace StudentDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentDbContext dbContext = new StudentDbContext();
            StudentSQLStore dbHandler = new StudentSQLStore(dbContext);


            StudentHandler studentHandler = new StudentHandler(dbHandler);
            AppManager appManager = new AppManager(studentHandler);
            appManager.Run();

        }
    }
}
