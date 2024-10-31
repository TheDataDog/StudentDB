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
            AppManager appManager = new AppManager(studentHandler);
            appManager.Run();

            // var myEnumMemberCount = Enum.GetNames(typeof(MyEnum)).Length;

        }
    }
}
