using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Alunos.Models
{
    public interface IAlunosRepositorio
    {
        void Adicionar(Aluno item);
        IEnumerable<Aluno> GetTodos();
        Aluno Encontrar(string chave);
        void Remover(string Id);
        void Atualizar(Aluno item);
    }
}
