using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebTeste.Models;


namespace WebTeste.entites
{
    public class conexao 
    {
        
        string conectContas = @"Data Source=DESKTOP-GPICHSB\SQLEXPRESS;Initial Catalog=DB_CONTAS;Integrated Security=True";
        string conect_bancoNovo = @"Data Source=DESKTOP-GPICHSB\SQLEXPRESS;Initial Catalog=DB_WEB;Integrated Security=True";


        public bool ConsultarUsuario(string usu, string psw)
        {
            var con = new SqlConnection(conect_bancoNovo);
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
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
            return retorno;
        }
        public IEnumerable<Contas> GetContas()
        {
            var Mes = 4;
            string query = $"select* from TB_CONTAS where MONTH(Vencimento) = {Mes}and year(Vencimento) = DATEPART(year, getdate())";

            var con = new SqlConnection(conectContas);
            con.Open();
            var contas = con.Query<Contas>(query);
            if (contas.Count() > 0)
            {
                return contas;
            }
            con.Close();
            return contas;
        }
        public void Cadastrar(string descricao, float valor, string data, string situacao)
        {
            string query = $"INSERT INTO'Nome da tabela' (descricao,valor,data,situacao) VALUES ('{descricao}',{valor},'{data}','{situacao}') ";

            var con = new SqlConnection();
            con.Open();
            con.Query(query);
            con.Close();

        }
        public void CadastrarUsuario(UsuarioModel UsuarioModel) 
        {
            string query = $"INSERT INTO TB_LOGIN (usuario,senha)VALUES(@USUARIO,@SENHA)";
            var con = new SqlConnection(conect_bancoNovo);
            con.Open();
            con.Execute(query, UsuarioModel);
            con.Close();
        }

    }
}
