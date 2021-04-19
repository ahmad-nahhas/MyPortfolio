using Microsoft.EntityFrameworkCore;
using MyPortfolio.Shared.Entities;
using System;

namespace MyPortfolio.Shared
{
    public class MyPortfolioDbContext : DbContext
    {
        public MyPortfolioDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Owner>().HasData(new Owner
            {
                Id = Guid.NewGuid(),
                FullName = "Ahmet Bakırcı",
                Profile = ".NET Full Stack Web Developer",
                About = "I am a software developer, studying Computer Engineering at Selçuk University in Turkey and I'm so motivated to continue with improving my skills in computer science.",
                Description = "I have experience developing Android apps because I produced many apps which I have published on Google Play Store. I am now starting to develop myself in the field of web applications and my goal is to become a full stack developer.",
                AvatarPath = "avatar.png",
                CVPath = "MyCV.pdf"
            });

            modelBuilder.Entity<Project>().HasData(new Project
            {
                Id = Guid.NewGuid(),
                Name = "Video Statuses",
                Description = "A video status application that contains many videos and beautiful statuses that are constantly updated and also allows users to download videos and share them on social networking sites.",
                ImagePath = "videostatuses.png",
                Link = "https://play.google.com/store/apps/details?id=com.mahwous.videostatuses"
            });

            modelBuilder.Entity<Project>().HasData(new Project
            {
                Id = Guid.NewGuid(),
                Name = "My Statuses",
                Description = "A video status application that contains many videos and beautiful statuses that are constantly updated and also allows users to download videos and share them on social networking sites.",
                ImagePath = "mystatuses.png",
                Link = "https://play.google.com/store/apps/details?id=com.mahwous.mystatuses"
            });

            modelBuilder.Entity<Project>().HasData(new Project
            {
                Id = Guid.NewGuid(),
                Name = "Asia For Stadiums",
                Description = "The website of Asia company for the sale and rental of stadiums in Turkey.",
                ImagePath = "asiacompany.png",
                Link = "https://jx0hwxn75fznewe0qppjwq-on.drv.tw/AsiaSport/"
            });
        }

        public DbSet<Owner> Owner { get; set; }
        public DbSet<Project> Project { get; set; }
    }
}