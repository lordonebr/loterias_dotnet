﻿using Loteria.Model;
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

        public List<Jogo> GetJogos()
        {
            return _context.Jogo.ToList();
        }

        public List<Jogo> GetMegaSenaJogos()
        {
            throw new NotImplementedException();
        }
    }
}
