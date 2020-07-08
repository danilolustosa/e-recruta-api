using erecruta.Dto;
using erecruta.Interface;
using erecruta.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erecruta.Service
{
    public class CandidatoService : ICandidatoService
    {
        private ICandidatoRepository _candidatoRepository;

        public CandidatoService(ICandidatoRepository candidatoRepository)
        {
            _candidatoRepository = candidatoRepository;
        }

        public ListResponse Salvar(Candidato candidato)
        {
            var listResponse = new List<string>();

            if (candidato.Nome == "")
                listResponse.Add("Nome não preenchido.");

            if (candidato.Email== "")
                listResponse.Add("E-mail não preenchido.");

            if (candidato.Celular == "")
                listResponse.Add("Celular não preenchido.");

            if (candidato.EstadoId == 0)
                listResponse.Add("Estado não preenchido.");

            if (candidato.CidadeId == 0)
                listResponse.Add("Cidade não preenchida.");

            if (listResponse.Count > 0)
                return new ListResponse()
                {
                    Mensagem = "Bad request",
                    StatusCode = StatusCodes.Status400BadRequest,
                    Erros = listResponse
                };

            if (candidato.Id == 0)
                candidato.Id = _candidatoRepository.Incluir(candidato);
            else
                _candidatoRepository.Alterar(candidato);


            return new ListResponse() { StatusCode = StatusCodes.Status201Created, Mensagem = "Candidato salvo com sucesso." };
        }

        public ListaCandidatoResponse Listar(int oportunidadeId)
        {
            var lista = new ListaCandidatoResponse();
            lista.Candidatos = _candidatoRepository.Listar(oportunidadeId);

            if (lista.Candidatos.Count == 0)
                return new ListaCandidatoResponse() { StatusCode = StatusCodes.Status404NotFound };

            lista.StatusCode = StatusCodes.Status200OK;
            return lista;
        }

        public CandidatoResponse Obter(int id)
        {
            var candidato = _candidatoRepository.Obter(id);

            if (candidato != null)
                return new CandidatoResponse() { Candidato = candidato, StatusCode = StatusCodes.Status200OK };
            else
                return new CandidatoResponse() { StatusCode = StatusCodes.Status404NotFound };
        }
    }
}
