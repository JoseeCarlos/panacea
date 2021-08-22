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


namespace Panacea.Users
{
    /// <summary>
    /// Lógica de interacción para Vnrecuperarpass.xaml
    /// </summary>
    public partial class Vnrecuperarpass : Window
    {
        Usuario usuario;
        UsuarioImpl implusuario;
        public Vnrecuperarpass()
        {
            InitializeComponent();
        }

        private void btnenviar_Click(object sender, RoutedEventArgs e)
        {
            string n1 = "recu";
            string n2 = "perar";
            string pass = logypas(n1, n2);
            try
            {
                usuario = new Usuario(pass,1);
                implusuario = new UsuarioImpl();
                int res=implusuario.updateRecuperarPass(txtcorreo.Text, txtuserl.Text, usuario);
                if (res>0)
                {
                    enviaremail(txtcorreo.Text, pass);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}, Fallo en el Metodo Recuperar Password, ", DateTime.Now, ex.Message, 1));
                MessageBox.Show("Error Inesperado comuniquese con el Departamento de Sistemas");
            }
        }

        public string logypas(string nom, string ape)
        {
            Random rdn = new Random();
            string caracteres = nom + ape;
            int longitud = caracteres.Length;
            char letra;
            int longitudContrasenia = 7;
            string contraseniaAleatoria = string.Empty;
            for (int i = 0; i < longitudContrasenia; i++)
            {
                letra = caracteres[rdn.Next(longitud)];
                contraseniaAleatoria += letra.ToString();
            }
            return contraseniaAleatoria;
        }
        public void enviaremail(string email, string pas)
        {
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
            mmsg.To.Add(email);
            mmsg.Subject = "password panasea de recuperacion";
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
            mmsg.Body = "tu contraseña es " + pas ;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true;
            mmsg.From = new System.Net.Mail.MailAddress("panaceacorporation12@gmail.com");

            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
            cliente.Credentials = new System.Net.NetworkCredential("panaceacorporation12@gmail.com", "jose60388135");
            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.gmail.com";
            try
            {
                cliente.Send(mmsg);
                MessageBox.Show("se le ha enviado el password de recuperacion a su Correo");
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}, Fallo en el Metodo de Envio de Email, ", DateTime.Now, ex.Message, 1));
                MessageBox.Show("Error Inesperado comuniquese con el Departamento de Sistemas");
            }
        }

        private void btncancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
