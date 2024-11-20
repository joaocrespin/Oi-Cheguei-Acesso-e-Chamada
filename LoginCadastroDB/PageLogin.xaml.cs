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
            try
            {
                if (string.IsNullOrWhiteSpace(campoLogin.Text) || string.IsNullOrWhiteSpace(campoSenha.Password))
                {
                    MessageBox.Show("Preencha os campos vazios!");
                }
                else
                {
                    Usuario user = new Usuario(_conexao);
                    bool sucesso = user.MetodoLogin(campoLogin.Text, campoSenha.Password);
                    if (sucesso)
                    {
                        MessageBox.Show("Login bem sucedido!");
                        this.NavigationService.Navigate(new PageChamada());
                    }
                    else
                    {
                        MessageBox.Show("Login ou senha incorretos!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void areaSenha_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(campoSenha.Password))
            {
                textBlockSenha.Visibility = Visibility.Visible;
            }
            else
            {
                textBlockSenha.Visibility = Visibility.Hidden;
            }
        }

        private void pagCadastro(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageCadastro());

        }

        
    }
}

