﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyPortfolioAPI.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolioAPI
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {

        }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<Home> Homes { get; set; }
        public DbSet<Experience> Experiences {get; set;}
        public DbSet<AboutMe> AboutMe { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Home>().HasData(new Home[] {

                new Home { Id = 1, Language = "english", Label = "Hello", Text = "I am Grzegorz Aszlar", UnderText = "Fullstack Developer" },
                new Home { Id = 2, Language = "polish", Label = "Cześć", Text = "Nazywam się Grzegorz Aszlar", UnderText = "Fullstack Developer" }
            });
            modelBuilder.Entity<AboutMe>().HasData(new AboutMe[] {

                new AboutMe { Id = 1, EnglishDescription= "Template", PolishDescription="Wzor"}
                
            });
            modelBuilder.Entity<Contact>().HasData(new Contact[] {

                new Contact { Id = 1, Linkedin= "", Github= "", Instagram= "", Email="" }

            });
            base.OnModelCreating(modelBuilder);
        }
       
    }
}
