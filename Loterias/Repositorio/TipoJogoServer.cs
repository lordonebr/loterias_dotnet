using Loteria.Model;
using Loterias.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loterias.Repositorio
{
    public class TipoJogoServer : ITipoJogoRepositorio
    {
        private ApplicationDbContext _context;

        public TipoJogoServer(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<TipoJogo> GetTiposJogo()
        {
            return _context.TipoJogo.ToList();
        }

        public void AdicionarTipoJogo(TipoJogo tipoJogo)
        {
            this._context.TipoJogo.Add(tipoJogo);
            this._context.Entry(tipoJogo).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            this._context.SaveChanges();
        }

        public void AtualizaTipoJogo(TipoJogo tipoJogo)
        {
            this._context.TipoJogo.Add(tipoJogo);
            this._context.Entry(tipoJogo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this._context.SaveChanges();
        }

        public void ExcluirTipoJogo(string id)
        {
            TipoJogo tipoJogo = GetTipoJogo(id);
            this._context.Entry(tipoJogo).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            this._context.SaveChanges();
        }

        public TipoJogo GetTipoJogo(string id)
        {
            return _context.TipoJogo.Where(tj => tj.Id.ToString().Equals(id)).FirstOrDefault();
        }
    }
}
