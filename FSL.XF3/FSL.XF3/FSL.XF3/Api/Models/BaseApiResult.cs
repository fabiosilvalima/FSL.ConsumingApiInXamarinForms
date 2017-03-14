using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSL.XF3.Api.Models
{
    public class BaseApiResult<T> : IApiResult<T>
    {
        public BaseApiResult()
        {

        }

        public T Data { get; set; }

        public string Id { get; set; }

        public string Message { get; set; }

        public object ModelState { get; set; }

        public bool Success { get; set; }

        public string Url { get; set; }

        public virtual object Minify()
        {
            return this;
        }
    }
}
