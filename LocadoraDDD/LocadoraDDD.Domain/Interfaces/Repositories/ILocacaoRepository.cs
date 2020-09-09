using LocadoraDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDDD.Domain.Interfaces.Repositories
{
    public interface ILocacaoRepository : IRepositoryBase<Locacao>
    {
        IEnumerable<Locacao> BuscarPorCpfCliente(string cpf);
    }
}
