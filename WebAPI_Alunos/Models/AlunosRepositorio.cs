using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Alunos.Models
{
    public class AlunosRepositorio : IAlunosRepositorio
    {
        static List<Aluno> ListaAlunos = new List<Aluno>();

        public AlunosRepositorio()
        {
            ListaAlunos.Add(new Aluno() { Nome = "Conrado", Sobrenome = "Silva", Email = "conrado@teste.com", Telefone = "13999922339", Id = "1" });
            ListaAlunos.Add(new Aluno() { Nome = "Simone", Sobrenome = "Santos", Email = "simone@teste.com", Telefone = "13999922546", Id = "2" });
            ListaAlunos.Add(new Aluno() { Nome = "Arihane", Sobrenome = "Souza", Email = "arihane@teste.com", Telefone = "13999945846", Id = "3" });
        }

        public void Adicionar(Aluno item)
        {
            ListaAlunos.Add(item);
        }

        public void Atualizar(Aluno item)
        {
            var itemAtualizar = ListaAlunos.SingleOrDefault(r => r.Id == item.Id);

            if (itemAtualizar != null)
            {
                itemAtualizar.Nome = item.Nome;
                itemAtualizar.Sobrenome = item.Sobrenome;
                itemAtualizar.Email = item.Email;
                itemAtualizar.Telefone = item.Telefone;
            }
        }

        public Aluno Encontrar(string chave)
        {
            return ListaAlunos.FirstOrDefault(r => r.Id == chave);
        }

        public IEnumerable<Aluno> GetTodos()
        {
            //return ListaAlunos;

                
        }

        public void Remover(string Id)
        {
            var itemARemover = ListaAlunos.SingleOrDefault(r => r.Id == Id);
            if (ListaAlunos != null)
            {
                ListaAlunos.Remove(itemARemover);
            }
        }
    }
}
