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
    /// Lógica de interacción para FacturaImp.xaml
    /// </summary>
    public partial class FacturaImp : Window
    {
        public FacturaImp( CrystalReport1 rp)
        {
            InitializeComponent();
            viewFactura.ViewerCore.ReportSource = rp;
        }
    }
}
