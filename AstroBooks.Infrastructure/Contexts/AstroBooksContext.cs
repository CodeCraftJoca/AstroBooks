using AstroBooks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroBooks.Infrastructure.Contexts
{
    public class AstroBooksContext: DbContext
    {
        public AstroBooksContext(DbContextOptions<AstroBooksContext> options) : base(options){}

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da relação muitos-para-muitos entre Book e Author
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Authors)
                .WithMany(a => a.Books)
                .UsingEntity<Dictionary<string, object>>(
                    "BookAuthor",
                    j => j
                        .HasOne<Author>()
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict),
                    j => j
                        .HasOne<Book>()
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                );

            // Configuração da relação muitos-para-muitos entre Book e Genre
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Genres)
                .WithMany(g => g.Books)
                .UsingEntity<Dictionary<string, object>>(
                    "BookGenre",
                    j => j
                        .HasOne<Genre>()
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Restrict),
                    j => j
                        .HasOne<Book>()
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                );

            // Configuração da relação muitos-para-muitos entre Book e Publisher
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Publishers)
                .WithMany(p => p.Books)
                .UsingEntity<Dictionary<string, object>>(
                    "BookPublisher",
                    j => j
                        .HasOne<Publisher>()
                        .WithMany()
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Restrict),
                    j => j
                        .HasOne<Book>()
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                );

            // Definindo chaves primárias
            modelBuilder.Entity<Genre>().HasKey(g => g.Id);
            modelBuilder.Entity<Author>().HasKey(a => a.Id);
            modelBuilder.Entity<Publisher>().HasKey(p => p.Id);
            modelBuilder.Entity<Book>().HasKey(b => b.Id);
        }



    }

}
