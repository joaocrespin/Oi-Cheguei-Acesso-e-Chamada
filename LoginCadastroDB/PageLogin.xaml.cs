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
    /// Interação lógica para PageLogin.xam
    /// </summary>
    public partial class PageLogin : Page
    {
        private ConexaoBD _conexao;
        //private MainWindow _mainWindow = new MainWindow();
        public PageLogin()
        {
            InitializeComponent();
            _conexao = new ConexaoBD();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection conn = _conexao.AbrirConexao();
            string strSql = "SELECT COUNT(1) FROM [Funcionario] WHERE [Nome] = @Nome AND [Senha] = @Senha";

            using (SQLiteCommand cmd = new SQLiteCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@Nome", areaNome.Text);
                cmd.Parameters.AddWithValue("@Senha", areaSenha.Password);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 1)
                {
                    MessageBox.Show("Login bem-sucedido!");
                }
                else
                {
                    MessageBox.Show("Nome de usuário ou senha incorretos.");
                }
            }

            _conexao.FecharConexao();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageCadastro());

        }
    }
}

