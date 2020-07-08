using erecruta.Dto;
using erecruta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erecruta.Interface
{
    public interface IOportunidadeService
    {
        ListResponse Salvar(Oportunidade oportunidade);
        ListaOportunidadeResponse Listar();
        OportunidadeResponse Obter(int id);
    }
}
