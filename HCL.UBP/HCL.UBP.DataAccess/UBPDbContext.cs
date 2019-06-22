using HCL.UBP.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCL.UBP.DataAccess
{
    public class UBPDbContext : DbContext
    {
        public UBPDbContext()
            : base("UBPEntities")
        {
            
        }

        #region "DB Tables"
        public DbSet<UserDetails> UserDetails { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region "Custom implementation"
            modelBuilder.Entity<UserDetails>().HasKey(p => p.Id);
            modelBuilder.Entity<UserDetails>().HasIndex(p => p.Username).IsUnique();
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
