using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loteria.Model;
using Loterias.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Loterias.Controllers
{
    public class JogosController : Controller
    {
        public IActionResult Index([FromServices] IJogoRepositorio jogoRepositorio)
        {
            List<Jogo> jogos = jogoRepositorio.GetJogos();
            return View(jogos);
        }
    }
}
