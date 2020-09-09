using LocadoraDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDDD.Application.Interface
{
    public interface IGeneroAppService : IAppServiceBase<Genero>
    {
        IEnumerable<Genero> BuscarPorTitulo(string name);
    }
}
