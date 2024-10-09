using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;


namespace LoginCadastroDB
{
    class Usuario
    {
        private int id { get; set;}
        public string nome { get; set; }
        public string senha { get; set; }
        public int cpf { get; set; }
        public int contato { get; set; }
        public string cargo { get; set; }
            
        private ConexaoDB conexao;

        public Usuario(ConexaoDB _conexao)
        {
            this.conexao = _conexao;
        }

        public void salvaUsuarios()
        {
            using (var _conexao = conexao.pegarConexao())
            {
                if (_conexao.State != ConnectionState.Open)
                {
                    _conexao.Open();
                }
                var mandaDados = new SqliteCommand("INSERT INTO Usuarios (nome, senha, cpf, contato, cargo) VALUES (@Nome, @Senha, @CPF, @Contato, @Cargo)", _conexao);
                mandaDados.Parameters.AddWithValue("@Nome", nome);
                mandaDados.Parameters.AddWithValue("@Senha", senha);
                mandaDados.Parameters.AddWithValue("@CPF", cpf);
                mandaDados.Parameters.AddWithValue("@Contato", contato);
                mandaDados.Parameters.AddWithValue("@Cargo", cargo);
                mandaDados.ExecuteNonQuery();
            }
        }
    }
}
