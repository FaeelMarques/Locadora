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
    public class FilmeAppService : AppServiceBase<Filme>, IFilmeAppService
    {
        private readonly IFilmeService _filmeService;

        public FilmeAppService(IFilmeService filmeService)
            : base(filmeService)
        {
            _filmeService = filmeService;
        }
        public IEnumerable<Filme> BuscarPorTitulo(string name)
        {
            return _filmeService.BuscarPorTitulo(name);
        }

    }
}
