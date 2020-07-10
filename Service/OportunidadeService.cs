using erecruta.Common;
using erecruta.Dto;
using erecruta.Interface;
using erecruta.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace erecruta.Service
{
    public class OportunidadeService : IOportunidadeService
    {
        private IOportunidadeRepository _oportunidadeRepository;
        private IOportunidadeNivelRepository _oportunidadeNivelRepository;
        private INivelRepository _nivelRepository;
        private IIBGEService _iBGEService;

        public OportunidadeService(IOportunidadeRepository oportunidadeRepository,
            IOportunidadeNivelRepository oportunidadeNivelRepository,
            INivelRepository nivelRepository, IIBGEService iBGEService) 
        {
            _oportunidadeNivelRepository = oportunidadeNivelRepository;
            _oportunidadeRepository = oportunidadeRepository;
            _nivelRepository = nivelRepository;
            _iBGEService = iBGEService;
        } 

        public ListResponse Salvar(Oportunidade oportunidade) 
        {
            var listResponse = new List<string>();

            //Validando os níveis da oportunidade
            var nivel = oportunidade.Niveis.Find(n => n.Id != "JR" && n.Id != "PL" && n.Id != "SR");
            if (nivel != null)
                listResponse.Add($"Nível '{nivel.Id}' não encontrado.");

            if (listResponse.Count > 0)
                return new ListResponse()
                {
                    Mensagem = "Not found",
                    StatusCode = StatusCodes.Status404NotFound,
                    Erros = listResponse
                };

            if (oportunidade.Titulo == "")
                listResponse.Add($"Título não preenchido.");

            if (oportunidade.Empresa == "")
                listResponse.Add($"Empresa não preenchida.");

            if (oportunidade.EstadoId == 0)
                listResponse.Add($"Estado não preenchido.");

            if (oportunidade.CidadeId == 0)
                listResponse.Add($"Cidade não preenchida.");

            if (oportunidade.Regime == "")
                listResponse.Add($"Regime de contratação não preenchido.");

            if (oportunidade.Regime.Length != 2)
                listResponse.Add($"Regime de contratação deve conter dois caracteres.");

            if (oportunidade.Posicao == "")
                listResponse.Add($"Posição não preenchida.");

            if (oportunidade.Posicao.Length != 2)
                listResponse.Add($"Posição deve conter dois caracteres.");

            if (oportunidade.JobDescription == "")
                listResponse.Add($"Job description não preenchido.");

            if (oportunidade.Niveis.Count > 2)
                listResponse.Add($"Apenas dois níveis são permitidos.");

            if (listResponse.Count > 0)
                return new ListResponse()
                {
                    Mensagem = "Bad request",
                    StatusCode = StatusCodes.Status400BadRequest,
                    Erros = listResponse
                };

            if (oportunidade.DataHoraCriacao == null)
                oportunidade.DataHoraCriacao = DateTime.Now;


            if (oportunidade.Id == 0)
                oportunidade.Id = _oportunidadeRepository.Incluir(oportunidade);
            else
                _oportunidadeRepository.Alterar(oportunidade);

            //Deletando os níveis da oportunidade
            _oportunidadeNivelRepository.DeletarByOportunidade(oportunidade.Id);

            //Inserindo os novos níveis
            oportunidade.Niveis.ForEach(n => {
                _oportunidadeNivelRepository.Incluir(new OportunidadeNivel()
                    { 
                        OportunidadeId = oportunidade.Id,
                        NivelId = n.Id
                    });
            });

            return new ListResponse() { StatusCode = StatusCodes.Status201Created, Mensagem = "Oportunidade salva com sucesso." };
        }

        public ListaOportunidadeResponse Listar()
        {
            var lista = new ListaOportunidadeResponse();
            lista.Oportunidades = _oportunidadeRepository.Listar();            

            if (lista.Oportunidades.Count == 0)
                return new ListaOportunidadeResponse() { StatusCode = StatusCodes.Status404NotFound };

            lista.Oportunidades.ForEach(o => { 
                o.Niveis = _nivelRepository.ListarByOportunidade(o.Id);
                o.Estado = _iBGEService.ObterEstado(o.EstadoId);
                o.Cidade = _iBGEService.ObterCidade(o.CidadeId);
                o.Duracao = (DateTime.Now - o.DataHoraCriacao).RelativeTime();

            });

            lista.StatusCode = StatusCodes.Status200OK;
            return lista;
        } 

        public OportunidadeResponse Obter(int id) 
        {
            var oportunidade = _oportunidadeRepository.Obter(id);            

            if (oportunidade != null)
            {
                oportunidade.Niveis = _nivelRepository.ListarByOportunidade(oportunidade.Id);
                oportunidade.Estado = _iBGEService.ObterEstado(oportunidade.EstadoId);
                oportunidade.Cidade = _iBGEService.ObterCidade(oportunidade.CidadeId);
                TimeSpan timeSpan = (DateTime.Now - oportunidade.DataHoraCriacao);
                oportunidade.Duracao = timeSpan.RelativeTime();
                return new OportunidadeResponse() { Oportunidade = oportunidade, StatusCode = StatusCodes.Status200OK };
            }                
            else
                return new OportunidadeResponse() { StatusCode = StatusCodes.Status404NotFound };
        } 
    }
}
