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
            optionsBuilder.UseSqlite(@"Data Source = C:\Users\nikok\OneDrive\Dokumenty\PROGRAMOWANIE\.NET\WFP\MVVM\LoginPanelExercise\LoginPanelLesson\LoginPanelLesson\LoginPanelDB.db");
        }
    }
}
