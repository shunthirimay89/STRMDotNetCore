

namespace STRMDotNetCore.RestApiWithNLayer.Db
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);

        }

        public DbSet<BlogModel> blogs { get; set; }

    }
}
