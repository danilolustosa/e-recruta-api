using erecruta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erecruta.Dto
{
    public class Oportunidade
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Empresa { get; set; }
        public long EstadoId { get; set; }
        public long CidadeId { get; set; }
        public string Regiao { get; set; }
        public string Remuneracao { get; set; }
        public string Regime { get; set; }
        public string Posicao { get; set; }
        public string JobDescription { get; set; }
        public bool Situacao { get; set; }
        public List<Nivel> Niveis { get; set; }
    }
}
