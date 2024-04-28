using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using STRMDotNetCoreRestApi.Models;
using STRMDotNetCoreRestApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRMDotNetCoreRestApi.Db
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
