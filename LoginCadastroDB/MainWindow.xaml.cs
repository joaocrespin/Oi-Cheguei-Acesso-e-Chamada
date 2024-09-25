using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;


namespace LoginCadastroDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SQLiteConnection _connection;
        public MainWindow()
        {
            InitializeComponent();
            Conexao();
        }

        private void Conexao()
        {
            _connection = new SQLiteConnection("Data Source=EscolaDB.db; Version=3;");
            _connection.Open();
        }

        private void botaoCadastrar_Click(object sender, RoutedEventArgs e)
        {
            string usuario = caixaNome.Text;
            string senha = caixaSenha.Password; 
            string cpf = caixaCpf.Text;
            string cargo = caixaCargo.Text;
            string contato = caixaContato.Text;

            string inserirDados = "INSERT INTO Usuarios (Nome, Senha, CPF, Cargo, Contato) VALUES(@nome, @senha, @cpf, @cargo, @contato)";
            SQLiteCommand mandaDados = new SQLiteCommand(inserirDados, _connection);
            mandaDados.Parameters.AddWithValue("@nome", usuario);
            mandaDados.Parameters.AddWithValue("@senha", senha);
            mandaDados.Parameters.AddWithValue("@cpf", cpf);
            mandaDados.Parameters.AddWithValue("@cargo", cargo);
            mandaDados.Parameters.AddWithValue("@contato", contato);

            try
            {
                mandaDados.ExecuteNonQuery();
                MessageBox.Show("Dados salvos com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }
    }
}