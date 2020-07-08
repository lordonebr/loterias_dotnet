using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loteria.Model;
using Loterias.Repositorio;
using Loterias.ViewModel;
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

        [HttpGet]
        public IActionResult Adicionar([FromServices] ITipoJogoRepositorio tipoJogoRepositorio)
        {
            JogoViewModel vm = new JogoViewModel();
            vm.Jogo = new Jogo();
            vm.Jogo.TipoJogo = new TipoJogo();
            vm.Jogo.DataConcurso = DateTime.Now;
            vm.Jogo.PremioAcumulado = PremioAcumulado.NA;

            List<TipoJogo> tipoJogos = tipoJogoRepositorio.GetTiposJogo();
            foreach (TipoJogo item in tipoJogos)
                vm.OptionsTipoJogo.Add(item.Id.ToString(), item.Name);

            return View(vm);
        }

        [HttpPost]
        public IActionResult Adicionar(JogoViewModel jogoVM, [FromServices] IJogoRepositorio jogoRepositorio, [FromServices] ITipoJogoRepositorio tipoJogoRepositorio)
        {
            jogoVM.Jogo.TipoJogo = tipoJogoRepositorio.GetTipoJogo(jogoVM.CodigoTipoJogo);
            jogoRepositorio.AdicionarJogo(jogoVM.Jogo);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(string id, [FromServices] IJogoRepositorio jogoRepositorio)
        {
            jogoRepositorio.ExcluirJogo(id);
            return RedirectToAction("Index");
        }
    }
}
