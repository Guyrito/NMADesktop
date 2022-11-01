using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //Variables de prueba
        readonly string username = "prof";
        readonly string password = "123";

        private async void ValidarLogin()
        {
            if (usuarioLogin.Text.Equals(username)
                && contrasenaLogin.Password.Equals(password))
            {
                VistaProfesional vistaProfesional = new();
                this.Close();
                vistaProfesional.Show();
            }
            else
            {
                await this.ShowMessageAsync("ERROR :", "Usuario no encontrado.");
            }
        }

        private void BotonIngresar_Click(object sender, RoutedEventArgs e)
        {
            ValidarLogin();
        }

    }
}
