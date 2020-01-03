namespace TheCatProject.DAL
{
    using System.Data.Entity;
    using TheCatProject.Models;

    public partial class CatsContext : DbContext
    {
        public CatsContext()
            : base("name=CatsContext")
        {
        }

        public virtual DbSet<AnimalFriendliness> AnimalFriendlinesses { get; set; }
        public virtual DbSet<Breed> Breeds { get; set; }
        public virtual DbSet<Cat> Cats { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Lifestyle> Lifestyles { get; set; }
        public virtual DbSet<PeopleFriendliness> PeopleFriendlinesses { get; set; }
        public virtual DbSet<Play> Plays { get; set; }
        public virtual DbSet<Trait> Traits { get; set; }
        public virtual DbSet<Water> Waters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimalFriendliness>()
                .HasMany(e => e.Cats)
                .WithRequired(e => e.AnimalFriendliness)
                .HasForeignKey(e => e.AnimalFriendID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Breed>()
                .HasMany(e => e.Cats)
                .WithRequired(e => e.Breed)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Color>()
                .HasMany(e => e.Cats)
                .WithRequired(e => e.Color)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lifestyle>()
                .HasMany(e => e.Cats)
                .WithRequired(e => e.Lifestyle)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PeopleFriendliness>()
                .HasMany(e => e.Cats)
                .WithRequired(e => e.PeopleFriendliness)
                .HasForeignKey(e => e.PeopleFriendID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Play>()
                .HasMany(e => e.Cats)
                .WithRequired(e => e.Play)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trait>()
                .HasMany(e => e.Cats)
                .WithRequired(e => e.Trait)
                .HasForeignKey(e => e.TraitsID_1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trait>()
                .HasMany(e => e.Cats1)
                .WithRequired(e => e.Trait1)
                .HasForeignKey(e => e.TraitsID_2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trait>()
                .HasMany(e => e.Cats2)
                .WithRequired(e => e.Trait2)
                .HasForeignKey(e => e.TraitsID_3)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Water>()
                .HasMany(e => e.Cats)
                .WithRequired(e => e.Water)
                .WillCascadeOnDelete(false);
        }
    }
}
