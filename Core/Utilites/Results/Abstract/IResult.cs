using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites.Results.Abstract
{   //Starting fot main voids
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }

}
