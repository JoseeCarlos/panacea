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

namespace Panacea
{
    /// <summary>
    /// Lógica de interacción para ReporteView3.xaml
    /// </summary>
    public partial class ReporteView3 : Window
    {
        public ReporteView3(ReporteProductos pro)
        {
            InitializeComponent();
            view2.ViewerCore.ReportSource = pro;
        }
    }
}
