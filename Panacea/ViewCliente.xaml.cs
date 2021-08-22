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
using System.Windows.Shapes;
using Model;
using Dao;
using Implemetation;

namespace Panacea
{
    /// <summary>
    /// Lógica de interacción para ViewCliente.xaml
    /// </summary>
    public partial class ViewCliente : Window
    {
        Clientes cliente;
        ClientesImpl implCliente;
        public ViewCliente()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cliente = new Clientes(txtnombre.Text,txtPape.Text,txtSeApe.Text,txtCi.Text,Session.SessionId);
                implCliente = new ClientesImpl();

                int res = implCliente.insert(cliente);
                if (res>0)
                {
                    MessageBox.Show("Cliente Resgistrado con Exito");
                    loadData();
                }
                else
                {
                    MessageBox.Show("No se Registro el cliente");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        void loadData()
        {
            try
            {

                implCliente = new ClientesImpl();

                gridClientes.ItemsSource = null;
                gridClientes.ItemsSource = implCliente.select().DefaultView;
                gridClientes.Columns[0].Visibility = Visibility.Collapsed;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadData();
        }

        private void btnsal_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
