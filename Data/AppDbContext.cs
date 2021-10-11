using System;
using Microsoft.EntityFrameworkCore;
using todoApi.Models;

namespace  todoApi.Data
{   
    public class AppDbContext :DbContext
    {
        public DbSet<TodoSchema> TodoTable { get; set; }
        protected override void OnConfiguring (DbContextOptionsBuilder options ) 
            => options.UseSqlite("DataSource=app.db;Cache=Shared");



        protected override void OnModelCreating (ModelBuilder builder){
            builder.Entity<TodoSchema>(r=>{
                r.HasKey(p => p.Id);
                r.Property(p =>p.Id).ValueGeneratedOnAdd();
            });
        }
    }


}   