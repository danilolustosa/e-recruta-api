using erecruta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erecruta.Interface
{
    public interface IIBGEService
    {
        List<Estado> ListarEstado();        
        List<Cidade> ListarCidade(long idEstado);
        Estado ObterEstado(long estadoId);
        Cidade ObterCidade(long cidadeId);
    }
}
