using AW.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.Data
{
    public class AWDbContext:DbContext
    {
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Person>()
            .Property(c => c.BusinessEntityID) // Client must set the ID.
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);


        }
    }
}
