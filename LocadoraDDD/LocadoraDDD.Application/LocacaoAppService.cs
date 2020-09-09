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
    public class LocacaoAppService : AppServiceBase<Locacao>, ILocacaoAppService
    {
        private readonly ILocacaoService _locacaoService;

        public LocacaoAppService(ILocacaoService locacaoService)
            : base(locacaoService)
        {
            _locacaoService = locacaoService;
        }

        public IEnumerable<Locacao> BuscarPorCpfCliente(string cpf)
        {
            return _locacaoService.BuscarPorCpfCliente(cpf);
        }
      
    }
}
