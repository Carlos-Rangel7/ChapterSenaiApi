using ChapterSenai.Contexts;
using ChapterSenai.Models;
using System.Linq;

namespace ChapterSenai.Repositories
{
    public class LivroRepository
    {
        private readonly Sqlcontext _context;
        public LivroRepository(Sqlcontext context)
        {
            _context = context;

        }

        public List<Livro> Listar()
        {

            return _context.Livros.ToList();
        }

    }
}
