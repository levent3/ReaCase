using EntityLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Contexts
{
    public class SqlDbContext: DbContext
    {


        protected IConfiguration Configuration { get; }

        public SqlDbContext(IConfiguration configuration, DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<TrenIstasyon> TrenIstasyonlar { get; set; }
        public DbSet<TrenSefer> TrenSeferler { get; set; }
        //public DbSet<TrenSefer> TrenSeferler { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;Database=ReaCase;Trusted_Connection=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrenSefer>()
                .HasOne(ts => ts.TrenKalkisIstasyon)
                .WithMany(ti => ti.KalkısIstasyonlar)
                .HasForeignKey(ts => ts.TrenKalkisIstasyonId);

            modelBuilder.Entity<TrenSefer>()
                .HasOne(ts => ts.TrenVarisIstasyon)
                .WithMany(ti => ti.VarisIstasyonlar)
                .HasForeignKey(ts => ts.TrenVarisIstasyonId).

                OnDelete(DeleteBehavior.NoAction); ;
        }

    }
}
