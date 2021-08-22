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
using Microsoft.Win32;
using System.IO;

namespace Panacea
{
    /// <summary>
    /// Lógica de interacción para Producto.xaml
    /// </summary>
    public partial class Producto : Window
    {
        Productos pro;
        ProductoImpl implproducto;
        CategoriaImpl implcategoria;
        ProveedorImpl implproveedor;
        string pathImgProduc = null,pathimgServer=null;

        byte opcion = 0;
        public Producto()
        {
            InitializeComponent();
            this.opcion = 1;
        }
        public Producto(Productos productos)
        {
            InitializeComponent();
            this.opcion = 2;
            this.pro = productos;

           
            loadDatosProducto();
        }
        void loadDatosProducto()
        {
            txtTitulo.Text = "Modificar Producto";
            txtnombre.Text = this.pro.NombreProducto;
            txtPrecio.Text = this.pro.Precio.ToString();
            txtdescri.Text = this.pro.Descripcion;
            txtcanti.Text = this.pro.Stock.ToString();
            ComboCategoria.SelectedValue = this.pro.IdCategoria.ToString();
            datepik1.SelectedDate = this.pro.FechaVencimiento;
            
            ComboProveedor.SelectedValue = this.pro.Idproveedor.ToString();

            try
            {
                if (pro.Foto == 1)
                {
                   pathimgServer= Config.pathFotoProducto + pro.IdProducto + ".jpg";
                }
                else
                {
                    pathimgServer= Config.pathFotoProducto + "0.jpg";
                }
                imgProduc.Source = new BitmapImage(new Uri(pathimgServer));
                pathImgProduc = pathimgServer;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}, Carga de Imagen de un producto", DateTime.Now, ex.Message, pro.IdProducto));
                MessageBox.Show("Comuniquese con el Departamento de Sistemas ");
                throw ex;
               
            }
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadDataCombo();
            loadComboProveedor();
        }

        void loadDataCombo()
        {
            try
            {
                implcategoria = new CategoriaImpl();
                ComboCategoria.DisplayMemberPath = "NOMBRECATEGORIA";
                ComboCategoria.SelectedValuePath = "IDCATEGORIA";
                ComboCategoria.ItemsSource = implcategoria.selectCategoriaId().DefaultView;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        void loadComboProveedor()
        {
            try
            {
                implproveedor = new ProveedorImpl();
                ComboProveedor.DisplayMemberPath = "NOMBREPROVEEDOR";
                ComboProveedor.SelectedValuePath = "IDPROVEEDOR";
                ComboProveedor.ItemsSource = implproveedor.SelectIdName().DefaultView;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            // descripcion|*.extencion; 
            ofd.Filter = "Archivos de Imagen|*.jpg";
            if (ofd.ShowDialog() == true)
            {
                imgProduc.Source = new BitmapImage(new Uri(ofd.FileName));
                pathImgProduc = ofd.FileName;
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            switch (opcion)
            {
                case 1: // insert
                    try
                    {

                        pro = new Productos(txtnombre.Text, double.Parse(txtPrecio.Text), txtdescri.Text, 1, int.Parse(txtcanti.Text), int.Parse(ComboCategoria.SelectedValue.ToString()), datepik1.SelectedDate.Value, "ENVASE", Session.SessionId, int.Parse(ComboProveedor.SelectedValue.ToString()));
                        implproducto = new ProductoImpl();
                        int ide = DBImplementation2.GetIdentityFromTable2("Producto")+1;
                        int res = implproducto.insert(pro);
                        if (res > 0)
                        {

                            File.Copy(pathImgProduc, Config.pathFotoProducto + ide + ".jpg");
                            MessageBox.Show("Registro Insertado con exito");
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }

                    break;
                case 2: // update
                    this.pro.NombreProducto = txtnombre.Text;
                    this.pro.Precio = double.Parse(txtPrecio.Text);
                    this.pro.Descripcion = txtdescri.Text;
                    this.pro.FechaVencimiento =datepik1.SelectedDate.Value;
                    this.pro.Stock = int.Parse(txtcanti.Text);
                    this.pro.IdCategoria = int.Parse(ComboCategoria.SelectedValue.ToString());
                    this.pro.Idproveedor = int.Parse(ComboProveedor.SelectedValue.ToString());

                    try
                    {
                        implproducto = new ProductoImpl();
                        int res = implproducto.update(this.pro);
                        if (res>0)
                        {
                            MessageBox.Show("Producto Actualizado con Exito");
                            if (pathImgProduc!=pathimgServer)
                            {
                                System.GC.Collect();
                                System.GC.WaitForPendingFinalizers();
                                File.Delete(pathimgServer);
                                File.Copy(pathImgProduc,pathimgServer);
                            }
                            this.Close();
                            Productolist pro = new Productolist();
                            pro.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            MessageBox.Show("No se Actualizaron Registros :(");
                        }

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }

                    break;
            }
           
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
           
        }
    }
}
