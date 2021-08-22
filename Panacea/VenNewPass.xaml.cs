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

namespace Panacea
{
    /// <summary>
    /// Lógica de interacción para VenNewPass.xaml
    /// </summary>
    public partial class VenNewPass : Window
    {
        Usuario usuario;
        UsuarioImpl implusuario;
        public VenNewPass()
        {
            InitializeComponent();
        }

        private void btncambi_Click(object sender, RoutedEventArgs e)
        {
          
              if (txtpas1.Password == txtpas2.Password)
                {
                   try
                   {
                        usuario = new Usuario(txtpas1.Password);
                        implusuario = new UsuarioImpl();
                        int res = implusuario.updatePasseord2(Session.SessionId, usuario,oldPassword.Password);
                        if (res > 0)
                        {
                            MessageBox.Show("Contraseña Modifacada con Exito");
                            this.Close();
                            
                        }
                   }
                   catch (Exception ex)
                   {

                    System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}, Fallo en el Metodo Cambio de Password, ", DateTime.Now, ex.Message, 1));
                    MessageBox.Show("Error Inesperado comuniquese con el Departamento de Sistemas");
                   }

              }
              else
              {
                    
                    MessageBox.Show("Las Contraseñas no coinciden");
              }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtUser.Text = Session.SessionUsername;
           
        }

        private void btncancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
