using System;
using System.Collections.Generic;

namespace todoApi.Models 
{
    public class RetornoDynamic<T>
    {
        public T Retorno { get; set; }
        public List<string> errors { get; set; } 
    }
}