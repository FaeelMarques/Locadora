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
    //Classe com método específico para gênero
    public class GeneroRepository : RepositoryBase<Genero>, IGeneroRepository
    {
        protected readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ProjetoModeloDDD"].ConnectionString;

        //Utilizando Dapper para busca de generos com base no nome informado.
        public IEnumerable<Genero> BuscarPorTitulo(string nome)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                return con.Query<Genero>("SELECT * FROM dbo.Genero WHERE Nome like '%@nome%'");
            }
        }
    }
}
