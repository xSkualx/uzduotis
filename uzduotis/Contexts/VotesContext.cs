using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uzduotis.NewFolder;

namespace uzduotis.Contexts
{
    public class VotesContext : DbContext
    { 

        public DbSet<Vote> Votes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = System.Configuration.ConfigurationManager.ConnectionStrings["UsersDatabase"].ConnectionString;
            optionsBuilder.UseSqlServer(connection);
        }
    }
}
