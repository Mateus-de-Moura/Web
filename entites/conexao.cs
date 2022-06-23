using Dapper;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace WebTeste.entites
{
    public class conexao
    {

        string conect = @"Data Source=DESKTOP-GPICHSB\SQLEXPRESS;Initial Catalog=DB_LOGIN;Integrated Security=True";


        public bool ConsultarUsuario(string usu, string psw)
        {
            var con = new SqlConnection(conect);

            bool retorno = false;
            try
            {
                con.Open();
                string query = $"select * from TB_Login where usuario = '{usu}' and senha ='{psw}'";         
               
                var usuario = con.Query(query);
                if (usuario.Count() > 0)
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
                
            }
            catch (Exception )
            {

                throw;
            }
            finally
            {
                con.Close();
            }

            return retorno;
        }
    }
}
