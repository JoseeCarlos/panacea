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
using Implemetation;

namespace Panacea
{
    /// <summary>
    /// Lógica de interacción para ViewDosificacion.xaml
    /// </summary>
    public partial class ViewDosificacion : Window
    {
        Dosificacion dosificacion;
        DosificacionImpl implDosificacion;
        
        public ViewDosificacion()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadDosi();
        }

        void loadDosi()
        {

            try
            {

                implDosificacion = new DosificacionImpl ();

                gridDosificaciones.ItemsSource = null;
                gridDosificaciones.ItemsSource = implDosificacion.select().DefaultView;
                gridDosificaciones.Columns[0].Visibility = Visibility.Collapsed;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                implDosificacion = new DosificacionImpl();
                dosificacion = new Dosificacion(txtAutorizacion.Text, datepik1.SelectedDate.Value, txtLlave.Text);
                implDosificacion.InsertTransac(dosificacion);
                MessageBox.Show("Dosificacion actualizada con exito");
                txtAutorizacion.Clear();
                datepik1.Text = "";
                txtLlave.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnsal_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
