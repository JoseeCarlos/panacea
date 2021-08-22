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
using System.Data;

namespace Panacea
{
    /// <summary>
    /// Lógica de interacción para Productolist.xaml
    /// </summary>
    public partial class Productolist : Window
    {
        Productos producto = null;
        ProductoImpl implproducto;
        public Productolist()
        {
            InitializeComponent();
        }

        private void txtbuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtbuscar.Text.Length>0)
            {
                implproducto = new ProductoImpl();
                datagrid1.ItemsSource = null;
                datagrid1.ItemsSource = implproducto.SearchProduct(txtbuscar.Text).DefaultView;
                datagrid1.Columns[0].Visibility = Visibility.Collapsed;
            }
            else
            {
                datagrid1.ItemsSource = null;
            }
           
        }

        private void datagrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datagrid1.Items.Count > 0 && datagrid1.SelectedItem != null)
            {
                try
                {
                    DataRowView datarow = (DataRowView)datagrid1.SelectedItem;
                    int id = int.Parse(datarow.Row.ItemArray[0].ToString());
                    implproducto = new ProductoImpl();
                    
                    producto = implproducto.Get(id);

                    txtnombre.Text = producto.NombreProducto;
                    txtprecio.Text = producto.Precio.ToString();
                    txtdescri.Text = producto.Descripcion;
                    txtfecha.Text = producto.FechaVencimiento.ToString();
                    txtstock.Text = producto.Stock.ToString();
                    txtcategoria.Text =producto.IdCategoria.ToString();
                    txtproveedor.Text = producto.Idproveedor.ToString();

                    try
                    {
                        if (producto.Foto == 1)
                        {
                            imagePro.Source = new BitmapImage(new Uri(Config.pathFotoProducto + producto.IdProducto + ".jpg"));
                        }
                        else
                        {
                            imagePro.Source = new BitmapImage(new Uri(Config.pathFotoProducto + "0.jpg"));
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}, Carga de Imagen de un producto Incorrecta, ", DateTime.Now,ex.Message,producto.IdProducto));
                        MessageBox.Show("Error Inesperado Contacte con el departamento de sistemas");
                    }

                }
                catch (Exception ex)
                {

                    System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}, Carga de Imagen de un producto Incorrecta, ", DateTime.Now, ex.Message, producto.IdProducto));
                    MessageBox.Show("Error Inesperado Contacte con el departamento de sistemas");
                }
            }
            else
            {
                producto = null;
            }
        }

        private void productUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (producto!=null)
            {
                imagePro.Source = null;
                Producto win = new Producto(this.producto);
                this.Visibility = Visibility.Hidden;
                win.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Es necesario Seleccionar un producto");
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
