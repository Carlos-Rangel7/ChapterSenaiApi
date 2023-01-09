using ChapterSenai.Models;
using ChapterSenai.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChapterSenai.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly LivroRepository _LivroRepository;

        public LivroController(LivroRepository livroRepository)
        {
            _LivroRepository = livroRepository;
        }

        [HttpGet]

        public IActionResult Ler()
        {
            try
            {
                return Ok(_LivroRepository.Listar());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }


        [HttpGet("{id}")]

        public IActionResult BuscarPorId(int id)
        {

            try
            {

                Livro livroBuscado = _LivroRepository.BuscarPorId(id);

                if (livroBuscado == null)
                {
                    return NotFound("Nã");
                }

                return Ok(livroBuscado);


            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Livro l)
        {
            try
            {
                _LivroRepository.Cadastro(l);
                return StatusCode(201);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _LivroRepository.Deletar(id);
                return Ok("Livro Removido com sucesso");
                    
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Livro l) 
        {
            try
            {
                _LivroRepository.Alterar(id, l);
                return StatusCode(204);

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }    

    }
}
