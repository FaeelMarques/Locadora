using AutoMapper;
using LocadoraDDD.Domain.Entities;
using LocadoraDDD.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocadoraDDD.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Filme, FilmeViewModel>();
            Mapper.CreateMap<Genero, GeneroViewModel>();
            Mapper.CreateMap<Locacao, LocacaoViewModel>();
        }
    }
}