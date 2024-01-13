using EntityLayer.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccessLayer
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<EmotionResult> EmotionResults { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Post sınıfındaki Writer özelliği ile AppUser sınıfı arasında bir ilişki belirleme
            modelBuilder.Entity<Post>()
                .HasOne(p => p.Writer)
                .WithMany()
                .HasForeignKey(p => p.WriterId);

            // EmotionResult sınıfındaki Posts koleksiyonu ile Post sınıfı arasında bir ilişki belirleme
            modelBuilder.Entity<EmotionResult>()
                .HasMany(e => e.Posts)
                .WithOne(p => p.EmotionResult)
                .HasForeignKey(p => p.EmotionResultId);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-R25IHH5\\MSSQLSERVER044;Initial Catalog=TermProjectDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}