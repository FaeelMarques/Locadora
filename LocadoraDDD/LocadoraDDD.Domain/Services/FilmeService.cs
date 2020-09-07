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
    public class FilmeService : ServiceBase<Filme>, IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;
        public FilmeService(IFilmeRepository filmeRepository)
            : base(filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public IEnumerable<Filme> BuscarPorTitulo(string titulo)
        {
            return _filmeRepository.BuscarPorTitulo(titulo);
        }
    }
}
