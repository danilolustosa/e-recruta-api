using erecruta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erecruta.Interface
{
    public interface IOportunidadeRepository
    {
        void Incluir(Oportunidade oportunidade);
        List<Oportunidade> Listar();
    }
}
