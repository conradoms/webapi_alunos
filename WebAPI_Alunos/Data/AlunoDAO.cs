using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Alunos.Models;

namespace WebAPI_Alunos.Data
{
    public class AlunoDAO
    {
        IConfiguration _configuracoes;
        public AlunoDAO(IConfiguration configuracoes)
        {
            _configuracoes = configuracoes;
        }

        public Aluno Obter(string nome)
        {
            using (SqlConnection conn = new SqlConnection(
                _configuracoes.GetConnectionString("connection")))
            {
                return conn.QueryFirstOrDefault<Aluno>(
                        "Select " +
                        "ID, Nome, Sobrenome, Email, Telefone where Nome = @Nome", new { Nome = nome }
                    );
            }
        }
    }
}
