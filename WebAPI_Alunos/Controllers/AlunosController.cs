using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPI_Alunos.Models;

namespace WebAPI_Alunos.Controllers
{
    [Route("api/[controller]")]
    public class AlunosController : Controller
    {
        public IAlunosRepositorio alunosRepo { get; set; }

        public AlunosController(IAlunosRepositorio _repo)
        {
            alunosRepo = _repo;
        }

        [HttpGet]
        public IEnumerable<Aluno> GetTodos()
        {
            return alunosRepo.GetTodos();
        }

        [HttpGet("{id}", Name = "GetContatos")]
        public IActionResult GetPorId(string id)
        {
            var item = alunosRepo.Encontrar(id);
            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Aluno item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            alunosRepo.Adicionar(item);
            return CreatedAtRoute("GetContatos", new { Controller = "Alunos", id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(string id, [FromBody] Aluno item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var alunoObj = alunosRepo.Encontrar(id);
            if (alunoObj == null)
            {
                return NotFound();
            }

            alunosRepo.Atualizar(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Deletar(string id)
        {
            alunosRepo.Remover(id);
        }
    }
}
