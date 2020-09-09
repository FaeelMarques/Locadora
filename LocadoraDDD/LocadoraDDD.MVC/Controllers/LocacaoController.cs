using AutoMapper;
using LocadoraDDD.Application.Interface;
using LocadoraDDD.Domain.Entities;
using LocadoraDDD.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocadoraDDD.MVC.Controllers
{
    [Authorize]
    public class LocacaoController : Controller
    {
        private readonly ILocacaoAppService _locacaoService;
        private readonly IFilmeAppService _filmeService;
        private readonly ILocacaoFilmesAppService _locFilmesService;

        public LocacaoController()
        {

        }

        public LocacaoController(ILocacaoAppService locacaoService, IFilmeAppService filmeService, ILocacaoFilmesAppService locFilmesService)
        {
            _locacaoService = locacaoService;
            _filmeService = filmeService;
            _locFilmesService = locFilmesService;
        }

        //ActionResult da homepage de locacao, trazendo a lista de locação já cadastrados.
        public ActionResult Index(string cpf = "")
        {
            var locacaos = Mapper.Map<IEnumerable<Locacao>, IEnumerable<LocacaoViewModel>>(_locacaoService.BuscarPorCpfCliente(cpf));
            ViewBag.Search = cpf;
            return View(locacaos);
        }


        //ActionResult para redirecionar para cadastro da locação.
        public ActionResult Cadastrar()
        {
            ViewBag.Filmes = _filmeService.GetAll();
            return View();
        }


        //ActionResult para salvar no banco a locação.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(LocacaoViewModel viewModel, List<int> idFilmes)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var locacao = Mapper.Map<Locacao>(viewModel);
                    locacao.DataLocacao = DateTime.Now;
                    _locacaoService.Add(locacao);

                    foreach (var item in idFilmes)
                    {
                        _locFilmesService.Add(new LocacaoFilmes
                        {
                            LocacaoId = locacao.Id,
                            FilmeId = item
                        });
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View(viewModel);
        }

        //ActionResult para retornar os detalhes.
        public ActionResult Detalhes(int id)
        {
            var locacao = Mapper.Map<Locacao, LocacaoViewModel>(_locacaoService.GetById(id));

            List<Filme> listaFilmes = new List<Filme>();

            foreach (var item in locacao.LocacaoFilmes)
            {
                var filme = _filmeService.GetById(item.FilmeId);
                listaFilmes.Add(filme);
            }

            ViewBag.Filmes = listaFilmes;
            if (locacao == null)
            {
                return HttpNotFound();
            }
            return View(locacao);
        }

        //ActionResult que redireciona para edição da locação.
        //public ActionResult Editar(int id)
        //{
        //    var locacao = Mapper.Map<Locacao, LocacaoViewModel>(_locacaoService.GetById(id));
        //    if (locacao == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.Filmes = _filmeService.GetAll();
        //    return View(locacao);
        //}


        ////ActionResult para atualizar no banco a locação.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Editar(LocacaoViewModel viewModel, List<int> idFilmes)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var locacao = Mapper.Map<Locacao>(viewModel);

        //            if (idFilmes != null)
        //            {
        //                foreach (var item in idFilmes)
        //                {
        //                    //var locacaoFilme = _locFilmesService.GetById(item);
        //                    //_locFilmesService.


        //                    _locFilmesService.Add(new LocacaoFilmes
        //                    {
        //                        LocacaoId = locacao.Id,
        //                        FilmeId = item
        //                    });
        //                }
        //            }

        //            _locacaoService.Update(locacao);
        //            return RedirectToAction("Index");
        //        }
        //        catch (Exception ex)
        //        {
        //            throw;
        //        }
        //    }
        //    ViewBag.Filmes = _filmeService.GetAll();
        //    return View(viewModel);
        //}

        ////ActionResult para remover do banco a locação.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Excluir(int id)
        //{
        //    try
        //    {
        //        var locacao = Mapper.Map<Locacao>(_locacaoService.GetById(id));
        //        _locacaoService.Remove(locacao);
        //        return Json(new { ok = true });
        //    }
        //    catch (Exception e)
        //    {
        //        return Json(new { ok = false });
        //    }
        //}


        ////ActionResult para bloquear a locação.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Bloquear(int id)
        //{
        //    try
        //    {
        //        var locacao = Mapper.Map<Locacao>(_locacaoService.GetById(id));

        //        locacao.Ativo = false;
        //        _locacaoService.Update(locacao);
        //        return Json(new { ok = true });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { ok = false });
        //    }

        //}

        ////ActionResult para desbloquear a locacao.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Liberar(int id)
        //{
        //    try
        //    {
        //        var locacao = Mapper.Map<Locacao>(_locacaoService.GetById(id));

        //        locacao.Ativo = true;
        //        _locacaoService.Update(locacao);
        //        return Json(new { ok = true });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { ok = false });
        //    }

        //}
    }
}