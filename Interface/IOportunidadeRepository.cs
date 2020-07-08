using erecruta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erecruta.Interface
{
    public interface IOportunidadeRepository
    {
        int Incluir(Oportunidade oportunidade);
        void Alterar(Oportunidade oportunidade);
        List<Oportunidade> Listar();
        Oportunidade Obter(int Id);
    }
}
