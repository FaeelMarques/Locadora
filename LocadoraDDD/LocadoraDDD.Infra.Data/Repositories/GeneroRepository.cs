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

            var Query = "";

            if (!string.IsNullOrEmpty(nome))
            {
                Query = "SELECT * From dbo.Genero g Where g.Nome like '%" + nome + "%'";
            }
            else
            {
                Query = "Select * From dbo.Genero";
            }
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                return con.Query<Genero>(Query);
            }
        }
    }
}