namespace DnD.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using DnD.Models;


    public class DnDContext : DbContext
    {

        public DnDContext()
            : base("name=DnDContext")
        {
        }
        public virtual DbSet<Hero> Heroes { get; set; }
        public virtual DbSet<SpecialAbility> SpecialAbilities { get; set; }
        public virtual DbSet<Dragon>  Dragons{ get; set; }
        public virtual DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpecialAbility>().Property(sa => sa.Description).IsOptional();            
        }

    }


}