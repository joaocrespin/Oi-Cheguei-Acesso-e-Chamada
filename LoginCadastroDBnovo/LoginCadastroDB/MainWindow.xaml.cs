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
            conexaoDB = new ConexaoDB("Data Source = SistemaEscola.db");
            usuario = new Usuario(conexaoDB);
        }

        private void botaoCadastrar_Click(object sender, RoutedEventArgs e)
        {
            /*
            usuario.nome = caixaoNome.Text;
            usuario.senha = caixaoSenha.Text;
            usuario.cpf = Convert.ToInt32(caixaoCPF.Text);
            usuario.contato = Convert.ToInt32(caixaoContato.Text);
            usuario.cargo = caixaoCargo.Text;
            usuario.salvaUsuarios();
            MessageBox.Show("Usuário salvo com sucesso!");
            */
            Usuario teste = new Usuario(conexaoDB)
            {
                nome = "João",
                senha = "123456",
                cpf = 123456789,
                contato = 987654321,
                cargo = "Professor"
            };
            usuario.salvaUsuarios();


        }

        private void botaoListarTabelas_Click(object sender, RoutedEventArgs e)
        {
            var tabelas = conexaoDB.ListarTabelas();
            StringBuilder listaTabelas = new StringBuilder("Tabelas no banco de dados:\n");

            foreach (var tabela in tabelas)
            {
                listaTabelas.AppendLine(tabela);
            }

            if (!tabelas.Contains("Usuarios"))
            {
                MessageBox.Show("A tabela 'Usuarios' não foi encontrada.");
            }
            else
            {
                MessageBox.Show(listaTabelas.ToString());
            }
        }
    }
}

