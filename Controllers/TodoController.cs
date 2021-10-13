using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todoApi.Commands;
using todoApi.DAO;
using todoApi.Data;
using todoApi.interfaces;
using todoApi.Models;

namespace todoApi.Controllers
{   
    ///<summary>
    /// Controller TODO 
    ///</summary>
    [ApiController]
    [Route("v1/[controller]")]
    public class TodoController : ControllerBase, IToDoDAO<RetornoDynamicApp<TodoSchema>, RetornoDynamicApp<List<TodoSchema>>,CreateTodoCommand,TodoSchema>
    {
        private ToDoDAO _DAO;

        ///<summary>
        /// Controller TODO 
        ///</summary>
        public TodoController([FromServices] AppDbContext contexto) => _DAO = new ToDoDAO(contexto); 
        
        ///<summary>
        /// End Point  Deleçao 
        ///</summary>
        [HttpDelete("{Id}")]
        public async Task<RetornoDynamicApp<TodoSchema>> Delete([FromRoute] int Id) => await  _DAO.Delete(Id);
        ///<summary>
        /// End Point Listagem geral
        ///</summary>
        [HttpGet]
        public async Task<RetornoDynamicApp<List<TodoSchema>>> Get() => await _DAO.Get();
        ///<summary>
        /// End Point Listagem Por Id
        ///</summary>
        [HttpGet("{Id}")]
        public async Task<RetornoDynamicApp<TodoSchema>> GetById([FromRoute] int Id) => await _DAO.GetById(Id);
        ///<summary>
        /// End Point Cadastro Novo
        ///</summary>
        [HttpPost]
        public  async Task<RetornoDynamicApp<TodoSchema>> Post(CreateTodoCommand PostItem) => await _DAO.Post(PostItem);
        ///<summary>
        /// End Point Atualização Cadastro
        ///</summary>
        [HttpPut]
        public async Task<RetornoDynamicApp<TodoSchema>> Put(TodoSchema PutItem) => await  _DAO.Put(PutItem);
    }

}