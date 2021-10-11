using System;
using System.Linq;
using FluentValidation;
using todoApi.Data;
using todoApi.Models;

namespace todoApi.Validators {

    ///<summary>
    /// Validator TODO Update
    ///</summary>
    public class UpdateTodoValidator: AbstractValidator<TodoSchema>
    {
        AppDbContext dataDbContext;

        public UpdateTodoValidator()
        {
            RuleFor(r => r.Name).NotEmpty().WithMessage("Descrição do TODO nao pode ficar vazio !");

            RuleFor(r => r.Done).NotNull().WithMessage("Booleano nao pode ser nulo !");

            RuleFor(r => r).Custom((obj,context) => {
                var item = dataDbContext.TodoTable.Where(r => r.Name.Trim() == obj.Name.Trim() && r.Id != obj.Id).FirstOrDefault();
                if (item.Id != 0){
                    context.AddFailure("Descricao todo já existe !");
                }
            });

            RuleFor(r=>r.Id).Custom((id,context) => {
                if(id == 0){
                    context.AddFailure("Id nao pode ser 0.");
                }
            });


            RuleFor(r=>r.Id).Custom((id,context)=>{
                if(id != 0){
                    var registroBanco = dataDbContext.TodoTable.Where(r=>r.Id == id).FirstOrDefault();
                    if(registroBanco.Id == 0){
                        context.AddFailure("Registro nao existe , favor incluir um id valido !");
                    }
                }
            });



        }
        
    }
}   