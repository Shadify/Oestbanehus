namespace WebApi.Controllers
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<ConditionsOfItem> ConditionsOfItems { get; set; }
        public virtual DbSet<ConditionType> ConditionTypes { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartment>()
                .Property(e => e.Side)
                .IsUnicode(false);

            modelBuilder.Entity<Apartment>()
                .Property(e => e.Street)
                .IsFixedLength();

            modelBuilder.Entity<Apartment>()
                .HasMany(e => e.ConditionsOfItems)
                .WithRequired(e => e.Apartment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Apartment>()
                .HasMany(e => e.Persons)
                .WithRequired(e => e.Apartment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Apartment>()
                .HasMany(e => e.Requests)
                .WithRequired(e => e.Apartment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Building>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Building>()
                .Property(e => e.ZipCode)
                .IsUnicode(false);

            modelBuilder.Entity<Building>()
                .Property(e => e.Street)
                .IsUnicode(false);

            modelBuilder.Entity<Building>()
                .HasMany(e => e.Apartments)
                .WithRequired(e => e.Building)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comment>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<Comment>()
                .Property(e => e.PublishedDate)
                .IsUnicode(false);

            modelBuilder.Entity<ConditionsOfItem>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ConditionsOfItem>()
                .Property(e => e.Picture)
                .IsUnicode(false);

            modelBuilder.Entity<ConditionsOfItem>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<ConditionType>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<ConditionType>()
                .HasMany(e => e.ConditionsOfItems)
                .WithRequired(e => e.ConditionType1)
                .HasForeignKey(e => e.ConditionType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.MoveInDate)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.MoveOutDate)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Picture)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Request>()
                .Property(e => e.Author)
                .IsFixedLength();

            modelBuilder.Entity<Request>()
                .Property(e => e.Title)
                .IsFixedLength();

            modelBuilder.Entity<Request>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Request>()
                .Property(e => e.Picture)
                .IsUnicode(false);
        }
    }
}
