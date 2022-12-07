using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPanelLesson.MVVM.Models.Entities
{
    public class MyDbContext : DbContext
    {
        public DbSet<Users> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(@"FileName = LoginPanelDB.db");
        }

    }
}
