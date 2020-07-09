using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loteria.Model;
using Loterias.Repositorio;
using Loterias.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Loterias.Controllers
{
    [Authorize]
    public class JogosController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index([FromServices] IJogoRepositorio jogoRepositorio)
        {
            List<Jogo> jogos = jogoRepositorio.GetJogos();
            return View(jogos);
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        public IActionResult Adicionar([FromServices] ITipoJogoRepositorio tipoJogoRepositorio)
        {
            JogoViewModel vm = new JogoViewModel();
            vm.Jogo = new Jogo();
            vm.Jogo.DataConcurso = DateTime.Now;
            vm.Jogo.PremioAcumulado = PremioAcumulado.NA;

            List<TipoJogo> tipoJogos = tipoJogoRepositorio.GetTiposJogo();
            foreach (TipoJogo item in tipoJogos)
                vm.OptionsTipoJogo.Add(item.Id.ToString(), item.Name);

            return View(vm);
        }

        [HttpGet]
        public IActionResult Detalhar(string id, [FromServices] IJogoRepositorio jogoRepositorio)
        {
            Jogo jogo = jogoRepositorio.GetJogo(id);
            return View(jogo);
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult Adicionar(JogoViewModel jogoVM, [FromServices] IJogoRepositorio jogoRepositorio, [FromServices] ITipoJogoRepositorio tipoJogoRepositorio)
        {
            jogoVM.Jogo.TipoJogo = tipoJogoRepositorio.GetTipoJogo(jogoVM.CodigoTipoJogo);
            jogoRepositorio.AdicionarJogo(jogoVM.Jogo);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        public IActionResult Editar(string id, [FromServices] IJogoRepositorio jogoRepositorio, [FromServices] ITipoJogoRepositorio tipoJogoRepositorio)
        {
            JogoViewModel vm = new JogoViewModel();
            vm.Jogo = jogoRepositorio.GetJogo(id);

            vm.CodigoTipoJogo = vm.Jogo.TipoJogo.Id.ToString();
            List<TipoJogo> tipoJogos = tipoJogoRepositorio.GetTiposJogo();
            foreach (TipoJogo item in tipoJogos)
                vm.OptionsTipoJogo.Add(item.Id.ToString(), item.Name);

            return View(vm);
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult Editar(JogoViewModel jogoVM, [FromServices] IJogoRepositorio jogoRepositorio, [FromServices] ITipoJogoRepositorio tipoJogoRepositorio)
        {
            jogoVM.Jogo.TipoJogo = tipoJogoRepositorio.GetTipoJogo(jogoVM.CodigoTipoJogo);
            jogoRepositorio.AtualizaJogo(jogoVM.Jogo);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        public IActionResult Excluir(string id, [FromServices] IJogoRepositorio jogoRepositorio)
        {
            jogoRepositorio.ExcluirJogo(id);
            return RedirectToAction("Index");
        }
    }
}
