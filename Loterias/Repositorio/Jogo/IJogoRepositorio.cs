﻿using Loteria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loterias.Repositorio
{
    public interface IJogoRepositorio
    {
        public List<Jogo> GetJogos();

        public List<Jogo> GetMegaSenaJogos();
        void AdicionarJogo(Jogo jogo);
        void ExcluirJogo(string id);

        public Jogo GetJogo(string id);
        void AtualizaJogo(Jogo jogo);
    }
}
