﻿using MahApps.Metro.Controls;
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
    /// Lógica de interacción para VentanaNuevaActMejora.xaml
    /// </summary>
    public partial class VentanaNuevaActMejora : MetroWindow
    {
        public VentanaNuevaActMejora()
        {
            InitializeComponent();
        }
        private void TileGuardar_Click(object sender, RoutedEventArgs e)
        {
        }
        private void TileAtras_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
