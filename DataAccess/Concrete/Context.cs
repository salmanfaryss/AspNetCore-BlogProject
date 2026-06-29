using Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{

    public class Context:IdentityDbContext<AppUser,AppRole,int>
    {
        public DbSet<ToDosLogs> ToDosLogs { get; set; }
        public DbSet<About> abouts { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Blog> blogs { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Writer> writers { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<ToDo> toDos { get; set; }
        public DbSet<NewsLetter> newsLetters { get; set; }
        public DbSet<BlogRating> blogsRating { get; set; }
        public DbSet<Message> messages { get; set; }
        public DbSet<Notification> notification { get; set; }
        public DbSet<Team> team { get; set; }
        public DbSet<Match> match { get; set; }
        public DbSet<Message2> message2 { get; set; }
        public DbSet<Test> test { get; set; }
        public DbSet<Test2> test2 { get; set; }
        public DbSet<Test3> test3 { get; set; }
        public DbSet<Admin> admins { get; set; }
        public DbSet<Test4> test4 { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                .HasOne(x => x.HomeTeam)
                .WithMany(y => y.HomeMatches)
                .HasForeignKey(z => z.HomeTeamID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Match>()
                .HasOne(x => x.GuestTeam)
                .WithMany(y => y.AwayMatches)
                .HasForeignKey(z => z.GuestTeamdID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            //HomeMatches ---> WriterSender
            //AwayMatches ---> WriterReceiver

            //HomeTeam --->SenderUser
            //GuestTeam --->ReceiverUser


            modelBuilder.Entity<Message2>()
                .HasOne(x => x.SenderUser)
                .WithMany(y => y.writerSenderMessage)
                .HasForeignKey(z => z.SenderID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message2>()
                .HasOne(x => x.ReceiverUser)
                .WithMany(y => y.writerReceiverMessage)
                .HasForeignKey(z => z.ReceiverID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder);


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=CoreBlogDb;integrated security=true;");
        }
    }
}
