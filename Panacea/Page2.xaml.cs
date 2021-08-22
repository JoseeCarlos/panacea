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
using Model;
using Implemetation;
using System.Data;
using System.Data.SqlClient;

namespace Panacea
{
    /// <summary>
    /// Lógica de interacción para Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {

        Enfermedad enfermedad;
        EnfermedadImpl implenfermedad;
        public Page2()
        {
            InitializeComponent();
            btnregis_Click(null, null);
        }

        private void checkagre_Click(object sender, RoutedEventArgs e)
        {
            if (btnagregar.IsEnabled == false)
            {
                btnagregar.IsEnabled = true;
            }
            else
            {
                btnagregar.IsEnabled = false;
            }
        }

        private void checkmodi_Click(object sender, RoutedEventArgs e)
        {
            if (btnmodificar.IsEnabled == false)
            {
                btnmodificar.IsEnabled = true;
                txtid.IsEnabled = true;
            }
            else
            {
                btnmodificar.IsEnabled = false;
                txtid.IsEnabled = false;
            }
        }

        private void checkeli_Click(object sender, RoutedEventArgs e)
        {
            if (btneliminar.IsEnabled == false)
            {
                btneliminar.IsEnabled = true;
                txtid.IsEnabled = true;
            }
            else
            {
                btneliminar.IsEnabled = false;
            }

        }

        private void btnagregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                enfermedad = new Enfermedad(txtnombre.Text,txtdescri.Text,comboramame.Text,1);
                implenfermedad = new EnfermedadImpl();
               int res= implenfermedad.insert(enfermedad);
               
                if (res>0)
                {
                    MessageBox.Show("Registro Insertado con exito");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            btnregis_Click(null, null);
        }

        private void btnregis_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                implenfermedad = new EnfermedadImpl();
               
                
                datalist.ItemsSource = implenfermedad.select().DefaultView;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnmodificar_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                enfermedad = new Enfermedad(int.Parse(txtid.Text), txtnombre.Text, txtdescri.Text, comboramame.Text, 1);
                implenfermedad = new EnfermedadImpl();
             
                int res = implenfermedad.update(enfermedad);
                if (res > 0)
                {
                    MessageBox.Show("Registro Modificado con exito");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            btnregis_Click(null, null);

        }

        private void btneliminar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Esta realmente seguro de eliminar \n Esta accion es Irreversible ", "Alerta ", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                try
                {
                    enfermedad = new Enfermedad(int.Parse(txtid.Text));
                    implenfermedad = new EnfermedadImpl();

                    int res = implenfermedad.delete(enfermedad);
                    if (res>0)
                    {
                        MessageBox.Show("Registro Eliminado");
                    }
                    else
                    {
                        MessageBox.Show("No se Elimino el Registro");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                btnregis_Click(null, null);
            }
        }
    }
}
