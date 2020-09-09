using LocadoraDDD.Domain.Entities;
using LocadoraDDD.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDDD.Infra.Data.Repositories
{
    public class LocacaoFilmesRepository : RepositoryBase<LocacaoFilmes>, ILocacaoFilmesRepository
    {
    }
}
