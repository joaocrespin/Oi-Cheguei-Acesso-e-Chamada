using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        private void Cadastrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cpf = campoCPF.Text.Replace(".", "").Replace("-", "").Replace(" ", "");
                if (string.IsNullOrWhiteSpace(campoNome.Text) || string.IsNullOrWhiteSpace(campoSenha.Password) || string.IsNullOrWhiteSpace(campoCPF.Text) || string.IsNullOrWhiteSpace(comboBoxCargo.Text))
                {
                    MessageBox.Show("Preencha os campos vazios!");
                }
                else if (campoSenha.Password != campoRepetirSenha.Password)
                {
                    MessageBox.Show("As senhas não coincidem.");
                }
                else if (cpf.Length != 11 || !cpf.All(char.IsDigit))
                {
                    MessageBox.Show("CPF inválido!");
                }
                else
                {
                    Usuario user = new Usuario(_conexao);
                    user.MetodoCadastro(campoNome.Text, campoSenha.Password, cpf, comboBoxCargo.Text);
                    MessageBox.Show("Cadastrado com sucesso!");

                    campoNome.Clear();
                    campoSenha.Clear();
                    campoRepetirSenha.Clear();
                    campoCPF.Clear();
                    comboBoxCargo.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
            }
        }


        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new PageLogin());
        }

        private void CampoCPF_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            // Remove caracteres inválidos
            string text = Regex.Replace(textBox.Text, @"[^\d]", "");
            // Formatando com caracteres especiais
            if (text.Length > 0)
            {
                if (text.Length > 3 && text.Length <= 6)
                    text = $"{text.Substring(0, 3)}.{text.Substring(3, text.Length - 3)}";
                else if (text.Length > 6 && text.Length <= 9)
                    text = $"{text.Substring(0, 3)}.{text.Substring(3, 3)}.{text.Substring(6, text.Length - 6)}";
                else if (text.Length > 9)
                    text = $"{text.Substring(0, 3)}.{text.Substring(3, 3)}.{text.Substring(6, 3)}-{text.Substring(9, text.Length - 9)}";
            }
            textBox.TextChanged -= CampoCPF_TextChanged;
            textBox.Text = text;
            textBox.CaretIndex = textBox.Text.Length;
            textBox.TextChanged += CampoCPF_TextChanged;
        }


    }
}

