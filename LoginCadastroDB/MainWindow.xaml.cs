using Microsoft.Data.Sqlite;
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

namespace LoginCadastroDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ConexaoDB conexaoDB;
        private Usuario usuario;
        public MainWindow()
        {
            InitializeComponent();
            conexaoDB = new ConexaoDB("Data Source=SistemaEscola.db");
            usuario = new Usuario(conexaoDB);
        }

        private void botaoCadastrar_Click(object sender, RoutedEventArgs e)
        {
            using (SqliteConnection conn = new SqliteConnection("Data Source=SistemaEscola.db"))
            {
                conn.Open();
                using (SqliteCommand cmd = new SqliteCommand())
                {
                    cmd.Connection = conn; 
                    string strSQL = "INSERT INTO Usuarios (Nome, CPF, Contato, Cargo) VALUES (@Nome, @CPF, @Contato, @Cargo)";
                    cmd.CommandText = strSQL;
                    cmd.Parameters.AddWithValue("@Nome", caixaoNome.Text);
                    cmd.Parameters.AddWithValue("@CPF", caixaoCPF.Text);
                    cmd.Parameters.AddWithValue("@Contato", caixaoContato.Text);
                    cmd.Parameters.AddWithValue("@Cargo", caixaoCargo.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
