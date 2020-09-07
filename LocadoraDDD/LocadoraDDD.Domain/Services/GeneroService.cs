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
    public class GeneroService : ServiceBase<Genero>, IGeneroService
    {
        private readonly IGeneroRepository _generoRepository;
        public GeneroService(IGeneroRepository generoRepository)
            : base(generoRepository)
        {
            _generoRepository = generoRepository;
        }

        public IEnumerable<Genero> BuscarPorTitulo(string titulo)
        {
            return _generoRepository.BuscarPorTitulo(titulo);
        }
    }
}
