using Microsoft.EntityFrameworkCore;
using university_management_service.srcs.Core.Entities;

namespace university_management_service.srcs.Insfastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Student> Students { get; set; }
    public DbSet<Certifications> Certifications { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Lecture> Lectures { get; set; }
    public DbSet<Module> Modules { get; set; }
    public DbSet<Result> Results { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Student configuration
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.NIC);
            entity.HasIndex(e => e.Email).IsUnique();
        });
        
        // Certifications configuration
        modelBuilder.Entity<Certifications>(entity =>
        {
            entity.HasKey(e => e.CertificationId);
            entity.HasOne(e => e.Student)
                .WithMany(s => s.Certifications)
                .HasForeignKey(e => e.StudentNIC)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        // Result configuration
        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasKey(e => e.ResultId);
            entity.HasOne(e => e.Student)
                .WithMany(s => s.Results)
                .HasForeignKey(e => e.StudentNIC)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
