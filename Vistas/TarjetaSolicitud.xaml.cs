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

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para TarjetaSolicitud.xaml
    /// </summary>
    public partial class TarjetaSolicitud : UserControl
    {
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public TarjetaSolicitud()
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        {
            InitializeComponent();
            DataContext = this;
        }
        public string DisplayNombreEmpresa { get; set; }
        public string DisplayRutEmpresa { get; set; }
        public string DisplayNombreGerente { get; set; }
        public string DisplayNombreProfesional { get; set; }
        public string DisplayRazonSolicitud { get; set; }
        public string DisplayFechaSolicitud { get; set; }
        public string DisplayHoraSolicitud { get; set; }
        public string DisplayDescripcionSolicitud { get; set; }

        private void GridPrincipal_Initialized(object sender, EventArgs e)
        {
            dockPanelCentral.Visibility = Visibility.Collapsed;
            ucTarjetaSolicitud.Height.Equals(107.837837837838);
        }
        private void BtnUpdDown_Click(object sender, RoutedEventArgs e)
        {
            if (dockPanelCentral.Visibility.Equals(Visibility.Collapsed))
            {
                ucTarjetaSolicitud.Height.Equals(400);
                dockPanelCentral.Visibility = Visibility.Visible;
            }
            else if (dockPanelCentral.Visibility.Equals(Visibility.Visible))
            {
                ucTarjetaSolicitud.Height.Equals(107.837837837838);
                dockPanelCentral.Visibility = Visibility.Collapsed;
            }
        }
    }
}
