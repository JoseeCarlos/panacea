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
using Microsoft.Maps.MapControl.WPF;
using Model;
using Implemetation;
using System.Data;

namespace Panacea
{
    /// <summary>
    /// Lógica de interacción para Venfarmacia.xaml
    /// </summary>
    public partial class Venfarmacia : Page
    {
        Location ubicationpoin;
        pais pais;
        PaisImpl implpais;
        CiudadImpl implciudad;
        Proveedor proveedor;
        ProveedorImpl implproveedor;
        
        public Venfarmacia()
        {
            InitializeComponent();
        }

        private void btnsatelite_Click(object sender, RoutedEventArgs e)
        {
            myMap.Focus();
            myMap.Mode = new AerialMode(true);
        }

        private void btncalles_Click(object sender, RoutedEventArgs e)
        {
            myMap.Focus();
            myMap.Mode = new RoadMode();
        }

        private void btnmas_Click(object sender, RoutedEventArgs e)
        {
            myMap.Focus();
            myMap.ZoomLevel++;
        }

        private void btnmenos_Click(object sender, RoutedEventArgs e)
        {

            myMap.Focus();
            myMap.ZoomLevel--;
            
        }

        private void myMap_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            var mousepotition = e.GetPosition((UIElement)sender);
            ubicationpoin = myMap.ViewportPointToLocation(mousepotition);
            Pushpin m = new Pushpin();
            m.Location = ubicationpoin;
            myMap.Children.Clear();
            myMap.Children.Add(m);
            

            //MessageBox.Show(ubicationpoin.Latitude + "" + ubicationpoin.Longitude);


        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            loadDataCombo();
        }
        void loadDataCombo()
        {
            try
            {
                implpais = new PaisImpl();
                DataTable dt = implpais.SelectIdName();
                combopais.DisplayMemberPath = "NOMBREPAIS";
                combopais.SelectedValuePath = "IDPAIS";
                combopais.ItemsSource = dt.DefaultView;

                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void combopais_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                implciudad = new CiudadImpl();
                
                combociudad.DisplayMemberPath = "NOMBRECIUDAD";
                combociudad.SelectedValuePath = "IDCIUDAD";
                combociudad.SelectedIndex = 0;
                combociudad.ItemsSource = implciudad.selectnameyid(int.Parse(combopais.SelectedValue.ToString())).DefaultView;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnregis_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                proveedor = new Proveedor(txtnombre.Text,txtTelefono.Text,txtdirec.Text,ubicationpoin.Latitude,ubicationpoin.Longitude,int.Parse(combociudad.SelectedValue.ToString()),Session.SessionId);
                implproveedor = new ProveedorImpl();
                int res = implproveedor.insert(proveedor);
                if (res>0)
                {
                    MessageBox.Show("Registro Insertado con Exito");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al completar la Transaccion\nComuniquese con el Adm. de Sistemas");
            }
        }
    }
}
