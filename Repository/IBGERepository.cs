using erecruta.Dto;
using erecruta.Interface;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace erecruta.Repository
{
    public class IBGERepository : IIBGERepository
    {
        public List<Estado> ListarEstado()
        {
            var client = new RestClient("https://servicodados.ibge.gov.br/api/v1/localidades/estados");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);

            var lista = JsonConvert.DeserializeObject<List<Estado>>(response.Content);

            return lista;
        }

        public List<Cidade> ListarCidade(long estadoId)
        {
            var client = new RestClient($"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{estadoId.ToString()}/municipios");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);

            var lista = JsonConvert.DeserializeObject<List<Cidade>>(response.Content);

            return lista;
        }

        public Estado ObterEstado(long estadoId)
        {
            var client = new RestClient($"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{estadoId.ToString()}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);

            var estado = JsonConvert.DeserializeObject<Estado>(response.Content);

            return estado;
        }

        public Cidade ObterCidade(long cidadeId)
        {
            var client = new RestClient($"https://servicodados.ibge.gov.br/api/v1/localidades/municipios/{cidadeId.ToString()}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);

            var cidade = JsonConvert.DeserializeObject<Cidade>(response.Content);

            return cidade;
        }

    }
}
