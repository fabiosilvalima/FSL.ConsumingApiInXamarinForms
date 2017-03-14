using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSL.XF3.Api.Models
{
    public sealed class OkApiResult<T> : BaseApiResult<T>
    {
        public OkApiResult()
        {
            Success = false;
            ModelState = null;
            Id = null;
        }

        public OkApiResult(T data)
            : this()
        {
            Success = true;
            Data = data;
        }
    }
}
