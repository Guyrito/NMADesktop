using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para ClienteTarjetaCompleta.xaml
    /// </summary>
    public partial class ClienteTarjetaCompleta : UserControl
    {
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public ClienteTarjetaCompleta()
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        {
            InitializeComponent();
            DataContext = this;
        }
        //--------------------------------------------------
        public int ReceiveIdProfesional { get; set; }
        public int ReceiveIdCliente { get; set; }
        //--------------------------------------------------
        public string DisplayEmpresa { get; set; }
        public string DisplayRutEmpresa { get; set; }
        public string DisplayGerente { get; set; }
        public string DisplayProfNombre { get; set; }
        public string DisplayMailGerente { get; set; }
        public string DisplayTelefonoEmpresa { get; set; }
        public string DisplayDireccion { get; set; }
        public string DisplayActMejora { get; set; }
        //--------------------------------------------------
        private void BtnUpdDown_Click(object sender, RoutedEventArgs e)
        {
            if (dockPanelMedio.Visibility == Visibility.Collapsed)
            {
                dockPanelMedio.Visibility = Visibility.Visible;
                ucTarjetaCliente.Height.Equals(300);
            }
            else if (dockPanelMedio.Visibility == Visibility.Visible)
            {
                ucTarjetaCliente.Height.Equals(72.4137931034483);
                dockPanelMedio.Visibility = Visibility.Collapsed;
            }
        }
        private void GridPrincipal_Initialized(object sender, EventArgs e)
        {
            dockPanelMedio.Visibility = Visibility.Collapsed;
            ucTarjetaCliente.Height.Equals(72.4137931034483);
        }
        /*
        private void CerrarVentana()
        {
            VentanaNuevaActMejora ventanaNuevaActMejora = new VentanaNuevaActMejora();
            VentanaNuevaAsesoria ventanaNuevaAsesoria = new VentanaNuevaAsesoria();
            VentanaNuevaCapacitacion ventanaNuevaCapacitacion = new VentanaNuevaCapacitacion();
            VentanaNuevaVisita ventanaNuevaVisita = new VentanaNuevaVisita();
            VentanaNuevoChecklist ventanaNuevoChecklist = new VentanaNuevoChecklist();
            var ListaVentanas = (ventanaNuevaActMejora
                , ventanaNuevaAsesoria
                , ventanaNuevaCapacitacion
                , ventanaNuevaVisita
                , ventanaNuevoChecklist);
        }
        */
        private void BtnAgregarVisita_Click(object sender, RoutedEventArgs e)
        {
            VentanaNuevaVisita ventanaNuevaVisita = new();
            ventanaNuevaVisita.ShowDialog();
        }
        private void BtnAgregarCapacitacion_Click(object sender, RoutedEventArgs e)
        {
            VentanaNuevaCapacitacion ventanaNuevaCapacitacion = new();
            ventanaNuevaCapacitacion.ShowDialog();
        }
        private void BtnAgregarAsesoria_Click(object sender, RoutedEventArgs e)
        {
            VentanaNuevaAsesoria ventanaNuevaAsesoria = new();
            ventanaNuevaAsesoria.ShowDialog();
        }
        private void BtnAgregarActMejora_Click(object sender, RoutedEventArgs e)
        {
            VentanaNuevaActMejora ventanaNuevaActMejora = new();
            ventanaNuevaActMejora.ShowDialog();
        }
    }
}
