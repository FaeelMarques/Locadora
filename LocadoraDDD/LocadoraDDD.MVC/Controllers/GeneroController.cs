﻿using AutoMapper;
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
    public class GeneroController : Controller
    {
        private readonly IGeneroAppService _generoService;

        public GeneroController()
        {

        }
        public GeneroController(IGeneroAppService generoService)
        {
            _generoService = generoService;
        }

        //ActionResult da homepage de gêneros, trazendo a lista de gêneros já cadastrados.
        public ActionResult Index(string name = "")
        {
            var generos = Mapper.Map<IEnumerable<Genero>, IEnumerable<GeneroViewModel>>(_generoService.BuscarPorTitulo(name));
            ViewBag.Search = name;
            return View(generos);
        }


        //ActionResult para redirecionar para cadastro do gênero.
        public ActionResult Cadastrar()
        {
            return View();
        }


        //ActionResult para salvar no banco o gênero.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(GeneroViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    viewModel.DataCriacao = DateTime.Now;
                    var genero = Mapper.Map<Genero>(viewModel);
                    _generoService.Add(genero);
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
            var genero = Mapper.Map<Genero, GeneroViewModel>(_generoService.GetById(id));
            if (genero == null)
            {
                return HttpNotFound();
            }
            return View(genero);
        }

        //ActionResult que redireciona para edição do gênero.
        public ActionResult Editar(int id)
        {
            var genero = Mapper.Map<Genero, GeneroViewModel>(_generoService.GetById(id));
            if (genero == null)
            {
                return HttpNotFound();
            }
            return View(genero);
        }


        //ActionResult para atualizar no banco o gênero.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(GeneroViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var genero = Mapper.Map<Genero>(viewModel);
                    _generoService.Update(genero);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View(viewModel);
        }


        [HttpGet]
        public ActionResult Excluir(int id)
        {
            var genero = Mapper.Map<GeneroViewModel>(_generoService.GetById(id));
            if (genero == null)
            {
                return HttpNotFound();
            }
            return View(genero);
        }

        //ActionResult para remover do banco o gênero.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(GeneroViewModel viewModel)
        {
            try
            {
                var genero = Mapper.Map<Genero>(viewModel);
                _generoService.Remove(genero);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //ActionResult para remover múltiplos gêneros do banco.
        
        public ActionResult ExcluirMultiplos(int[] idGeneros)
        {
            try
            {
                foreach (var id in idGeneros)
                {
                    var genero = Mapper.Map<Genero>(_generoService.GetById(id));
                    _generoService.Remove(genero);
                }
                return Json(new { ok = true });
            }
            catch (Exception e)
            {
                return Json(new { ok = false });
            }
        }



        //ActionResult para bloquear o gênero.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Bloquear(int id)
        {
            try
            {
                var genero = Mapper.Map<Genero>(_generoService.GetById(id));

                genero.Ativo = false;
                _generoService.Update(genero);
                return Json(new { ok = true });
            }
            catch (Exception ex)
            {
                return Json(new { ok = false });
            }

        }

        //ActionResult para desbloquear o gênero.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Liberar(int id)
        {
            try
            {
                var genero = Mapper.Map<Genero>(_generoService.GetById(id));

                genero.Ativo = true;
                _generoService.Update(genero);
                return Json(new { ok = true });
            }
            catch (Exception ex)
            {
                return Json(new { ok = false });
            }

        }

    }
}