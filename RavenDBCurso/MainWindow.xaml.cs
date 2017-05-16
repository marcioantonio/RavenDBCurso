using _01___Model;
using Model;
using Repositorio;
using System;
using System.Collections.Generic;
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

namespace RavenDBCurso
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string idDoClienteSalvo { get; set; }
        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            var cliente = new Cliente
            {
                Nome = txtNome.Text,
                Cpf = txtCpf.Text,
                Email = txtEmail.Text,
                Telefone = txtTelefone.Text,
                Endereco = new Endereco
                {
                    Pais = txtPais.Text,
                    Estado = txtEstado.Text,
                    Cidade = txtCidade.Text,
                    Logradouro = txtLogradouro.Text,
                    Rua = txtRua.Text,
                    Numero = txtNumero.Text,

                    Complemento = txtComplemento.Text
                }

            };

            var repo = new _02___Repositorio.RepositorioGenerico();
            var idCliente = repo.Cadastrar(cliente);
            idDoClienteSalvo = idCliente;

            MessageBox.Show($"cadastro feito com sucesso{idCliente}");
        }

        private void btnConsulte_Click(object sender, RoutedEventArgs e)
        {
            var repo = new _02___Repositorio.RepositorioGenerico();
            var cliente = repo.Consulte(idDoClienteSalvo);
            MessageBox.Show($"cliente {cliente.Nome} consultado");
        }
    }
}
