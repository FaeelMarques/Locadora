using AutoMapper;
using LocadoraDDD.Domain.Entities;
using LocadoraDDD.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocadoraDDD.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<FilmeViewModel, Filme>();
            Mapper.CreateMap<GeneroViewModel, Genero>();
            Mapper.CreateMap<LocacaoViewModel, Locacao>();
        }
    }
}