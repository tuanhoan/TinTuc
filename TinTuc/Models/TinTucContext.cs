using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TinTuc.Models
{
    public partial class TinTucContext : DbContext
    {
        public TinTucContext()
            : base("name=TinTucContext")
        {
        }

        public virtual DbSet<Theloaitin> Theloaitins { get; set; }
        public virtual DbSet<Tintuc> Tintucs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
