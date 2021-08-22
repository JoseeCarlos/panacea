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

namespace Panacea
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string pathfotoser = "";
        
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void btnsalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            
            
        }

        private void textefec_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frame2.Navigate(new System.Uri("Page2.xaml", UriKind.RelativeOrAbsolute));
            
        }

        private void nomsesion_Loaded(object sender, RoutedEventArgs e)
        {

            nomsesion.Content = Session.Username();
        }

        private void venUser_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frame2.Navigate(new System.Uri("ventanaUser.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnnewPass_Click(object sender, RoutedEventArgs e)
        {
            VenNewPass venpas = new VenNewPass();
            venpas.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Session.SessionInicio == 1)
            {
                MessageBox.Show("Primer Inicio de Sesion debe Cambiar su Contraseña");
                VenCambiopass ven = new VenCambiopass();
                ven.Show();
                this.Close();

            }
            if (Session.SessionRole=="Administrador")
            {

            }
            if (Session.SessionRole=="Ventas")
            {
                visenfe.Visibility = Visibility.Collapsed;
                vistaUser.Visibility = Visibility.Collapsed;
                Vistarepor.Visibility = Visibility.Collapsed;
                vistaReporte.Visibility = Visibility.Collapsed;
                vistaDosificacion.Visibility = Visibility.Collapsed;
            }
            if (Session.SessionRole=="Inventario")
            {
               
                Vistarepor.Visibility = Visibility.Collapsed;
                vistaCli.Visibility = Visibility.Collapsed;
                vistaUser.Visibility = Visibility.Collapsed;
                txtnewPro.Visibility = Visibility.Collapsed;
                reVentas.Visibility = Visibility.Collapsed;
                produV.Visibility = Visibility.Collapsed;
                visenfe.Visibility = Visibility.Collapsed;
                vistaReporte.Visibility = Visibility.Collapsed;
                vistaDosificacion.Visibility = Visibility.Collapsed;

            }

            if (Session.foto==1)
            {
                pathfotoser = Config.pathFotoUsuario + Session.SessionId + ".jpg";
            }
            else
            {
                pathfotoser = Config.pathFotoUsuario + "0.jpg";
            }
           
            logima.Source = new BitmapImage(new Uri( pathfotoser));
            
        }

        private void pagelist_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frame2.Navigate(new System.Uri("VenlistUser.xaml", UriKind.RelativeOrAbsolute));
        }

        private void ventapro_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frame2.Navigate(new System.Uri("Venfarmacia.xaml", UriKind.RelativeOrAbsolute));
        }

        private void venlistProv_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            VentanaProve vent = new VentanaProve();
            vent.Show();
        }

        private void ventanaPro_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Productolist pro = new Productolist();
            pro.Show();
        }

        private void ventProducto_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Producto pro = new Producto();
            pro.Show();
        }

        private void ViewCli_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ViewCliente clien = new ViewCliente();
            clien.ShowDialog();
        }

        private void textVenta_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ViewVenta venta = new ViewVenta();
            venta.ShowDialog();
              
        }

        private void viewLista_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ViewVentaList lista = new ViewVentaList();
            lista.ShowDialog();


        }

        private void viewVentAnu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            VwVenCanceladas cance = new VwVenCanceladas();
            cance.ShowDialog();
        }

        private void viewDosificacion_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ViewDosificacion dosi = new ViewDosificacion();
            dosi.ShowDialog();

        }

        private void reporte1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ReportVentas vetas = new ReportVentas();
            vetas.ShowDialog();
            
        }
    }
}
