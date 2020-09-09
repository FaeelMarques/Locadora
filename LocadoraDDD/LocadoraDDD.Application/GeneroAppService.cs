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
    public class GeneroAppService : AppServiceBase<Genero>, IGeneroAppService
    {
        private readonly IGeneroService _generoService;

        public GeneroAppService(IGeneroService generoService)
            : base(generoService)
        {
            _generoService = generoService;
        }

        public IEnumerable<Genero> BuscarPorTitulo(string name)
        {
            return _generoService.BuscarPorTitulo(name);
        }
    }
}
