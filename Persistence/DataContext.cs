using System;
//  En el curso hay que colocarlo, aquí no hace falta,
//  ya que aparentemente por la version del .net ya importa DbContext
using Domain;
using Microsoft.EntityFrameworkCore; 


namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) {
            
        }
        
        public DbSet<Value> Values { get; set; }

        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<Value>().HasData(
                new Value {Id = 1, Name = "Value 101 JuanJosé"},
                new Value {Id = 2, Name = "Value 102 Yamilet"},
                new Value {Id = 3, Name = "Value 103 Raúl"},
                new Value {Id = 4, Name = "Value 104 Alberto"}
            );
        }

    }
}
