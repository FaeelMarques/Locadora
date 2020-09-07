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
    public class LocacaoService : ServiceBase<Locacao>, ILocacaoService
    {
        private readonly ILocacaoRepository _locacaoRepository;
        public LocacaoService(ILocacaoRepository locacaoRepository)
            : base(locacaoRepository)
        {
            _locacaoRepository = locacaoRepository;
        }

        public IEnumerable<Locacao> BuscarPorCpfCliente(string cpf)
        {
            return _locacaoRepository.BuscarPorCpfCliente(cpf);
        }
    }
}
