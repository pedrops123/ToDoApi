using System;
using System.Collections.Generic;

namespace todoApi.Models 
{

     
    ///<summary>
    /// Classe de retorno dinamica onde T é o objeto em questão a ser retornado.
    ///</summary>
    public class RetornoDynamicApp<T>
    {

         
        ///<summary>
        /// Construtor da classe
        ///</summary>
        public RetornoDynamicApp()
        {
            this.errors = new List<string>();
        }

        ///<summary>
        /// Retorno dinamico que será exibido
        ///</summary>
        public T Retorno { get; set; }
        ///<summary>
        /// Erros de validacao a ser exibido
        ///</summary>
        public List<string> errors { get; set; } 
    }
}