using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erecruta.Model
{
    public class ListResponse : BaseResponse
    {
        public List<string> Erros { get; set; }
    }
}
