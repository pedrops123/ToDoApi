using System;
using Microsoft.EntityFrameworkCore;
using todoApi.Models;

namespace  todoApi.Data
{   
    ///<summary>
    /// Classe de contexto Entity Framework do sistema
    ///</summary>
    public class AppDbContext :DbContext
    {

        ///<summary>
        /// Dbset da tabela TODO
        ///</summary>
        public DbSet<TodoSchema> TodoTable { get; set; }

        ///<summary>
        /// Configuracao do contexto EF
        ///</summary>
        ///<param name="options"> Opçoes do contexto </param>
        protected override void OnConfiguring (DbContextOptionsBuilder options ) 
            => options.UseSqlite("DataSource=app.db;Cache=Shared");


        ///<summary>
        /// Configuracao de inicializacao das models no contexto
        ///</summary>
        ///<param name="builder"> Construtor das configuracoes das models no contexto </param>
        protected override void OnModelCreating (ModelBuilder builder){
            builder.Entity<TodoSchema>(r=>{
                r.HasKey(p => p.Id);
                r.Property(p =>p.Id).ValueGeneratedOnAdd();
            });
        }
    }


}   