using System;
using System.Collections.Generic;
using System.Data;
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

namespace Panacea
{
    /// <summary>
    /// Lógica de interacción para ProDetalle.xaml
    /// </summary>
    public partial class ProDetalle : Window
    {
        public ProDetalle(DataTable dt)
        {
            InitializeComponent();
            dgproductos.ItemsSource = null;
            dgproductos.ItemsSource = dt.DefaultView;
        }
    }
}
