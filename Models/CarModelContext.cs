using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace CHMS.Models
{
    public class CarModelContext : DbContext
    {
        public DbSet<CarModel> Cars { get; set; }   

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = cars.db");
            optionsBuilder.UseLazyLoadingProxies(); 
        }
    }
}
