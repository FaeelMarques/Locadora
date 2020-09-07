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
    //[Authorize]
    public class FilmesController : Controller
    {
        private readonly IFilmeAppService _filmeService;

        public FilmesController(IFilmeAppService filmeService)
        {
            _filmeService = filmeService;
        }

        //ActionResult da homepage de filmes, trazendo a lista de filmes já cadastrados.
        public ActionResult Index()
        {
            var filmes = Mapper.Map<IEnumerable<Filme>, IEnumerable<FilmeViewModel>>(_filmeService.GetAll().Where(f => f.Ativo));
            return View(filmes);
        }


        //ActionResult para redirecionar para cadastro do filme.
        public ActionResult Cadastrar()
        {
            return View();
        }


        //ActionResult para salvar no banco o filme.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(FilmeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var filme = Mapper.Map<Filme>(viewModel);
                    _filmeService.Add(filme);
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
            var filme = Mapper.Map<Filme, FilmeViewModel>(_filmeService.GetById(id));
            return View(filme);
        }

        //ActionResult que redireciona para edição do filme.
        public ActionResult Editar(int id)
        {
            var filme = Mapper.Map<Filme, FilmeViewModel>(_filmeService.GetById(id));
            return View(filme);
        }


        //ActionResult para atualizar no banco o filme.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(FilmeViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var filme = Mapper.Map<Filme>(viewModel);
                    _filmeService.Update(filme);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View(viewModel);
        }

        //ActionResult para remover do banco o filme.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(int id)
        {
            try
            {
                var filme = Mapper.Map<Filme>(_filmeService.GetById(id));
                _filmeService.Remove(filme);
                return Json(new { ok = true });
            }
            catch (Exception e)
            {
                return Json(new { ok = false });
            }
        }

        //ActionResult para remover múltiplos filmes do banco.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirMultiplos(List<int> idFilmes)
        {
            try
            {
                foreach (var id in idFilmes)
                {
                    var filme = Mapper.Map<Filme>(_filmeService.GetById(id));
                    _filmeService.Remove(filme);
                }
                return Json(new { ok = true });
            }
            catch (Exception e)
            {
                return Json(new { ok = false });
            }
        }



        //ActionResult para bloquear o filme.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Bloquear(int id)
        {
            try
            {
                var filme = Mapper.Map<Filme>(_filmeService.GetById(id));

                filme.Ativo = false;
                _filmeService.Update(filme);
                return Json(new { ok = true });
            }
            catch (Exception ex)
            {
                return Json(new { ok = false });
            }

        }

        //ActionResult para desbloquear o filme.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Liberar(int id)
        {
            try
            {
                var filme = Mapper.Map<Filme>(_filmeService.GetById(id));

                filme.Ativo = true;
                _filmeService.Update(filme);
                return Json(new { ok = true });
            }
            catch (Exception ex)
            {
                return Json(new { ok = false });
            }

        }

    }
}