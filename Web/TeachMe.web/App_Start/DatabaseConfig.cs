namespace TeachMe.Web
{
    using Data;
    using Data.Migrations;
    using System.Data.Entity;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TeachMeDbContext, Configuration>());
            TeachMeDbContext.Create().Database.Initialize(true);
        }
    }
}