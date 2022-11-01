using MahApps.Metro.Controls;
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

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para VentanaNuevoChecklist.xaml
    /// </summary>
    public partial class VentanaNuevoChecklist : MetroWindow
    {
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public VentanaNuevoChecklist()
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        {
            InitializeComponent();
            DataContext = this;
        }
        public string DisplayNombreCliente { get; set; }
        public string DisplayFechaVisita { get; set; }
        public string DisplayHoraVisita { get; set; }
        private void TileAgregarItem_Click(object sender, RoutedEventArgs e)
        {
            TextBox txtboxItem = new()
            {
                BorderBrush = new SolidColorBrush(Color.FromRgb(224, 224, 224)),
                Background = new SolidColorBrush(Color.FromRgb(245, 245, 245)),
                BorderThickness = new Thickness(0, 0, 0, 2)
            };
            this.StckPanelChecklist.Children.Add(txtboxItem);
        }
        private void TileAtras_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
