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
using Dao;
using Model;
using Implemetation;


namespace Panacea
{
    /// <summary>
    /// Lógica de interacción para VwVenCanceladas.xaml
    /// </summary>
    public partial class VwVenCanceladas : Window
    {
        CompraImpl implcompra;
        public VwVenCanceladas()
        {
            InitializeComponent();
        }

        private void btnexit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadgrid1();
            loadgrid2();
        }

        void loadgrid1()
        {
            try
            {

                implcompra = new CompraImpl();

                dgVentasR.ItemsSource = null;
                dgVentasR.ItemsSource = implcompra.selectdelete().DefaultView;
                dgVentasR.Columns[0].Visibility = Visibility.Collapsed;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        void loadgrid2()
        {
            try
            {

                implcompra = new CompraImpl();

                datagrid2.ItemsSource = null;
                datagrid2.ItemsSource = implcompra.selectDadoBaja().DefaultView;
                datagrid2.Columns[0].Visibility = Visibility.Collapsed;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
