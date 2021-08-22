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
    /// Lógica de interacción para ReportVentas.xaml
    /// </summary>
    public partial class ReportVentas : Window
    {
        CompraImpl implCompra;
        
        public ReportVentas()
        {
            InitializeComponent();
        }

       

        private void Seleccionar_Click(object sender, RoutedEventArgs e)
        {
            implCompra = new CompraImpl();
            DataTable dt = implCompra.vetasGeneral(datepik1.SelectedDate.Value,datepik12.SelectedDate.Value);
            ReporteVentas ven = new ReporteVentas();
            ven.Database.Tables["VENTAFACTURA"].SetDataSource(dt);
            ReporView2 view = new ReporView2(ven);
            view.Show();
            
        }

        private void btnrepor2_Click(object sender, RoutedEventArgs e)
        {
            implCompra = new CompraImpl();
            DataTable dt2 = implCompra.vetasTopProductos(int.Parse(combonum.Text));
            ReporteProductos pro = new ReporteProductos();
            pro.Database.Tables["VENTADETALLE"].SetDataSource(dt2);
            ReporteView3 rep = new ReporteView3(pro);
            rep.Show();
        }

       
    }
}
