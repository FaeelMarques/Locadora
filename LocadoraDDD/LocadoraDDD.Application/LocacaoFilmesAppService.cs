using LocadoraDDD.Application.Interface;
using LocadoraDDD.Domain.Entities;
using LocadoraDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDDD.Application
{
    public class LocacaoFilmesAppService : AppServiceBase<LocacaoFilmes>, ILocacaoFilmesAppService
    {
        private readonly ILocacaoFilmesService _locacaoFilmesService;

        public LocacaoFilmesAppService(ILocacaoFilmesService locacaoFilmesService)
            : base(locacaoFilmesService)
        {
            _locacaoFilmesService = locacaoFilmesService;
        }

    }
}
