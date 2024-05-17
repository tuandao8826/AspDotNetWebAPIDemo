using DotNetCoreWebAPIWithAngular_BE.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPIWithAngular_BE.Infrastructure.DBContext
{
    public class WebAPIWithAngularDemoContext : DbContext
    {
        public WebAPIWithAngularDemoContext()
        {

        }
        public WebAPIWithAngularDemoContext(DbContextOptions<WebAPIWithAngularDemoContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-OTHPHUSK\\SQLEXPRESS;Initial Catalog=WebAPIWithAngularDemo;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;TrustServerCertificate=True");
            }
        }

        #region DbSet
        public DbSet<User> Users { get; set; }
        #endregion
    }
}
