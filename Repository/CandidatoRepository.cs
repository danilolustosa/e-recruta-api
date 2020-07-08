using erecruta.Dto;
using erecruta.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace erecruta.Repository
{
    public class CandidatoRepository : BaseRepository, ICandidatoRepository
    {
        public CandidatoRepository(IConfiguration configuration) : base(configuration) { }

        public int Incluir(Candidato candidato)
        {
            const string insert = @"
                        INSERT INTO [dbo].[Candidato]
                                   ([Nome]
                                   ,[Email]
                                   ,[Celular]
                                   ,[LinkedIn]
                                   ,[Curriculo]
                                   ,[Classificacao]
                                   ,[EstadoId]
                                   ,[CidadeId]
                                   ,[Observacao]
                                   ,[Situacao]
                                   ,[OportunidadeId])
                             VALUES
                                   (@Nome
                                   ,@Email
                                   ,@Celular
                                   ,@LinkedIn
                                   ,@Curriculo
                                   ,@Classificacao
                                   ,@EstadoId
                                   ,@CidadeId
                                   ,@Observacao
                                   ,@Situacao
                                   ,@OportunidadeId)
            ";

            using (var con = new SqlConnection(ObterConexao))
            {
                con.Open();
                return con.ExecuteScalar<int>(insert, candidato);
            }
        }

        public void Alterar(Candidato candidato)
        {
            const string insert = @"
                    UPDATE [dbo].[Candidato]
                       SET [Nome] = @Nome
                          ,[Email] = @Email
                          ,[Celular] = @Celular
                          ,[LinkedIn] = @LinkedIn
                          ,[Curriculo] = @Curriculo
                          ,[Classificacao] = @Classificacao
                          ,[EstadoId] = @EstadoId
                          ,[CidadeId] = @CidadeId
                          ,[Observacao] = @Observacao
                          ,[Situacao] = @Situacao
                          ,[OportunidadeId] = @OportunidadeId
                     WHERE Id = @Id
            ";

            using (var con = new SqlConnection(ObterConexao))
            {
                con.Open();
                con.Execute(insert, candidato);
            }
        }

        public List<Candidato> Listar(int OportunidadeId)
        {
            const string query = @"
                    SELECT [Id]
                          ,[Nome]
                          ,[Email]
                          ,[Celular]
                          ,[LinkedIn]
                          ,[Curriculo]
                          ,[Classificacao]
                          ,[EstadoId]
                          ,[CidadeId]
                          ,[Observacao]
                          ,[Situacao]
                          ,[OportunidadeId]
                      FROM [dbo].[Candidato]
                      WHERE Situacao = 1
	                    AND [OportunidadeId] = @OportunidadeId
            ";

            using (var con = new SqlConnection(ObterConexao))
            {
                con.Open();
                return con.Query<Candidato>(query, new { OportunidadeId }).ToList();
            }
        }

        public Candidato Obter(int Id)
        {
            const string query = @"
                        SELECT [Id]
                              ,[Nome]
                              ,[Email]
                              ,[Celular]
                              ,[LinkedIn]
                              ,[Curriculo]
                              ,[Classificacao]
                              ,[EstadoId]
                              ,[CidadeId]
                              ,[Observacao]
                              ,[Situacao]
                              ,[OportunidadeId]
                          FROM [dbo].[Candidato]
                          WHERE Situacao = 1
	                        AND [Id] = @Id
            ";

            using (var con = new SqlConnection(ObterConexao))
            {
                con.Open();
                return con.Query<Candidato>(query, new { Id }).FirstOrDefault();
            }
        }
    }
}
