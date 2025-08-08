using Microsoft.EntityFrameworkCore;
using TaskFullStack.Models;

namespace TaskFullStack.Context
{
    public class Data : DbContext
    {   
        public Data(DbContextOptions<Data> options):base(options)
        {
            
        }
    
        public virtual DbSet<user> Users { get; set; }
        public virtual DbSet<EmailOTP> emailOTPs  { get; set; }
    }
}
