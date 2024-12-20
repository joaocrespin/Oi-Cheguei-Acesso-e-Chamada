using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace LoginCadastroDB
{

    class ConexaoBD
    {
        private SQLiteConnection conn;
        //TODO: Data source deve ser relativa procurando apenas a DB
        private string stringConexao = "Data Source=\"C:\\Users\\Cliente\\source\\repos\\ProjetoEscola\\ChegouBD.db\"";

        public ConexaoBD() 
        {
            conn = new SQLiteConnection(stringConexao);
        }

        public SQLiteConnection AbrirConexao()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }

        public void FecharConexao()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
