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
            try
            {
                if (string.IsNullOrWhiteSpace(areaNome.Text) || string.IsNullOrWhiteSpace(areaSenha.Password) || string.IsNullOrWhiteSpace(areaCPF.Text) || string.IsNullOrWhiteSpace(areaCargo.Text))
                {
                    MessageBox.Show("Preencha os campos vazios!");
                }
                else if (areaSenha.Password != areaRepetirSenha.Password)
                {
                    MessageBox.Show("As senhas não coincidem...");
                }
                else if (areaCPF.Text.Length != 11 || !areaCPF.Text.All(char.IsDigit))
                {
                    MessageBox.Show("CPF inválido!");
                }
                else
                {
                    Usuario user = new Usuario(_conexao);
                    user.MetodoCadastro(areaNome.Text, areaSenha.Password, areaCPF.Text, areaCargo.Text);
                    MessageBox.Show("Cadastrado com sucesso!");
                }
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
