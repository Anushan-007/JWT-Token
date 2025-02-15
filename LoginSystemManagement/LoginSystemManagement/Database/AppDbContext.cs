﻿using LoginSystemManagement.Entity;
using Microsoft.EntityFrameworkCore;

namespace LoginSystemManagement.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }


    }
}
