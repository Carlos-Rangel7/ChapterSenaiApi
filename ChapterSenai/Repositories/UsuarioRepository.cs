﻿using ChapterSenai.Contexts;
using ChapterSenai.Interfaces;
using ChapterSenai.Models;
using System.ComponentModel.DataAnnotations;

namespace ChapterSenai.Repositories
{
    public class UsuarioRepository : IUsuarioRepository // criando herança e tem que trazer aquilo que eu quero que seja a herança
    {
        private readonly Sqlcontext _context; //likando com o banco

        public UsuarioRepository(Sqlcontext context)
        {
            _context = context;
        }

        public void Atualizar(int id, Usuario usuario)
        {
          Usuario usuarioEncontrado = _context.Usuarios.Find(id);

            if (usuarioEncontrado != null)
            {
                usuarioEncontrado.Email= usuario.Email;
                usuarioEncontrado.Senha = usuario.Senha;
                usuarioEncontrado.Tipo = usuario.Tipo;

               _context.Usuarios.Update(usuarioEncontrado); //informando ao banco q deve atualizar tudo que esta dentro do usuarioencontrado
                _context.SaveChanges();

            }

        }

        public Usuario BuscarPorId(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            _context.Usuarios.Add (novoUsuario);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario usuario = _context.Usuarios.Find(id);
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
