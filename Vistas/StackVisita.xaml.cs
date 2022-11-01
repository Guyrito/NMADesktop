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

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para StackVisita.xaml
    /// </summary>
    public partial class StackVisita : UserControl
    {
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public StackVisita()
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        {
            InitializeComponent();
            DataContext = this;
        }
        public string DisplayFechaVisita { get; set; }
        public string DisplayHoraVisita { get; set; }

        public void ToggleBtnVisita_Checked(object sender, RoutedEventArgs e)
        {
            if (this.ToggleBtnVisita.IsChecked == true)
            {
                int var = 0;
                Debug.WriteLine(var);
            }
        }
    }
}
