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
using Dao;
using Model;
using Implemetation;
using System.Data;

namespace Panacea
{
    /// <summary>
    /// Lógica de interacción para VenlistUser.xaml
    /// </summary>
    public partial class VenlistUser : Page
    {
        Usuario usuario=null;
        UsuarioImpl impluser;
       
        public VenlistUser()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            datagridList();
        }
        void datagridList()
        {
            try
            {
               
                    impluser = new UsuarioImpl();

                   datalist1.ItemsSource = null;
                   datalist1.ItemsSource = impluser.select().DefaultView;
                   datalist1.Columns[0].Visibility = Visibility.Collapsed;
                
            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message);
            }
        }

        private void datalist1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datalist1.Items.Count>0&&datalist1.SelectedItem!=null)
            {
                try
                {
                    DataRowView datarow = (DataRowView)datalist1.SelectedItem;
                    int id=int.Parse( datarow.Row.ItemArray[0].ToString());
                    impluser = new UsuarioImpl();
                    usuario= impluser.get(id);
                    txtnombre.Text = usuario.Nombre;
                    txtpApe.Text = usuario.PriApellido;
                    txtSape.Text = usuario.SeguApellido;
                    txtfecha.Text = usuario.FechaNacimiento.ToString();
                    txtgenero.Text = usuario.Genero;
                    txtemail.Text = usuario.Email;
                    txtrol.Text = usuario.Role;
                    
                    
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                usuario = null;
            }
        }

        private void btnmodificar_Click(object sender, RoutedEventArgs e)
        {
            if (usuario!=null)
            {

                try
                {



                    usuario.Nombre = txtnombre.Text;
                    usuario.PriApellido = txtpApe.Text;
                    usuario.SeguApellido = txtSape.Text;
                    
                   
                    impluser = new UsuarioImpl();
                    int res = impluser.update(usuario);
                    if (res > 0)
                    {
                        MessageBox.Show("Registro Modificado con exito");
                        datagridList();

                    }
                    else
                    {
                        MessageBox.Show("No se modificaron registros");
                    }




                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Debe Seleccinar un registro");
            }
        }

        private void datalist1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnElimin_Click(object sender, RoutedEventArgs e)
        {
            if (usuario != null)
            {

               
                    if (MessageBox.Show("Esta Realmente segur@ de eliminar el registro??","Eliminar",MessageBoxButton.YesNo,MessageBoxImage.Warning)==MessageBoxResult.Yes)
                    {
                        

                       try
                       {
                        impluser = new UsuarioImpl();
                        int res = impluser.delete(usuario);
                        if (res > 0)
                        {
                            MessageBox.Show("Registro Eliminado con exito");
                            datagridList();

                        }
                        else
                        {
                            MessageBox.Show("No se elminaron registros");
                        }
                       }
                       catch (Exception ex)
                       {

                        MessageBox.Show(ex.Message);
                       }
                     
                    }   
               
            }
            else
            {
                MessageBox.Show("Debe Seleccinar un registro");
            }
        }
    }
}
