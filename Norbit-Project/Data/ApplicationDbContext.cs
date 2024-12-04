namespace Norbit_Project.Data
{
    using Microsoft.EntityFrameworkCore;
    using Norbit_Project.Models;

    public class ApplicationDbContext: DbContext
    {
        public virtual DbSet<Category> categories { get; set; } = null!;
        public virtual DbSet<Body> bodies { get; set; } = null!;
        public virtual DbSet<Place> places { get; set; } = null!;
        public virtual DbSet<Component> components { get; set; } = null!;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;port=3307;user=root;password=root;database=norbitdb;",
                    new MySqlServerVersion(new Version(8, 4, 3)));
          
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Component>();
            modelBuilder.Entity<Category>();
            modelBuilder.Entity<Place>();
            modelBuilder.Entity<Body>();        
        }

    }
}
