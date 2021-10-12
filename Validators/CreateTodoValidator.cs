using System;
using System.Linq;
using FluentValidation;
using todoApi.Commands;
using todoApi.Data;

namespace todoApi.Validators
{
    ///<summary>
    /// Validator TODO Create
    ///</summary>
    public class CreateTodoValidator:AbstractValidator<CreateTodoCommand>
    {
        AppDbContext dataDbContext;
        ///<summary>
        /// Construtor Validador
        ///</summary>
        public CreateTodoValidator()
        {
            dataDbContext = new AppDbContext();
            // Valida se o nome esta em branco.
            RuleFor(r => r.Name).NotEmpty().WithMessage("Descrição do TODO nao pode ficar vazio !");
            // Valida se o bool done  esta nulo.
            RuleFor(r => r.Done).NotNull().WithMessage("Booleano nao pode ser nulo !");
            // Valida se há um registro na base com o mesmo nome enviado.
            RuleFor(r => r.Name).Custom((nome,context) => {
                
                var item = dataDbContext.TodoTable.Where(r=>r.Name.Trim() == nome.Trim()).FirstOrDefault();
                if (item != null){
                    context.AddFailure("Descricao todo já existe !");
                }
                
            });
        }

        
    }
    
}