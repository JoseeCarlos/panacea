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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Model;
using Implemetation;
using Microsoft.Win32;
using System.IO;
using System.Data;
using System.Security.Cryptography;

namespace Panacea
{
    /// <summary>
    /// Lógica de interacción para ventanaUser.xaml
    /// </summary>
    public partial class ventanaUser : Page
    {
        Usuario usuario;
        UsuarioImpl implusuario;
        string pathImgUser = null;
       
        public ventanaUser()
        {
            InitializeComponent();

        }

        private void btnagregar_Click(object sender, RoutedEventArgs e)
        {
            if (pathImgUser!=null)
            {
                try
                {
                    implusuario = new UsuarioImpl();

                    string username = CrearUser(txtnom.Text, txtpape.Text, txtsApe.Text);

                   

                    string password = logypas(txtnom.Text, txtpape.Text);

                    string cifrarpass = Getsha256(password);

                    DataTable dt = implusuario.selectUsername(username);

                    //if (dt.Rows.Count>0)
                    //{
                    //    username = CrearUser2(txtnom.Text,txtpape.Text,txtsApe.Text);
                    //}
                   

                    usuario = new Usuario(txtnom.Text, txtpape.Text, txtsApe.Text, datepik1.SelectedDate.Value, combogene.Text, txtcorreo.Text, username, cifrarpass, comborole.Text, 1, Session.SessionId);
                    
                    int ide = implusuario.getIndentity();
                    int res = implusuario.insert(usuario);
                    if (res > 0)
                    {
                        File.Copy(pathImgUser, Config.pathFotoUsuario + ide + ".jpg");
                       
                        MessageBox.Show("Usuario Creado con Exito");
                        enviaremail(txtcorreo.Text, username, password);

                    }






                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            else
            {
                MessageBox.Show("Debe completar los campos requeridos");
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
        private string  CrearUser(string n, string p1, string p2 )
        {
            string pri = n.Substring(0, 1);
            string se = p1.Substring(0, 1);
            string te = p2.Substring(0, 4);
           
            string user = pri + se + te ;
            return user;
        }
        private string CrearUser2(string n, string p1, string p2)
        {
            Random rnd = new Random();
            int res = rnd.Next(99, 999);
            string pri = n.Substring(0, 1);
            string se = p1.Substring(0, 1);
            string te = p2.Substring(0, 4);

            string user = pri + se + te+res;
            return user;
        }
        public void enviaremail(string email, string log, string pas)
        {
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
            mmsg.To.Add(email);
            mmsg.Subject = "Login y password panasea";
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
            mmsg.Body = "tu contraseña es " + pas + "\nTu username es " + log;
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
                MessageBox.Show("se le ha enviado el username y el password a su correo");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnfile_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            // descripcion|*.extencion; 
            ofd.Filter = "Archivos de Imagen|*.jpg";
            if (ofd.ShowDialog()==true)
            {
                imageUser.Source = new BitmapImage(new Uri(ofd.FileName));
                pathImgUser = ofd.FileName;
            }
          


        }

        
    }
}
