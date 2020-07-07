using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace LogSystem.Entities
{
    public class LogContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public LogContext(DbContextOptions<LogContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           //optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(m => m.DeletedDate == null);
            modelBuilder.Entity<Role>().HasQueryFilter(m => m.DeletedDate == null);
            modelBuilder.Entity<Company>().HasQueryFilter(m => m.DeletedDate == null);
            modelBuilder.Entity<Service>().HasQueryFilter(m => m.DeletedDate == null);
            modelBuilder.Entity<CompanyService>().HasQueryFilter(m => m.DeletedDate == null);
            modelBuilder.Entity<Request>().HasQueryFilter(m => m.DeletedDate == null);

            modelBuilder.Entity<Role>()
                .HasMany(c => c.Users)
                .WithOne(e => e.Role)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CompanyService>()
                .HasKey(cs => new { cs.CompanyServiceId });

            modelBuilder.Entity<CompanyService>()
                .HasOne(cs => cs.Company)
                .WithMany(c => c.CompanyServices)
                .HasForeignKey(cs => cs.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CompanyService>()
               .HasOne(cs => cs.Service)
               .WithMany(s => s.CompanyServices)
               .HasForeignKey(cs => cs.ServiceId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Request>()
                .HasOne(r => r.RequestBody)
                .WithOne(rb => rb.Request)
                .HasForeignKey<RequestBody>(rb => rb.RequestId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Request>()
                .HasOne(cs => cs.CompanyService)
                .WithMany(r => r.Requests)
                .HasForeignKey(cs => cs.CompanyServiceId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<CompanyService> CompanyServices { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestBody> RequestBodies { get; set; }
    }
}
