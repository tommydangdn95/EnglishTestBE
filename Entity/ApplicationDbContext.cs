using Microsoft.EntityFrameworkCore;
using RandomShowEnglish.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomShowEnglish.Entity
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<FileUpload> FileUploads { get; set; }
        public DbSet<Word> Words { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Word>()
                .HasOne(l => l.Lesson)
                .WithMany(w => w.Words)
                .HasForeignKey(w => w.LessonId);
        }
    }
}
