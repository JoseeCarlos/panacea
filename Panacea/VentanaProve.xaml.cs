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
using Microsoft.Maps.MapControl.WPF;
using Dao;
using Model;
using Implemetation;
using System.Data;

namespace Panacea
{
    /// <summary>
    /// Lógica de interacción para VentanaProve.xaml
    /// </summary>
    public partial class VentanaProve : Window
    {
        Proveedor proveedor=null;
        ProveedorImpl implproveedor;
        PaisImpl implpais;
        Location location;
        CiudadImpl implciudad;
        public VentanaProve()
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
        void selectproveer()
        {
            try
            {

                implproveedor = new ProveedorImpl();

                datagrid1.ItemsSource = null;
                datagrid1.ItemsSource = implproveedor.select().DefaultView;
                datagrid1.Columns[0].Visibility = Visibility.Collapsed;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            selectproveer();
            loadDataCombo();

        }

        private void datagrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datagrid1.Items.Count > 0 && datagrid1.SelectedItem != null)
            {
                try
                {
                    DataRowView datarow = (DataRowView)datagrid1.SelectedItem;
                    int id = int.Parse(datarow.Row.ItemArray[0].ToString());
                    implproveedor = new ProveedorImpl();
                    proveedor = implproveedor.get(id);
                   
                    txtnombre.Text = proveedor.Nombreproveedor;
                    txtdirec.Text = proveedor.Direccion;
                    txtTelefono.Text = proveedor.Telefono;
                    location = new Location(proveedor.Latitud, proveedor.Longitud);
                    myMap.SetView(location, 16);
                    Pushpin marcador = new Pushpin();
                    marcador.Location = location;
                    myMap.Children.Clear();
                    myMap.Children.Add(marcador);

                    implciudad = new CiudadImpl();
                    combociudad.DisplayMemberPath = "NOMBRECIUDAD";
                    combociudad.SelectedValuePath = "IDCIUDAD";
                    combociudad.SelectedIndex = 0;
                    combociudad.ItemsSource = implciudad.selectciudadname(proveedor.Idciudad).DefaultView;




                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                proveedor = null;
            }
           
        }
        void loadDataCombo()
        {
            try
            {
                implpais = new PaisImpl();
                combopais.DisplayMemberPath = "NOMBREPAIS";
                combopais.SelectedValuePath = "IDPAIS";
                combopais.ItemsSource = implpais.SelectIdName().DefaultView;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (proveedor != null)
            {


                if (MessageBox.Show("Esta Realmente segur@ de eliminar el registro??", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {


                    try
                    {
                        implproveedor = new ProveedorImpl();
                        int res = implproveedor.delete(proveedor);
                        if (res > 0)
                        {
                            MessageBox.Show("Registro Eliminado con exito");
                            selectproveer();

                        }
                        else
                        {
                            MessageBox.Show("No se elminaron registros");
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }

                }

            }
            else
            {
                MessageBox.Show("Debe Seleccinar un registro");
            }
        }

        private void combopais_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                implciudad = new CiudadImpl();

                combociudad.DisplayMemberPath = "NOMBRECIUDAD";
                combociudad.SelectedValuePath = "IDCIUDAD";
                
                combociudad.ItemsSource = implciudad.selectnameyid(int.Parse(combopais.SelectedValue.ToString())).DefaultView;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnmodificar_Click(object sender, RoutedEventArgs e)
        {
            if (proveedor != null)
            {
                try
                {
                    proveedor.Nombreproveedor = txtnombre.Text;
                    proveedor.Telefono = txtTelefono.Text;
                    proveedor.Direccion = txtdirec.Text;
                    proveedor.Latitud = location.Latitude;
                    proveedor.Longitud = location.Longitude;
                    
                    proveedor.UsuarioId = Session.SessionId;
                    implproveedor = new ProveedorImpl();
                    int res = implproveedor.update(proveedor);
                    if (res>0)
                    {
                        MessageBox.Show("Registro Modificado con Exito");
                        selectproveer();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Debe Seleccinar un registro");
            }
        }

        private void myMap_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            var mousepotition = e.GetPosition((UIElement)sender);
            location = myMap.ViewportPointToLocation(mousepotition);
            Pushpin m = new Pushpin();
            m.Location = location;
            myMap.Children.Clear();
            myMap.Children.Add(m);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
