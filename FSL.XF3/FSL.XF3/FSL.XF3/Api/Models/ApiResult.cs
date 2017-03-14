using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSL.XF3.Api.Models
{
    public sealed class ApiResult<TModel>
    {
        public bool Success { get; set; }
        public TModel Data { get; set; }
    }
}
