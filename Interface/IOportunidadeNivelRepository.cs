using erecruta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erecruta.Interface
{
    public interface IOportunidadeNivelRepository
    {
        void Incluir(OportunidadeNivel oportunidadeNivel);
        void DeletarByOportunidade(int OportunidadeId);
    }
}
