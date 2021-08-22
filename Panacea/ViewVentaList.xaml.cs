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
    /// Lógica de interacción para ViewVentaList.xaml
    /// </summary>
    public partial class ViewVentaList : Window
    {
        Compra compra;
        CompraImpl implcompra;
        FacturaAnulada facturaAnulada;
        FacturaAnuladaImpl implFacturaAnulada;
        ProductoImpl implproducto;
        List<Productos> productLis = new List<Productos>();
        Productos pro;
        public ViewVentaList()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            selectCompra();
        }

        void selectCompra()
        {
            try
            {

                implcompra = new CompraImpl();

                dgVentasR.ItemsSource = null;
                dgVentasR.ItemsSource = implcompra.select().DefaultView;
                dgVentasR.Columns[0].Visibility = Visibility.Collapsed;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            implcompra = new CompraImpl();
            dgVentasR.ItemsSource = null;
            dgVentasR.ItemsSource = implcompra.serachDate(date1.Text,date2.Text).DefaultView;
            dgVentasR.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void btnsalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CoInabilitar_Click(object sender, RoutedEventArgs e)
        {
            if (txtdescri.Text!="")
            {
                DataRowView datarow = (DataRowView)dgVentasR.SelectedItem;
                int id = int.Parse(datarow.Row.ItemArray[0].ToString());

                facturaAnulada = new FacturaAnulada(id,txtdescri.Text);
                implFacturaAnulada = new FacturaAnuladaImpl();
                DataTable dt2 = implproducto.productoDetalle(id);
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    pro = new Productos(int.Parse(dt2.Rows[i]["IDPRODUCTO"].ToString()),int.Parse(dt2.Rows[i]["CANTIDAD"].ToString()));
                    productLis.Add(pro);
                    MessageBox.Show(dt2.Rows[i]["CANTIDAD"].ToString());
                }

                implFacturaAnulada.insertFactura(facturaAnulada,productLis);
                MessageBox.Show("Se anulo la factura");
               
            }
            else
            {
                MessageBox.Show("Porfavor ponga el motivo de la anulacion");
            }

            
        }

        private void CodarBaja_Click(object sender, RoutedEventArgs e)
        {
            DataRowView datarow = (DataRowView)dgVentasR.SelectedItem;
            int id = int.Parse(datarow.Row.ItemArray[0].ToString());
            compra = new Compra(id);
            implcompra = new CompraImpl();

            int res = implcompra.delete(compra);

            if (res > 0)
            {
                MessageBox.Show("Venta Anulada");
                selectCompra();
            }
            else
            {
                MessageBox.Show("No se Anulo la Venta");
            }
        }

        private void txtnumero_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtnumero.Text.Length>0)
            {
                implcompra = new CompraImpl();
                dgVentasR.ItemsSource = null;
                dgVentasR.ItemsSource = implcompra.serachNum(int.Parse(txtnumero.Text)).DefaultView;
                dgVentasR.Columns[0].Visibility = Visibility.Collapsed;
            }
           

        }

        private void CodarBaja_Click_1(object sender, RoutedEventArgs e)
        {
            DataRowView datarow = (DataRowView)dgVentasR.SelectedItem;
            int id = int.Parse(datarow.Row.ItemArray[0].ToString());
            implproducto = new ProductoImpl();
            DataTable dt = implproducto.productoDetalle(id);
            ProDetalle pro = new ProDetalle(dt);
            pro.ShowDialog();

        }
    }
}
