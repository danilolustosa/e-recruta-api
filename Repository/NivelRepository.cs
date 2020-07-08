using erecruta.Dto;
using erecruta.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace erecruta.Repository
{
    public class NivelRepository : BaseRepository, INivelRepository
    {
        public NivelRepository(IConfiguration configuration) : base(configuration) { }

        public List<Nivel> ListarByOportunidade(int OportunidadeId)
        {
            const string query = @"
                    SELECT 
	                    T02.Id,
	                    T02.Descricao
                    FROM OportunidadeNivel T01
	                    JOIN Nivel T02 ON T02.Id = T01.NivelId
                    WHERE OportunidadeId = @OportunidadeId
            ";

            using (var con = new SqlConnection(ObterConexao))
            {
                con.Open();
                return con.Query<Nivel>(query, new { OportunidadeId }).ToList();
            }
        }

    }
}
