using erecruta.Dto;
using erecruta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erecruta.Interface
{
    public interface ICandidatoService
    {
        ListResponse Salvar(Candidato candidato);
        ListaCandidatoResponse Listar(int oportunidadeId);
        CandidatoResponse Obter(int id);
    }
}
