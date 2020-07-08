using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erecruta.Dto
{
    public class Candidato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string LinkedIn { get; set; }
        public byte[] Curriculo { get; set; }
        public int Classificacao { get; set; }
        public long EstadoId { get; set; }
        public long CidadeId { get; set; }
        public string Observacao { get; set; }
        public bool Situacao { get; set; }
        public int OportunidadeId { get; set; }
        public Estado Estado { get; set; }
        public Cidade Cidade { get; set; }
    }
}
