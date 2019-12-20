using TheCatProject.Models;

namespace TheCatProject.DAL
{
    using System.Data.Entity;

    public partial class CatsContext : DbContext
    {
        public CatsContext()
            : base("name=CatsContext")
        {
        }

        public virtual DbSet<Breed> Breeds { get; set; }
        public virtual DbSet<Cat> Cats { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Personality> Personalities { get; set; }
        public virtual DbSet<PTag> PTags { get; set; }
        public virtual DbSet<Trait> Traits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Breed>()
                .HasMany(e => e.Traits)
                .WithRequired(e => e.Breed)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cat>()
                .HasMany(e => e.PTags)
                .WithRequired(e => e.Cat)
                .HasForeignKey(e => e.CID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cat>()
                .HasMany(e => e.Traits)
                .WithRequired(e => e.Cat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Color>()
                .HasMany(e => e.Traits)
                .WithRequired(e => e.Color)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Personality>()
                .HasMany(e => e.PTags)
                .WithRequired(e => e.Personality)
                .HasForeignKey(e => e.FirstTrait)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Personality>()
                .HasMany(e => e.PTags1)
                .WithRequired(e => e.Personality1)
                .HasForeignKey(e => e.SecondTrait)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Personality>()
                .HasMany(e => e.PTags2)
                .WithRequired(e => e.Personality2)
                .HasForeignKey(e => e.ThirdTrait)
                .WillCascadeOnDelete(false);
        }
    }
}
