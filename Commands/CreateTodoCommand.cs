using System;

namespace todoApi.Commands
{
    ///<summary>
    /// Classe de criação TODO
    ///</summary>
    public class CreateTodoCommand {
        ///<summary>
        /// Nome da tarefa TODO
        ///</summary>
        public string Name { get; set; }
        ///<summary>
        /// Tarefa completa ou não
        ///</summary>
        public bool Done { get; set; }
    }
    
}