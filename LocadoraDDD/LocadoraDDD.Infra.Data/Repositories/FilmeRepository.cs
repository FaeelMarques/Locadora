using Dapper;
using LocadoraDDD.Domain.Entities;
using LocadoraDDD.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDDD.Infra.Data.Repositories
{
    //Classe com método específico para filme
    public class FilmeRepository : RepositoryBase<Filme>, IFilmeRepository
    {
        protected readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ProjetoModeloDDD"].ConnectionString;

        //Utilizando Dapper para busca de filmes com base no nome informado.
        public IEnumerable<Filme> BuscarPorTitulo(string nome)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                return con.Query<Filme>("SELECT * FROM dbo.Filme WHERE Nome like '%@nome%'");
            }
        }
    }
}
