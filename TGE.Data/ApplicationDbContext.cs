using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TGE.Data.Entites;
using TGE.Data.Entities;

namespace TGE.Data;

public class ApplicationDbContext : IdentityDbContext<UserEntity, IdentityRole<int>, int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options){}


    public DbSet<PostEntity> Posts {get; set;} = null!;
    public DbSet<CommentEntity> Comments {get; set;} = null!;
    public DbSet<ReplyEntity> Replies {get; set;} = null!;

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     base.OnModelCreating(modelBuilder);


    //     modelBuilder.Entity<UserEntity>().ToTable("Users");
    //     modelBuilder.Entity<PostEntity>().HasOne(n => n.Author).WithMany(u => u.Posts).HasForeignKey(n => n.AuthorId);
    //     modelBuilder.Entity<CommentEntity>().HasOne(n => n.Author).WithMany().HasForeignKey(n => n.AuthorId);
    //     modelBuilder.Entity<CommentEntity>().HasOne(n => n.Post).WithMany(u => u.Comments).HasForeignKey(n => n.PostId);
    //     modelBuilder.Entity<ReplyEntity>().HasOne(n => n.Author).WithMany().HasForeignKey(n => n.AuthorId);
    //     modelBuilder.Entity<ReplyEntity>().HasOne(n => n.Parent).WithMany().HasForeignKey(n => n.ParentId);
    //     modelBuilder.Entity<PostEntity>().HasOne(n => n.Author).HasForeignKey(n => n.AuthorId);
    // }

}