using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using STRMDotNetCore.PizzaApi.Models;
using STRMDotNetCore.PizzaApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRMDotNetCore.PizzaApi.Db;

    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);

        }

        public DbSet<PizzaModel> pizzas { get; set; }
        public DbSet<PizzaExtraModel> pizzaExtras { get; set; }
        public DbSet<PizzaOrderModel> pizzaOrders { get; set; }
        public DbSet<PizzaOrderDetailModel> pizzaOrderDetils { get; set; }

}

public class OrderRequest 
{
    public int PizzaId { get; set; }
    public int[] ?Extras {  get; set; }
}

public class OrderResponse 
{
    public string Message { get; set; }
    public string InvoiceNo { get; set; }
    public decimal TotalAmount { get; set; }
}
