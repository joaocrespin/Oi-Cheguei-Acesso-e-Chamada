using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace LoginCadastroDB
{
    internal class ConexaoDB
    {
        private string stringConexao;
        private SqliteConnection _conexao;

        //Construtor da conexão B)
        public ConexaoDB(string stringConexao)
        {
            this.stringConexao = stringConexao;
            _conexao = new SqliteConnection(stringConexao);
        }

        public void abreConexão()
        {
            using (_conexao = new SqliteConnection(stringConexao))
            {
                _conexao.Open();
            }
        }
        public void fechaConexao()
        {
            using (_conexao = new SqliteConnection(stringConexao))
            {
                _conexao.Close();
            }
        }

        public SqliteConnection pegarConexao()
        {
            return new SqliteConnection(stringConexao);
        }

        public List<string> ListarTabelas()
        {
            abreConexão();
            List<string> tabelas = new List<string>();

            string query = "SELECT name FROM sqlite_master WHERE type='table';";
            using (var comando = new SqliteCommand(query, _conexao))
            {
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tabelas.Add(reader.GetString(0));
                    }
                }
            }

            fechaConexao();
            return tabelas;

        }

    }
}