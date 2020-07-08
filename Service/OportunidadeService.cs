using erecruta.Dto;
using erecruta.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erecruta.Service
{
    public class OportunidadeService : IOportunidadeService
    {
        private IOportunidadeRepository _oportunidadeRepository;
        public OportunidadeService(IOportunidadeRepository oportunidadeRepository) => _oportunidadeRepository = oportunidadeRepository;

        public void Incluir(Oportunidade oportunidade) => _oportunidadeRepository.Incluir(oportunidade);

        public List<Oportunidade> Listar() => _oportunidadeRepository.Listar();
    }
}
