namespace Norbit_Project.Data
{
    using Microsoft.EntityFrameworkCore;
    using Norbit_Project.Models;

    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Category> categories { get; set; } = null!;
        public virtual DbSet<Body> bodies { get; set; } = null!;
        public virtual DbSet<Place> places { get; set; } = null!;
        public virtual DbSet<Component> components { get; set; } = null!;
        public virtual DbSet<User> users { get; set; } = null!;
        public virtual DbSet<Role> roles { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;port=3307;user=root;password=root;database=norbitdb2;",
                    new MySqlServerVersion(new Version(8, 4, 3)));

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Component>()
            .HasKey(c => c.Id);

            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Place>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Body>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Role>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Component>()
                .HasOne<Category>()
                .WithMany()
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<Component>()
                .HasOne<Body>()
                .WithMany()
                .HasForeignKey(c => c.BodyId);

            modelBuilder.Entity<Component>()
                .HasOne<Place>()
                .WithMany()
                .HasForeignKey(c => c.PlaceId);

        }
    }
}
