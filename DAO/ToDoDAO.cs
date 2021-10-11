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
    public class ToDoDAO : IToDoDAO<RetornoDynamic<TodoSchema>, RetornoDynamic<List<TodoSchema>>,CreateTodoCommand,TodoSchema>
    {
        private AppDbContext Context;

        ///<summary>
        /// Construtor da classe
        ///</summary>
        public ToDoDAO()
        {
            Context = new AppDbContext();    
        }

/**/
        public RetornoDynamic<TodoSchema> Delete(int Id)
        {
            RetornoDynamic<TodoSchema> ret = new RetornoDynamic<TodoSchema>();
            try
            {
                if(Id != 0){
                    var register = Context.TodoTable.Where(r=>r.Id == Id).FirstOrDefault();
                    Context.TodoTable.Remove(register);
                    Context.SaveChanges();
                    ret.Retorno = register;
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

        public RetornoDynamic<List<TodoSchema>> Get()
        {
            RetornoDynamic<List<TodoSchema>> ret = new RetornoDynamic<List<TodoSchema>>();
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

        public RetornoDynamic<TodoSchema> GetById(int Id)
        {
            RetornoDynamic<TodoSchema> ret = new RetornoDynamic<TodoSchema>();
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

        public RetornoDynamic<TodoSchema> Post(CreateTodoCommand PostItem)
        {
            RetornoDynamic<TodoSchema> ret = new RetornoDynamic<TodoSchema>();
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

        public RetornoDynamic<TodoSchema> Put(TodoSchema PutItem)
        {
            RetornoDynamic<TodoSchema> ret = new RetornoDynamic<TodoSchema>();
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
