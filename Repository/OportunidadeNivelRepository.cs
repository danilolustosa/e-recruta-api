using erecruta.Dto;
using erecruta.Interface;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace erecruta.Repository
{
    public class OportunidadeNivelRepository : BaseRepository, IOportunidadeNivelRepository
    {
        public OportunidadeNivelRepository(IConfiguration configuration) : base(configuration) { }

        public void Incluir(OportunidadeNivel oportunidadeNivel)
        {
            const string insert = @"
                        INSERT INTO [dbo].[OportunidadeNivel]
                                   ([NivelId]
                                   ,[OportunidadeId])
                             VALUES
                                   (@NivelId
                                   ,@OportunidadeId)
                        ";

            using (var con = new SqlConnection(ObterConexao))
            {
                con.Open();
                con.Execute(insert, oportunidadeNivel);
            }
        }

        public void DeletarByOportunidade(int OportunidadeId)
        {
            const string insert = @"
                            DELETE FROM OportunidadeNivel 
                            WHERE OportunidadeId = @OportunidadeId
                        ";

            using (var con = new SqlConnection(ObterConexao))
            {
                con.Open();
                con.Execute(insert, new
                {
                    OportunidadeId
                });
            }
        }
    }
}
