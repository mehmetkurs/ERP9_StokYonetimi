using Sy.Core.Abstracts;
using Sy.Core.ComplexTypes;
using Sy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sy.DataAccess
{
    public class StokDbContext : DbContext
    {
        public StokDbContext()
            : base("name=MyCon")
        {

        }
        public override int SaveChanges()
        {
            
            {
                //Audit
                if (StockSettings.UserInfo != null)
                {
                    var selectedEntityList = ChangeTracker.Entries()
                        .Where(x => x.Entity is AuditBase && x.State == EntityState.Added);
                    foreach (var item in selectedEntityList)
                    {
                        ((AuditBase)item.Entity).CreatedUser = StockSettings.UserInfo.Email;
                        ((AuditBase)item.Entity).CreatedDate = DateTime.Now;

                    }
                    selectedEntityList = ChangeTracker.Entries()
                        .Where(x => x.Entity is AuditBase && x.State == EntityState.Modified);
                    foreach (var item in selectedEntityList)
                    {
                        ((AuditBase)item.Entity).CreatedUser = StockSettings.UserInfo.Email;
                        ((AuditBase)item.Entity).CreatedDate = DateTime.Now;
                    }
                }

                return base.SaveChanges();
            }
        }

        public virtual DbSet<Product> Products {get;set;}
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ProductStockAction> ProductStockActions { get; set; }
    }
}
