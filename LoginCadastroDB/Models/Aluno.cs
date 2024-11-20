using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCadastroDB.Models
{
    class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Turma { get; set; }
        public string Responsavel { get; set; }

        public bool Presente { get; set; }
    }
}
