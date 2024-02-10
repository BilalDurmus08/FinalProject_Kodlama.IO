using Core.Utilites.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites.Results.Concrete
{
    public class SuccessDataResult<T> : DataResult<T> 
    {
        public SuccessDataResult(T data, string Message) : base(data, true, Message)
        {
            
        }

        public SuccessDataResult(T data) : base(data, true)
        {
            
        }

        public SuccessDataResult(string Message) : base(default, true, Message) 
        {
            
        }

        public SuccessDataResult() : base(default, true)
        {
            
        }

    }

}
