using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookStoreApp.API.Data
{
    public partial class BookStoreDbContext : IdentityDbContext<ApiUser>
    {
        public BookStoreDbContext()
        {
        }

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // must have this in here when inheriting to IdentityDbContext

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Bio).HasMaxLength(250);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.Isbn)
                    .HasMaxLength(50)
                    .HasColumnName("ISBN");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Summary).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Books_ToTable");
            });

            modelBuilder.Entity<IdentityRole>().HasData(
                    new IdentityRole
                    {
                        Name = "User",
                        NormalizedName = "USER",
                        Id = "2b79bfd2-d7c5-443a-9783-a726b8cc7bb3"
                    },
                    new IdentityRole
                    {
                        Name = "Administrator",
                        NormalizedName = "ADMINISTRATOR",
                        Id = "a92d6035-764d-4ee1-a10a-4bafb5a56bd7"
                    }
                );

            var hasher = new PasswordHasher<ApiUser>();

            modelBuilder.Entity<ApiUser>().HasData(
                    new ApiUser
                    {
                        Id = "1ed5c805-2e71-4d7d-a117-ea00604a884d",
                        Email = "admin@bookstore.com",
                        NormalizedEmail = "ADMIN@BOOKSTORE.COM",
                        UserName = "admin@bookstore.com",
                        NormalizedUserName = "ADMIN@BOOKSTORE.COM",
                        FirstName = "System",
                        LastName = "Admin",
                        PasswordHash = hasher.HashPassword(null, "P@ssword1")
                    },
                    new ApiUser
                    {
                        Id = "d1c84008-c154-4bc4-ab16-90c8a70a41de",
                        Email = "user@bookstore.com",
                        NormalizedEmail = "USER@BOOKSTORE.COM",
                        UserName = "user@bookstore.com",
                        NormalizedUserName = "USER@BOOKSTORE.COM",
                        FirstName = "System",
                        LastName = "User",
                        PasswordHash = hasher.HashPassword(null, "P@ssword1")
                    }
                );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                    new IdentityUserRole<string>
                    {
                        RoleId = "2b79bfd2-d7c5-443a-9783-a726b8cc7bb3",
                        UserId = "d1c84008-c154-4bc4-ab16-90c8a70a41de"
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = "a92d6035-764d-4ee1-a10a-4bafb5a56bd7",
                        UserId = "1ed5c805-2e71-4d7d-a117-ea00604a884d"
                    }
                );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
