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
    /// Lógica de interacción para VentanaNuevaAsesoria.xaml
    /// </summary>
    public partial class VentanaNuevaAsesoria : MetroWindow
    {
        public VentanaNuevaAsesoria()
        {
            InitializeComponent();
            datePickerFechaAsesoria.DisplayDateStart = DateTime.Now.AddDays(2);
            FormatoCalendario();
        }
        public int idCliente;
        public int idProfesional;
        public void FormatoCalendario()
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CL");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es-CL");
            datePickerFechaAsesoria.Language = XmlLanguage.GetLanguage("es-CL");
        }
        public bool ValidarCampos()
        {
            if (ComboBoxAsesorias.Text == " "
                || datePickerFechaAsesoria.SelectedDate == null
                || timePickerHoraAsesoria.SelectedDateTime == null
                && ComboBoxAsesorias.Text == " "
                && datePickerFechaAsesoria.SelectedDate == null
                && timePickerHoraAsesoria.SelectedDateTime == null)
            {
                MessageBox.Show("Se encontraron campos vacíos en la ventana o no se ha seleccionado una asesoría, favor de rellenar todos los campos y seleccionar una asesoría.", "Validación de campos");
                return false;
            }
            else
            {
                return true;
            }
        }
        public string DisplayHoraCreacionSolicitud { get; set; }
        public string DisplayDescripcionCaso { get; set; }
        public void CargarRazonAsesorias(int idProfesional, int idCliente)
        {
            ServiceSolicitud serviceSolicitud = new();
            foreach ( Solicitud _solicitud in serviceSolicitud.GetEntities())
            {
                if(_solicitud.Profesional_id_prof == idProfesional
                    && _solicitud.Gerente_id_gerente == idCliente
                    && _solicitud.Estado_solicitud == "Aceptada")
                {
                    ComboBoxItem comboBoxItem = new();
                    comboBoxItem.Content = _solicitud.Razon_soli;
                    Debug.WriteLine(comboBoxItem.Content);
                    ComboBoxAsesorias.Items.Add(comboBoxItem);
                }
            }
        }
        private void ComboBoxAsesorias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string HeaderCombobox = ComboBoxAsesorias.SelectedItem.ToString().Split(':')[1].Trim();
            ServiceSolicitud serviceSolicitud = new();
            foreach (Solicitud _solicitud in serviceSolicitud.GetEntities())
            {
                if (HeaderCombobox == _solicitud.Razon_soli)
                {
                    TxtBoxDescripcionCaso.Text = _solicitud.Descripcion;
                    var date = _solicitud.Fecha_CreacionSolicitud;
                    var formattedDate = date.ToString("dd/MM/yyyy");
                    var finalDate = Convert.ToDateTime(formattedDate);
                    datePickerFechaCreacionSolicitud.SelectedDate = finalDate;
                    var datetime = _solicitud.Hora_CreacionSolicitud;
                    var hora = datetime.TimeOfDay.Hours;
                    var minuto = datetime.TimeOfDay.Minutes;
                    timePickerHoraCreacionSolicitud.SelectedDateTime = datetime;
                }
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
                    fecha_act: datePickerFechaAsesoria.SelectedDate,
                    hora_act: timePickerHoraAsesoria.SelectedDateTime,
                    contador: 1,
                    prof_id_profe: idProfesional,
                    cliente_id_emp: idCliente,
                    tipo_actividad: "Asesoría",
                    estado: 0,
                    retraso: 0
                );
            contextActividad.SaveChanges();
        }
        public void CrearAsesoria(int idActividad)
        {
            var razon_solicitud = ComboBoxAsesorias.SelectedItem.ToString().Split(':')[1].Trim();
            int idSolicitud;
            ServiceSolicitud serviceSolicitud = new();
            ServiceProfesional serviceProfesional = new();
            foreach (Solicitud _solicitud in serviceSolicitud.GetEntities())
            {
                if (razon_solicitud == _solicitud.Razon_soli)
                {
                    idSolicitud = _solicitud.id_solicitud;
                    using BD_NMAEntities contextAsesoria = new();
                    contextAsesoria.CREATE_ASESORIA
                        (
                            razon_ases: razon_solicitud,
                            estado_caso: "Abierto",
                            diligencia: "null",
                            evento_ases: "null",
                            solicitud_id_solicitud: idSolicitud,
                            asesoriaActividad_id_act: idActividad,
                            fecha_incidente: datePickerFechaCreacionSolicitud.SelectedDate,
                            descripcion: TxtBoxDescripcionCaso.Text
                        );
                    contextAsesoria.SaveChanges();
                    using BD_NMAEntities contextActualizar = new();
                    var nombreProf = serviceProfesional.GetEntity(idProfesional).Nombre_prof;
                    var apellidoProf = serviceProfesional.GetEntity(idProfesional).Apellido_prof;
                    var fullNombreProf = nombreProf + " " + apellidoProf;
                    contextActualizar.crudUpdate
                        (
                            nombreTabla: "Solicitud",
                            nombreColumna: "Estado_solicitud",
                            nuevoDato: "Tomada por: "+fullNombreProf,
                            id: idSolicitud
                        );
                    contextActualizar.SaveChanges();
                }
            }
        }
        private void TileGuardar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("La información a continuación será ingresada. \n¿Esta seguro(a) que la información ingresada es correcta?", "Pregunta de confirmación", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                if(ValidarCampos() == true)
                {
                    CrearActividad(idProfesional, idCliente);
                    CrearAsesoria(Ultimo_idActividad());
                    MessageBox.Show("Asesoría creada correctamente.");
                    this.Close();
                }
                else if (ValidarCampos() == false)
                {
                    MessageBox.Show("No se pudo crear la asesoría.");
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
