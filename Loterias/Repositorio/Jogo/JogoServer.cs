using Loteria.Model;
using Loterias.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loterias.Repositorio
{
    public class JogoServer : IJogoRepositorio
    {
        private ApplicationDbContext _context;

        public JogoServer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AdicionarJogo(Jogo jogo)
        {
            this._context.Jogo.Add(jogo);
            this._context.Entry(jogo).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            this._context.SaveChanges();
        }

        public void AtualizaJogo(Jogo jogo)
        {
            this._context.Jogo.Add(jogo);
            this._context.Entry(jogo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this._context.SaveChanges();
        }

        public void ExcluirJogo(string id)
        {
            Jogo jogo = GetJogo(id);
            this._context.Entry(jogo).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            this._context.SaveChanges();
        }

        public Jogo GetJogo(string id)
        {
            _context.TipoJogo.ToList();
            return _context.Jogo.Where(j => j.Id.ToString().Equals(id)).FirstOrDefault();
        }

        public List<Jogo> GetJogos()
        {
            _context.TipoJogo.ToList();
            return _context.Jogo.ToList();
        }

        public List<Jogo> GetMegaSenaJogos()
        {
            _context.TipoJogo.ToList();
            return _context.Jogo.Where(j => j.TipoJogo.Name.Equals("Mega Sena")).ToList();
        }

    }
}
