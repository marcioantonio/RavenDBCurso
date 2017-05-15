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

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            var cliente = new Cliente
            {
                Nome = "msrcio",
                Cpf = "6854651",
                Email = "fkjnvfv@ckvjb.com",
                Telefone = "95126562",
                Endereco = new Endereco
                {
                    Pais = "brazil",
                    Estado = "mg",
                    Cidade = "fronteira",
                    Logradouro = "matinha",
                    Rua = "43",
                    Numero = 200,
                    Complemento = "portão branco"
                }
              
            };

            var repo = new RepositorioGenerico();
            repo.Cadastrar(cliente);

            MessageBox.Show("cadastro feito com sucesso");
        }
    }
}
