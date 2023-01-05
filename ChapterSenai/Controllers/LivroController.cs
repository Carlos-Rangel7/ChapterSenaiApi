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

        public LivroController (LivroRepository livroRepository)
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
    }
}
