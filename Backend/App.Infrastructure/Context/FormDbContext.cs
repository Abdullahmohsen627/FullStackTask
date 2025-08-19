using Microsoft.EntityFrameworkCore;
using App.Domain.Entities;

namespace App.Infrastructure.Context
{
    public class FormDbContext : DbContext
    {   
        public FormDbContext(DbContextOptions<FormDbContext> options):base(options)
        {
            
        }
    
        public virtual DbSet<user> Users { get; set; }
        public virtual DbSet<EmailOTP> emailOTPs  { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<user>().HasMany(b => b.EmailOTPs).WithOne(b => b.User).HasForeignKey(b => b.UserId).OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }
    }
    
}
