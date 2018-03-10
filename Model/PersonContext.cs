using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session07.Exam.Model
{


    public partial class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Initial Catalog=Employee;" +
                "Integrated Security=true");

            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Person> Persons { get; set; }
      

    }

    public class ShopingContextFactory : IDesignTimeDbContextFactory<PersonContext>
    {
        public PersonContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PersonContext>();
            optionsBuilder.UseSqlServer("Server=.; Initial Catalog=Employee;" +
                "Integrated Security=true");

            return new PersonContext(optionsBuilder.Options);
        }
    }
}
