using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Presto.Models;

namespace Presto.DAL
{
    public class PrestoContext : DbContext
    {
        public PrestoContext()
            : base("PrestoContext")
        {
            //Database.SetInitializer<PrestoContext>(new CreateDatabaseIfNotExists<PrestoContext>());
            //Database.SetInitializer(new PrestoInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Simulacion> Simulaciones { get; set; }

    }
}