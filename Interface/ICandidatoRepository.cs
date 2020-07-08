using erecruta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erecruta.Interface
{
    public interface ICandidatoRepository
    {
        int Incluir(Candidato candidato);
        void Alterar(Candidato candidato);
        public List<Candidato> Listar(int OportunidadeId);
        public Candidato Obter(int Id);
    }
}
