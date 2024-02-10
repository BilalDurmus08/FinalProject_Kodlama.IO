using Core.Utilites.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites.Results.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool Success, string Message) : base (Success,Message)
        {
            Data = data;
        }
        public DataResult(T data, bool Success) : base (Success)
        {
            Data = data;
        }

        public T Data { get; }

    }


}
