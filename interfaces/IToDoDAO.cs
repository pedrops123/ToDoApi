using System;
using System.Collections.Generic;

namespace todoApi.interfaces
{
    public interface IToDoDAO<T,L,C,U>
    {
        ///<summary>
        /// Coleta dados entity dinamica por Id
        ///</summary>
        ///<param name="Id">Id do registro a ser procurado</param>
        T GetById(int Id);
        ///<summary>
        /// Coleta lista de dados entity dinamica 
        ///</summary>
        L Get();
        ///<summary>
        /// Cadastra dado entity dinamica
        ///</summary>
        ///<param name="PostItem">Parametro POST a ser cadastrado no sistema</param>
        T Post(C PostItem);
        ///<summary>
        /// Atualiza dado entity dinamica  
        ///</summary>
        ///<param name="PutItem">Parametro PUT a ser atualizada no sistema</param>
        T Put(U PutItem);
        ///<summary>
        /// Deleta dado entity dinamica
        ///</summary>
        ///<param name="Id">Id  a ser deletado no sistema</param>
        T Delete(int Id);
    }    
}