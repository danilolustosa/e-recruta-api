using erecruta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erecruta.Model
{
    public class OportunidadeResponse : BaseResponse
    {
        public Oportunidade Oportunidade { get; set; }
    }
}
