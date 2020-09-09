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
    //Classe com método específico para locação
    public class LocacaoRepository : RepositoryBase<Locacao>, ILocacaoRepository
    {
        protected readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ProjetoModeloDDD"].ConnectionString;

        //Utilizando Dapper para busca de Locações com base no cpf informado. 
        public IEnumerable<Locacao> BuscarPorCpfCliente(string cpf)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                var Query = "";

                if (!string.IsNullOrEmpty(cpf))
                {
                    Query = "SELECT * FROM dbo.Locacao l WHERE l.CpfCliente = '" + cpf + "'";
                }
                else
                {
                    Query = "SELECT * FROM dbo.Locacao";
                }


                return con.Query<Locacao>(Query);
            }
        }

     
    }
}