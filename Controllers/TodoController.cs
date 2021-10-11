using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using todoApi.Commands;
using todoApi.DAO;
using todoApi.interfaces;
using todoApi.Models;

namespace todoApi.Controllers
{   
    ///<summary>
    /// Controller TODO 
    ///</summary>
    [ApiController]
    [Route("v1/[controller]")]
    public class TodoController : ControllerBase, IToDoDAO<RetornoDynamic<TodoSchema>, RetornoDynamic<List<TodoSchema>>,CreateTodoCommand,TodoSchema>
    {
        private ToDoDAO _DAO;

        ///<summary>
        /// Controller TODO 
        ///</summary>
        public TodoController() => _DAO = new ToDoDAO(); 
        
        ///<summary>
        /// End Point Deleçao 
        ///</summary>
        [HttpDelete("{Id}")]
        public RetornoDynamic<TodoSchema> Delete(int Id) => _DAO.Delete(Id);
        ///<summary>
        /// End Point Listagem geral
        ///</summary>
        [HttpGet]
        public RetornoDynamic<List<TodoSchema>> Get() => _DAO.Get();
        ///<summary>
        /// End Point Por Id
        ///</summary>
        [HttpGet("{Id}")]
        public RetornoDynamic<TodoSchema> GetById(int Id) => _DAO.GetById(Id);
        ///<summary>
        /// End Point Cadastro Novo
        ///</summary>
        [HttpPost]
        public RetornoDynamic<TodoSchema> Post(CreateTodoCommand PostItem) => _DAO.Post(PostItem);
        ///<summary>
        /// End Point Atualização Cadastro
        ///</summary>
        [HttpPut]
        public RetornoDynamic<TodoSchema> Put(TodoSchema PutItem) => _DAO.Put(PutItem);
    }

}