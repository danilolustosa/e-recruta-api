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

        public int Incluir(Oportunidade oportunidade)
        {
            const string insert = @"
                        INSERT INTO [dbo].[Oportunidade]
                                   ([Titulo]
                                   ,[Empresa]
                                   ,[EstadoId]
                                   ,[CidadeId]
                                   ,[Regiao]
                                   ,[Remuneracao]
                                   ,[Regime]
                                   ,[Posicao]
                                   ,[JobDescription]
                                   ,[Situacao])
                             output INSERTED.Id VALUES
                                   (@Titulo
                                   ,@Empresa
                                   ,@EstadoId
                                   ,@CidadeId
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
                return con.ExecuteScalar<int>(insert, oportunidade);
            }
        }

        public void Alterar(Oportunidade oportunidade)
        {
            const string insert = @"
                    UPDATE [dbo].[Oportunidade]
                       SET [Titulo] = @Titulo
                          ,[Empresa] = @Empresa
                          ,[EstadoId] = @EstadoId
                          ,[CidadeId] = @CidadeId
                          ,[Regiao] = @Regiao
                          ,[Remuneracao] = @Remuneracao
                          ,[Regime] = @Regime
                          ,[Posicao] = @Posicao
                          ,[JobDescription] = @JobDescription
                          ,[Situacao] = @Situacao
                     WHERE [Id] = @Id
            ";

            using (var con = new SqlConnection(ObterConexao))
            {
                con.Open();
                con.Execute(insert, oportunidade);
            }
        }

        public List<Oportunidade> Listar()
        {
            const string query = @"
                    SELECT [Id]
                          ,[Titulo]
                          ,[Empresa]
                          ,[EstadoId]
                          ,[CidadeId]
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

        public Oportunidade Obter(int Id)
        {
            const string query = @"
                    SELECT [Id]
                          ,[Titulo]
                          ,[Empresa]
                          ,[EstadoId]
                          ,[CidadeId]
                          ,[Regiao]
                          ,[Remuneracao]
                          ,[Regime]
                          ,[Posicao]
                          ,[JobDescription]
                          ,[Situacao]
                      FROM [dbo].[Oportunidade]
                      WHERE Id = @Id
            ";

            using (var con = new SqlConnection(ObterConexao))
            {
                con.Open();
                return con.Query<Oportunidade>(query, new { Id }).FirstOrDefault();
            }
        }
    }
}
