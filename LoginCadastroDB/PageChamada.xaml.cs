using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LoginCadastroDB.Models;

namespace LoginCadastroDB
{
    /// <summary>
    /// Interação lógica para PageChamada.xam
    /// </summary>
    public partial class PageChamada : Page
    {
        private ConexaoBD _conexao;
        Aluno aluno;
        public PageChamada()
        {
            InitializeComponent();
            _conexao = new ConexaoBD();
            CarregarDados();
        }


        public void CarregarDados()
        {
            List<Aluno> alunos = new List<Aluno>();
            SQLiteConnection conn = _conexao.AbrirConexao();
            string strSql = "SELECT * FROM Aluno";
            using (SQLiteCommand cmd = new SQLiteCommand(strSql, conn))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) //Enquanto há registros de alunos no banco de dadosos transforma em objetos do tipo Aluno 
                    {
                            Aluno aluno = new Aluno
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nome = reader["Nome"].ToString(),
                                Turma = reader["Turma"].ToString(),
                                Responsavel = reader["Responsavel"].ToString()
                            };
                            alunos.Add(aluno);
                        }
                    }
            }
            _conexao.FecharConexao();
            dGChamar.ItemsSource = alunos; //Preenche o ItemSource com os objetos da lista de alunos
        }

        private void BotaoChamar_Click(object sender, RoutedEventArgs e)
        {
            Button chamar = (Button)sender; //as Button
            DataGridRow linha = DataGridRow.GetRowContainingElement(chamar);
            var item = linha.Item as Aluno; 
            WindowCheguei cheguei = new WindowCheguei(item.Nome, item.Responsavel);
            cheguei.Show();
        }


    }
}
