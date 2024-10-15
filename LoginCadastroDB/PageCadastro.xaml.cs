using System;
using System.Collections.Generic;
using System.Data.SQLite;
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

namespace LoginCadastroDB
{
    /// <summary>
    /// Interação lógica para PageCadastro.xam
    /// </summary>
    public partial class PageCadastro : Page
    {
        private ConexaoBD _conexao;
        public PageCadastro()
        {
            InitializeComponent();
            _conexao = new ConexaoBD();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //using (SQLiteConnection conn = new SQLiteConnection("Data Source=\"C:\\Users\\Cliente\\source\\repos\\LoginCadastroDB\\ChegouBD.db\""))
            //{
            //    using (SQLiteCommand cmd = new SQLiteCommand())
            //    {
            //        string strSql = "INSERT INTO [User] ([Nome], [Senha]) VALUES ('" +
            //        Caixa1.Text + "', '" +
            //        Caixa2.Text + "')";
            //        cmd.CommandText = strSql;
            //        cmd.Connection = conn;
            //        conn.Open();
            //        cmd.ExecuteNonQuery();
            //        conn.Close();
            //    }
            //}
            try
            {
                SQLiteConnection conn = _conexao.AbrirConexao();
                string strSql = "INSERT INTO [Funcionario] ([Nome], [Senha], [CPF], [Cargo]) VALUES (@Nome, @Senha, @CPF, @Cargo)";
                using (SQLiteCommand cmd = new SQLiteCommand(strSql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", areaNome.Text);
                    cmd.Parameters.AddWithValue("@Senha", areaSenha.Password);
                    cmd.Parameters.AddWithValue("@CPF", areaCPF.Text);
                    cmd.Parameters.AddWithValue("@Cargo", areaCargo.Text);
                    cmd.ExecuteNonQuery();
                }
                _conexao.FecharConexao();
            }
            catch (Exception ex) {
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageLogin());
        }
    }
}
