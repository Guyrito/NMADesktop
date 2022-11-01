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
    /// Lógica de interacción para TarjetaRevision.xaml
    /// </summary>
    public partial class TarjetaRevision : UserControl
    {
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public TarjetaRevision()
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        {
            InitializeComponent();
            DataContext = this;
        }
        public string DisplayNombreEmpresa { get; set; }
        public string DisplayRutEmpresa { get; set; }
        public string DisplayNombreGerente { get; set; }
        public string DisplayNombreProfesional { get; set; }
        public string DisplayNombreActMejora { get; set; }
        public string DisplayFechaActMejora { get; set; }
        public string DisplayHoraActMejora { get; set; }
        public string DisplayDescripcionActMejora { get; set; }
        public string CreateInformacionDeImportancia { get; set; }

        private void GridPrincipal_Initialized(object sender, EventArgs e)
        {
            dockPanelMedio.Visibility = Visibility.Collapsed;
            dockPanelInferior.Visibility = Visibility.Collapsed;
            ucTarjetaRevision.Height.Equals(89.775);
        }

        private void BtnUpdDown_Click(object sender, RoutedEventArgs e)
        {
            if (dockPanelMedio.Visibility.Equals(Visibility.Collapsed)
                && dockPanelInferior.Visibility.Equals(Visibility.Collapsed))
            {
                ucTarjetaRevision.Height.Equals(400);
                dockPanelMedio.Visibility = Visibility.Visible;
                dockPanelInferior.Visibility = Visibility.Visible;
            }
            else if (dockPanelMedio.Visibility.Equals(Visibility.Visible)
                && dockPanelInferior.Visibility.Equals(Visibility.Visible))
            {
                ucTarjetaRevision.Height.Equals(89.775);
                dockPanelMedio.Visibility = Visibility.Collapsed;
                dockPanelInferior.Visibility = Visibility.Collapsed;
            }
        }
    }
}
