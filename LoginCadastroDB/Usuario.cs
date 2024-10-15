using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCadastroDB
{
    class Usuario
    {
        private int id { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }
        public int cpf { get; set; }
        public int contato { get; set; }
        public string cargo { get; set; }

        private ConexaoBD conexao;

        public Usuario(ConexaoBD _conexao)
        {
            this.conexao = _conexao;
        }
    }
}
