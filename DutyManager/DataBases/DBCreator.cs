using DutyManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DutyManager
{
    public class DBCreator :DbContext
    {
        public DBCreator(DbContextOptions<DBCreator> options) : base(options)
        {
            Database.EnsureCreated();
            
        }
        public DbSet<UsersModel> UsersModel { get; set; }
        public DbSet<GroupsModel> GroupModel { get; set; }
        public DbSet<RolesModel> RolesModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersModel>().HasKey(x => x.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
