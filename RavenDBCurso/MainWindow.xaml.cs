using _01___Model;
using System.Windows;

namespace RavenDBCurso
{
    public partial class MainWindow : Window
    {

        public string idDoClienteSalvo { get; set; }
        public _02___Repositorio.RepositorioGenerico Repositorio { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            Repositorio = new _02___Repositorio.RepositorioGenerico();
            CarregueElementosDoBancoDeDados();
        }
        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            var cliente = ChameOEditorDeCliente(new Cliente);

            Repositorio.Cadastrar(cliente);
            CarregueElementosDoBancoDeDados();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (lstCliente.SelectedItem == null)
            {
                MessageBox.Show("Selecione um Cliente");
                return;
            }
            var cliente = (Cliente)lstCliente.SelectedItem;
            cliente = ChameOEditorDeCliente(cliente);

            Repositorio.Atualizar(cliente);
            CarregueElementosDoBancoDeDados();
        }

        private  Cliente ChameOEditorDeCliente(Cliente cliente)
        {
            var formCliente = new FormCliente(cliente);
            formCliente.ShowDialog();
            cliente = formCliente.Cliente;
            return cliente;
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if(lstCliente.SelectedItem == null)
            {
                MessageBox.Show("Selecione um Cliente");
                return;
            }
            var cliente = ((Cliente)(lstCliente.SelectedItem));
            Repositorio.Remover(cliente.Id);
            CarregueElementosDoBancoDeDados();
        }

        private void CarregueElementosDoBancoDeDados()
        {
            lstCliente.DataContext = Repositorio.Liste();
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            CarregueElementosDoBancoDeDados();
        }
    }
}
