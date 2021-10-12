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

        ///<summary>
        /// Construtor da classe
        ///</summary>
        public UpdateTodoValidator()
        {
            dataDbContext = new AppDbContext();

            // Valida se o nome esta em branco.
            RuleFor(r => r.Name).NotEmpty().WithMessage("Descrição do TODO nao pode ficar vazio !");
            // Valida se o bool done  esta nulo.
            RuleFor(r => r.Done).NotNull().WithMessage("Booleano nao pode ser nulo !");
            // Valida se o id esta zerado.
            RuleFor(r=>r.Id).Custom((id,context) => {
                if(id == 0){
                    context.AddFailure("Id nao pode ser 0.");
                }
            });
            // Valida se há outro registro de id diferente , utilizando o mesmo nome informado.
            RuleFor(r => r).Custom((obj,context) => {
                var item = dataDbContext.TodoTable.Where(r => r.Name.Trim() == obj.Name.Trim() && r.Id != obj.Id).FirstOrDefault();
                if(item != null){
                    if (item.Id != 0){
                        context.AddFailure("Descricao todo já existe ! Esta sendo utilizado por outro registro !");
                    }
                }
            });

            // Valida se o id informado existe na base.
            RuleFor(r=>r.Id).Custom((id,context)=>{
                if(id != 0){
                    var registroBanco = dataDbContext.TodoTable.Where(r=>r.Id == id).FirstOrDefault();
                    if(registroBanco == null){
                        context.AddFailure("Registro nao existe , favor incluir um id valido !");
                    }
                }
            });



        }
        
    }
}   