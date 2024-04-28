using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using STRMDotNetCore.RestApi.Models;
using STRMDotNetCore.RestApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRMDotNetCore.RestApi.Db
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
