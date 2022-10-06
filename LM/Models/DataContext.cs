
using LM.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LM.Models
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<LC_Detail> LC_Details { get; set; }

        public DbSet<Collateral_RealEstate> Collateral_RealEstate{ get; set; }

        public DbSet<Collateral_CashDeposit> Collateral_CashDeposits { get; set; }

        //public DbSet<Customer> Customers { get; set; }

    }
}
