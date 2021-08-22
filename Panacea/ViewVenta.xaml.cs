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
using Dao;
using System.Data;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

namespace Panacea
{
    /// <summary>
    /// Lógica de interacción para ViewVenta.xaml
    /// </summary>
    public partial class ViewVenta : Window
    {
        ClientesImpl implcliente;
        ProductoImpl implproducto;
        List<Productos> products = new List<Productos>();
        int conta = 0;
        double total = 0;
        Compra compra;
        CompraImpl implcompra;
        string path;
        Dosificacion dosificacion = null;
        DosificacionImpl implDosificaion;
        Clientes cliente = null;
        
       
        public ViewVenta()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtUser.Text = Session.SessionUsername;
            
        }

      

       

        private void txtProduc_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtProduc.Text.Length > 0)
            {
                implproducto = new ProductoImpl();
                dataProduct.ItemsSource = null;
                dataProduct.ItemsSource = implproducto.SearchProduct(txtProduc.Text).DefaultView;
                dataProduct.Columns[0].Visibility = Visibility.Collapsed;
            }
            else
            {
                dataProduct.ItemsSource = null;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataRowView datarow = (DataRowView)dataProduct.SelectedItem;
            int id = int.Parse(datarow.Row.ItemArray[0].ToString());
            implproducto = new ProductoImpl();

            DataTable dt = implproducto.SlectIdnom(id);

            Productos producto = new Productos(int.Parse(dt.Rows[0][0].ToString()),dt.Rows[0][1].ToString(),double.Parse(dt.Rows[0][2].ToString()),1);

            total = total + producto.Precio;
            txtTotal.Text = total.ToString();

            foreach (var item in products)
            {
                if (item.IdProducto==id)
                {
                    conta = 1;
                }
            }
            if (conta==1)
            {
                foreach (var item in products)
                {
                    if (item.IdProducto==id)
                    {
                        item.Cantidad = item.Cantidad + 1;
                        conta = 0;
                    }
                }
            }
            else
            {
                products.Add(producto);
            }
           
          
            dtProductl.ItemsSource = null;
            dtProductl.ItemsSource = products;
        }

        private void btnVenta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                implcliente = new ClientesImpl();
                string nitci = implcliente.Cicliente(int.Parse(comboCliente.SelectedValue.ToString()));
                implDosificaion = new DosificacionImpl();
                dosificacion = implDosificaion.GetSelect();
                int facturanum = implDosificaion.NumFactura();
                string datestring = DateTime.Now.ToString("yyyy/MM/dd");
                string code = ControlCode.generateControlCode(dosificacion.NroAutorizacion, facturanum.ToString(), nitci, datestring.Replace("/",""), txtTotal.Text, dosificacion.LlaveDosificacion);
                int id = DBImplementation2.GetIdentityFromTable2("VENTAFACTURA")+1;
                compra = new Compra(int.Parse(comboCliente.SelectedValue.ToString()),Session.SessionId,DateTime.Now,double.Parse(txtTotal.Text),nitci,txtcliente.Text,dosificacion.IdDosificacion,facturanum,code);
                implcompra = new CompraImpl();
                implcompra.Insert2(compra,products);

                implproducto = new ProductoImpl();
                
                MessageBox.Show("Venta registrado con exito");
                implproducto.updatepro(products);

                    
                string path = @"C:\imgPanacea\qr.png";

                QrEncoder qr = new QrEncoder(ErrorCorrectionLevel.H);
                QrCode qrcod = new QrCode();
                qr.TryEncode("Código Control: " + code, out qrcod);
                GraphicsRenderer grqr = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), System.Drawing.Brushes.Black, System.Drawing.Brushes.White);
                MemoryStream mrstream = new MemoryStream();
                grqr.WriteToStream(qrcod.Matrix, ImageFormat.Png, mrstream);
                var imgtemp = new Bitmap(mrstream);
                var imagen = new Bitmap(imgtemp, new System.Drawing.Size(new System.Drawing.Point(150, 150)));
                imagen.Save(path, ImageFormat.Png);


                DataTable dtventa = implcompra.FacturaDatos(id);
                DataTable dtdetalles = implcompra.FacturaDetalles(id);
                DataTable dtDosifica = implDosificaion.selectDosificacion(id);

                CrystalReport1 report = new CrystalReport1();
                report.Database.Tables["VENTAFACTURA"].SetDataSource(dtventa);
                report.Database.Tables["VENTADETALLE"].SetDataSource(dtdetalles);
                report.Database.Tables["DOSIFICACION"].SetDataSource(dtDosifica);
                report.SetParameterValue("pathimh", path);

                FacturaImp facturaImp = new FacturaImp(report);
                facturaImp.Show();

                products.Clear();
                txtTotal.Text = "";
                total = 0;
                dtProductl.ItemsSource = null;
               


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}, AL Realizar la Venta, ", DateTime.Now, ex.Message, 1));
                MessageBox.Show(ex.Message);
            }
        }

        private void dataProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataProduct.Items.Count > 0 && dataProduct.SelectedItem != null)
            {
                try
                {
                    DataRowView datarow = (DataRowView)dataProduct.SelectedItem;
                    int id = int.Parse(datarow.Row.ItemArray[0].ToString());
                    implproducto = new ProductoImpl();

                    DataTable dt = implproducto.selectfoto(id);

                    try
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            imageProduct.Source = new BitmapImage(new Uri(Config.pathFotoProducto + id + ".jpg"));
                        }
                        else
                        {
                            imageProduct.Source = new BitmapImage(new Uri(Config.pathFotoProducto + "0.jpg"));
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}, Carga de Imagen de un producto Incorrecta, ", DateTime.Now, ex.Message, id));
                        MessageBox.Show("Error Inesperado Contacte con el departamento de sistemas");
                    }

                }
                catch (Exception ex)
                {

                    System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}, Carga de Imagen de un producto Incorrecta, ", DateTime.Now, ex.Message,1));
                    MessageBox.Show("Error Inesperado Contacte con el departamento de sistemas");
                }
            }
            else
            {
               
            }
        }

        private void comboCliente_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (comboCliente.Text.Length>0)
                {
                    implcliente = new ClientesImpl();
                    DataTable dt = implcliente.SelectIdName(comboCliente.Text);
                    comboCliente.SelectedValuePath = "IDCLIENTE";
                    comboCliente.DisplayMemberPath = "CI";
                    comboCliente.ItemsSource = dt.DefaultView;
                    if (dt.Rows.Count>0)
                    {
                        comboCliente.IsDropDownOpen = true;
                        comboCliente.SelectedItem = dt.Rows[0][0].ToString();
                        txtcliente.Text = dt.Rows[0][1].ToString();
                       
                    }
                    else
                    {
                        comboCliente.IsDropDownOpen = false;
                    }
                    
                }
                else
                {
                    comboCliente.IsDropDownOpen = false;
                    comboCliente.ItemsSource = null;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Error:  {1}, Carga de Imagen de un producto Incorrecta ", DateTime.Now, ex.Message));
                MessageBox.Show("Error Inesperado Contacte con el departamento de sistemas");
            }
        }

        private void comboCliente_DropDownOpened(object sender, EventArgs e)
        {

        }

        private void BtExist_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnquitar_Click(object sender, RoutedEventArgs e)
        {

            DataRowView datarow = (DataRowView)dataProduct.SelectedItem;
            int id = int.Parse(datarow.Row.ItemArray[0].ToString());

            

        }

        

        private void bntCliente_Click(object sender, RoutedEventArgs e)
        {
            ViewCliente cli = new ViewCliente();
            cli.ShowDialog();
        }

        private void btnlim_Click(object sender, RoutedEventArgs e)
        {
            products.Clear();
            dtProductl.ItemsSource = null;
        }

        private void comboCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboCliente.Items.Count>0 && comboCliente.SelectedItem!=null)
            {
                try
                {
                    DataRowView rowView = (DataRowView)comboCliente.SelectedItem;
                    short id = short.Parse(rowView.Row.ItemArray[0].ToString());
                    implcliente = new ClientesImpl();
                    cliente = implcliente.getnombre(id);
                    txtcliente.Text = cliente.Nombre;
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            else
            {
                cliente = null;
            }
        }
    }
}
