using erecruta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erecruta.Interface
{
    public interface IIBGERepository
    {
        List<Estado> ListarEstado();        
        List<Cidade> ListarCidade(long estadoId);
        Estado ObterEstado(long estadoId);
        Cidade ObterCidade(long cidadeId);
    }
}
