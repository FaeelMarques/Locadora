using LocadoraDDD.Domain.Entities;
using LocadoraDDD.Domain.Interfaces.Repositories;
using LocadoraDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDDD.Domain.Services
{
    public class LocacaoFilmesService : ServiceBase<LocacaoFilmes>, ILocacaoFilmesService
    {
        private readonly ILocacaoFilmesRepository _locacaofilmesRepository;
        public LocacaoFilmesService(ILocacaoFilmesRepository locacaofilmesRepository)
            : base(locacaofilmesRepository)
        {
            _locacaofilmesRepository = locacaofilmesRepository;
        }

    }
}
