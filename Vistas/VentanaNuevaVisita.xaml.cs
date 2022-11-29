using Controladores;
using MahApps.Metro.Controls;
using PersistenciaBD;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para VentanaNuevaVisita.xaml
    /// </summary>
    public partial class VentanaNuevaVisita : MetroWindow
    {
        public VentanaNuevaVisita()
        {
            InitializeComponent();
            DatepickerVisita.DisplayDateStart = DateTime.Now.AddDays(2);
            FormatoCalendario();
        }
        public int idCliente;
        public int idProfesional;
        public void FormatoCalendario()
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CL");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es-CL");
            DatepickerVisita.Language = XmlLanguage.GetLanguage("es-CL");
        }
        public bool ValidarCampos()
        {
            if(DatepickerVisita.SelectedDate == null
                || TimepickerVisita.SelectedDateTime == null
                && DatepickerVisita.SelectedDate == null
                && TimepickerVisita.SelectedDateTime == null)
            {
                MessageBox.Show("Se encontraron campos vacíos en la ventana, favor de rellenar todos los campos.", "Validación de campos");
                return false;
            }
            else
            {
                return true;
            }
        }
        public static int Ultimo_idActividad()
        {
            ServiceActividad serviceActividad = new();
            int ultimoID = 0;
            foreach (Actividad _actividad in serviceActividad.GetEntities())
            {
                if (ultimoID < _actividad.id_act)
                {
                    ultimoID = _actividad.id_act;
                }
            }
            return ultimoID;
        }
        public void CrearActividad(int idProfesional, int idCliente)
        {
            using BD_NMAEntities contextActividad = new();
            contextActividad.CREATE_ACTIVIDAD
                (
                    fecha_act: DatepickerVisita.SelectedDate,
                    hora_act: TimepickerVisita.SelectedDateTime,
                    contador: 1,
                    prof_id_profe: idProfesional,
                    cliente_id_emp: idCliente,
                    tipo_actividad: "Visita",
                    estado: 0,
                    retraso: 0
                );
            contextActividad.SaveChanges();
        }
        public void CrearVisita(int idActividad)
        {
            using BD_NMAEntities contextVisita = new();
            contextVisita.CREATE_VISITA
                (
                    checklist_id_check: null,
                    visitaActividad_id_act: idActividad,
                    test: null
                );
            contextVisita.SaveChanges();
        }
        private void TileGuardar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("La información a continuación será ingresada. \n¿Esta seguro(a) que la información ingresada es correcta?", "Pregunta de confirmación", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                if(ValidarCampos() == true)
                {
                    CrearActividad(idProfesional, idCliente);
                    CrearVisita(Ultimo_idActividad());
                    MessageBox.Show("Visita creada correctamente.");
                    this.Close();
                }
                else if (ValidarCampos() == false)
                {
                    MessageBox.Show("No se pudo crear la visita.");
                }
            }
            else if (messageBoxResult == MessageBoxResult.No)
            {
            }
            
        }
        private void TileAtras_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
