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

        public Livro BuscarPorId(int id)
        {
            return _context.Livros.Find(id);
        }

        public void Cadastro(Livro l)
        {
            _context.Livros.Add(l);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
           Livro l = _context.Livros.Find(id);
            _context.Livros.Remove(l);
            _context.SaveChanges();
        }

        public void Alterar(int id, Livro l)
        {
            Livro LivroBuscado = _context.Livros.Find(id);

            if (LivroBuscado != null)
            {
                LivroBuscado.Titulo = l.Titulo;
                LivroBuscado.QuantidadePaginas = l.QuantidadePaginas;
                LivroBuscado.Disponivel = l.Disponivel;

                _context.Livros.Update(LivroBuscado);
                _context.SaveChanges();
            }     

        }

    }
}
