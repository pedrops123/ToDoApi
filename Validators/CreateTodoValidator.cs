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

            RuleFor(r => r.Name).NotEmpty().WithMessage("Descrição do TODO nao pode ficar vazio !");

            RuleFor(r => r.Done).NotNull().WithMessage("Booleano nao pode ser nulo !");
            
            RuleFor(r => r.Name).Custom((nome,context) => {
                var item = dataDbContext.TodoTable.Where(r=>r.Name.Trim() == nome.Trim()).FirstOrDefault();
                if (item.Id != 0){
                    context.AddFailure("Descricao todo já existe !");
                }
            });
        }

        
    }
    
}