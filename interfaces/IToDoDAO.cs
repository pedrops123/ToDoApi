using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace todoApi.interfaces
{
    public interface IToDoDAO<T,L,C,U>
    {
        ///<summary>
        /// Coleta dados entity dinamica por Id
        ///</summary>
        ///<param name="Id">Id do registro a ser procurado</param>
        Task<T> GetById(int Id);
        ///<summary>
        /// Coleta lista de dados entity dinamica 
        ///</summary>
        Task<L> Get();
        ///<summary>
        /// Cadastra dado entity dinamica
        ///</summary>
        ///<param name="PostItem">Parametro POST a ser cadastrado no sistema</param>
        Task<T> Post(C PostItem);
        ///<summary>
        /// Atualiza dado entity dinamica  
        ///</summary>
        ///<param name="PutItem">Parametro PUT a ser atualizada no sistema</param>
        Task<T> Put(U PutItem);
        ///<summary>
        /// Deleta dado entity dinamica
        ///</summary>
        ///<param name="Id">Id  a ser deletado no sistema</param>
        Task<T> Delete(int Id);
    }    
}