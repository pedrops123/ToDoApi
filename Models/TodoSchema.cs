using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace todoApi.Models
{

    ///<summary>
    /// Schema TODO Model 
    ///</summary>
    public class TodoSchema
    {
    
        ///<summary>
        /// Id da tarefa TODO
        ///</summary>
        public int Id { get; set; }
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