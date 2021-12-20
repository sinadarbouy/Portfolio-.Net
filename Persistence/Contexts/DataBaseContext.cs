using Application.Interfaces.Contexts;
using Domain.Attributes;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Persistence.Contexts
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { 
        
        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (entityType.ClrType.GetCustomAttributes(typeof(AuditableAttribute), true).Any()) { 
                    
                    modelBuilder.Entity(entityType.Name).Property<DateTime?>("InsertTime");
                    modelBuilder.Entity(entityType.Name).Property<DateTime?>("UpdateTime");
                    modelBuilder.Entity(entityType.Name).Property<DateTime?>("RemoveTime");
                    modelBuilder.Entity(entityType.Name).Property<bool>("Is Removed");

                }
            }
            base.OnModelCreating(modelBuilder);

            
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(p => p.State == EntityState.Modified ||
                            p.State == EntityState.Added ||
                            p.State == EntityState.Deleted);
            foreach (var item in modifiedEntries)
            {
                var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());
                switch (item.State)
                {
                    case EntityState.Added:
                        if (entityType.FindProperty("InsertTime") != null)
                        {
                            item.Property("InsertTime").CurrentValue = DateTime.Now;
                        }
                        break;
                    case EntityState.Modified:
                        if (entityType.FindProperty("UpdateTime") != null)
                        {
                            item.Property("UpdateTime").CurrentValue = DateTime.Now;
                        }
                        break;
                    case EntityState.Deleted:
                        if (entityType.FindProperty("RemoveTime") != null)
                        {
                            item.Property("RemoveTime").CurrentValue = DateTime.Now;
                        }
                        if (entityType.FindProperty("IsRemoved") != null)
                        {
                            item.Property("IsRemoved").CurrentValue = true;
                        }
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChanges();
        }

    }
}
