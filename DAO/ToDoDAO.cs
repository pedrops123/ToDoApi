using System;
using System.Collections.Generic;
using System.Linq;
using todoApi.Commands;
using todoApi.Data;
using todoApi.interfaces;
using todoApi.Models;
using todoApi.Validators;

namespace todoApi.DAO
{

    ///<summary>
    /// Classe DAO TODO
    ///</summary>
    public class ToDoDAO : IToDoDAO<RetornoDynamicApp<TodoSchema>, RetornoDynamicApp<List<TodoSchema>>,CreateTodoCommand,TodoSchema>
    {
        private AppDbContext Context;

        ///<summary>
        /// Construtor da classe
        ///</summary>
        public ToDoDAO()
        {
            Context = new AppDbContext();    
        }


        public RetornoDynamicApp<TodoSchema> Delete(int Id)
        {
            RetornoDynamicApp<TodoSchema> ret = new RetornoDynamicApp<TodoSchema>();
            try
            {
                if(Id != 0){
                    var register = Context.TodoTable.Where(r=>r.Id == Id).FirstOrDefault();
                    if(register != null){
                        Context.TodoTable.Remove(register);
                        Context.SaveChanges();
                        ret.Retorno = register;
                    }
                    else 
                    {
                        ret.errors.Add("Registro nao encontrado !");
                    }
                }
                else
                {
                    ret.errors.Add("Id não pode ser 0");
                }
                return ret;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public RetornoDynamicApp<List<TodoSchema>> Get()
        {
            RetornoDynamicApp<List<TodoSchema>> ret = new RetornoDynamicApp<List<TodoSchema>>();
           try
           {
               ret.Retorno = Context.TodoTable.ToList(); 
           }
           catch (Exception e)
           {
               
               throw e;
           }

           return ret;
        }

        public RetornoDynamicApp<TodoSchema> GetById(int Id)
        {
            RetornoDynamicApp<TodoSchema> ret = new RetornoDynamicApp<TodoSchema>();
            try
            {
                if(Id != 0){
                    ret.Retorno = Context.TodoTable.Where(r=>r.Id == Id).FirstOrDefault();
                    return  ret;
                }
                else
                {
                    ret.errors.Add("Id nao pode ser 0.");
                }
           
            }
            catch (Exception e)
            {
                throw e;
            }
            return ret;
        }

        public RetornoDynamicApp<TodoSchema> Post(CreateTodoCommand PostItem)
        {
            RetornoDynamicApp<TodoSchema> ret = new RetornoDynamicApp<TodoSchema>();
            try
            {
                CreateTodoValidator validator = new CreateTodoValidator();
                var validacao = validator.Validate(PostItem);
                if(validacao.IsValid){
                    TodoSchema NewTodo = new TodoSchema (){
                            Name = PostItem.Name,
                            Done = PostItem.Done 
                        };
                 Context.TodoTable.Add(NewTodo);
                 Context.SaveChanges();
                 ret.Retorno = NewTodo;                    
                }
                else {
                    validacao.Errors.ForEach(r => ret.errors.Add(r.ErrorMessage));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return ret;
        }

        public RetornoDynamicApp<TodoSchema> Put(TodoSchema PutItem)
        {
            RetornoDynamicApp<TodoSchema> ret = new RetornoDynamicApp<TodoSchema>();
            try
            {
                UpdateTodoValidator validator = new UpdateTodoValidator();
                var validacao = validator.Validate(PutItem);
                if(validacao.IsValid){
                    Context.TodoTable.Update(PutItem);
                    Context.SaveChanges();
                    ret.Retorno = PutItem;
                }
                else
                {
                    validacao.Errors.ForEach(r=> ret.errors.Add(r.ErrorMessage));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return ret;
        }


    }
}
