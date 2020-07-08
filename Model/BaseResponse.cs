using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace erecruta.Model
{
    public class BaseResponse
    {
        [JsonIgnore]
        public int StatusCode { get; set; }

        public string Mensagem { get; set; }
    }
}
