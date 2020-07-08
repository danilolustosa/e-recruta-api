using erecruta.Dto;
using erecruta.Interface;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace erecruta.Repository
{
    public class OportunidadeRepository : BaseRepository, IOportunidadeRepository
    {
        public OportunidadeRepository(IConfiguration configuration) : base(configuration) { }

        public void Incluir(Oportunidade oportunidade)
        {
            const string insert = @"
                        INSERT INTO [dbo].[Oportunidade]
                                   ([Id]
                                   ,[Titulo]
                                   ,[Empresa]
                                   ,[EstadoId]
                                   ,[MunicipioId]
                                   ,[Regiao]
                                   ,[Remuneracao]
                                   ,[Regime]
                                   ,[Posicao]
                                   ,[JobDescription]
                                   ,[Situacao])
                             VALUES
                                   (@Id
                                   ,@Titulo
                                   ,@Empresa
                                   ,@EstadoId
                                   ,@MunicipioId
                                   ,@Regiao
                                   ,@Remuneracao
                                   ,@Regime
                                   ,@Posicao
                                   ,@JobDescription
                                   ,@Situacao)
                        ";

            using (var con = new SqlConnection(ObterConexao))
            {
                con.Open();
                con.ExecuteScalar<long>(insert, new
                {
                    oportunidade
                });
            }
        }

        public List<Oportunidade> Listar()
        {
            const string query = @"
                    SELECT [Id]
                          ,[Titulo]
                          ,[Empresa]
                          ,[EstadoId]
                          ,[MunicipioId]
                          ,[Regiao]
                          ,[Remuneracao]
                          ,[Regime]
                          ,[Posicao]
                          ,[JobDescription]
                          ,[Situacao]
                      FROM [dbo].[Oportunidade]
                      WHERE Situacao = 1
            ";

            using (var con = new SqlConnection(ObterConexao))
            {
                con.Open();
                return con.Query<Oportunidade>(query).ToList();
            }
        }
    }
}
