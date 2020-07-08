using erecruta.Dto;
using erecruta.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erecruta.Service
{
    public class IBGEService : IIBGEService
    {
        private IIBGERepository _ibgeRepository;

        public IBGEService(IIBGERepository ibgeRepository) => _ibgeRepository = ibgeRepository;

        public List<Estado> ListarEstado() => _ibgeRepository.ListarEstado();        
        public List<Cidade> ListarCidade(long idEstado) => _ibgeRepository.ListarCidade(idEstado);
        public Estado ObterEstado(long estadoId) => _ibgeRepository.ObterEstado(estadoId);
        public Cidade ObterCidade(long cidadeId) => _ibgeRepository.ObterCidade(cidadeId);
    }
}
