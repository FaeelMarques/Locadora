using LocadoraDDD.Application.Interface;
using LocadoraDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDDD.Application.Interface
{
    public interface IFilmeAppService : IAppServiceBase<Filme>
    {
        IEnumerable<Filme> BuscarPorTitulo(string name);
    }
}
