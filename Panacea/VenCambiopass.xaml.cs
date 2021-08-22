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
using System.Security.Cryptography;

namespace Panacea
{
    /// <summary>
    /// Lógica de interacción para VenCambiopass.xaml
    /// </summary>
    public partial class VenCambiopass : Window
    {
        UsuarioImpl implusuario;
        Usuario usuario;

        public VenCambiopass()
        {
            InitializeComponent();
        }

        private void btncambiar_Click(object sender, RoutedEventArgs e)
        {
            if (txtpas1.Password == txtpas2.Password)
            {
                try
                {

                    string pass = Getsha256(txtpas1.Password);
                    usuario = new Usuario(pass, 0);
                   

                    implusuario = new UsuarioImpl();
                    int res = implusuario.updatePassword(Session.SessionId, usuario);
                    if (res > 0)
                    {
                        MessageBox.Show("Password Cambiado con Exito");

                        this.Close();


                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }


            }
            else
            {
                MessageBox.Show("las contraseñas no son identicas");
            }
            
        }
        public static string Getsha256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();

        }

    }
}
