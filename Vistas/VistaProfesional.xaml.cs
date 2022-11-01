using Controladores;
using MahApps.Metro.Controls;
using PersistenciaBD;
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
using System.Windows.Shapes;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para VistaProfesional.xaml
    /// </summary>
    public partial class VistaProfesional : MetroWindow
    {
        public VistaProfesional()
        {
            InitializeComponent();
            Height = 500;
            Width = 1000;
            TabItemOpciones1.Visibility = Visibility.Collapsed;
            TabItemOpciones2.Visibility = Visibility.Collapsed;
            TabItemOpciones3.Visibility = Visibility.Collapsed;
            scrlViewerPrincipal.Visibility = Visibility.Visible;
            BtnCheckList.Visibility = Visibility.Collapsed;
            BtnCasoAsesoria.Visibility = Visibility.Collapsed;
            //btnCheckList.IsEnabled = false;
            BtnCasoAsesoria.IsEnabled = false;
        }
        private void TileSalir_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new();
            this.Close();
            login.ShowDialog();
        }
        private void TabItemClientes_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BtnCheckList.Visibility = Visibility.Collapsed;
            BtnCasoAsesoria.Visibility = Visibility.Collapsed;
            TabItemOpciones1.Header = "CLIENTE";
            TabItemOpciones2.Header = "ASESORIAS";
            TabItemOpciones3.Header = "SOLICITUDES";
            TabItemOpciones1.Visibility = Visibility.Visible;
            TabItemOpciones2.Visibility = Visibility.Visible;
            TabItemOpciones3.Visibility = Visibility.Visible;
            stckPanelTarjetas.Children.Clear();
        }
        private void TabitemProfesionales_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BtnCheckList.Visibility = Visibility.Collapsed;
            BtnCasoAsesoria.Visibility = Visibility.Collapsed;
            TabItemOpciones1.Header = "REVISIÓN";
            TabItemOpciones1.Visibility = Visibility.Visible;
            TabItemOpciones2.Visibility = Visibility.Collapsed;
            TabItemOpciones3.Visibility = Visibility.Collapsed;
            stckPanelTarjetas.Children.Clear();
        }
        public static ClienteTarjetaCompleta CrearTarjetaCliente(int idGerente)
        {
            ServiceActividad serviceActividad = new();
            ServiceActMejora serviceActMejora = new();
            ServiceAsesoria serviceAsesoria = new();
            ServiceCliente serviceCliente = new();
            ServiceGerente serviceGerente = new();
            ServiceProfesional serviceProfesional = new();

            var idCliente = serviceGerente.GetEntity(idGerente).Cliente_id_clien;

#pragma warning disable CS8604 // Posible argumento de referencia nulo
            var idProfesional = serviceCliente.GetEntity(idCliente).Profesional_id_prof;
#pragma warning restore CS8604 // Posible argumento de referencia nulo

            ClienteTarjetaCompleta clienteTarjetaCompleta = new()
            {
                ReceiveIdCliente = serviceCliente.GetEntity(idCliente).id_emp,
                ReceiveIdProfesional = serviceProfesional.GetEntity(idProfesional).id_prof,

                DisplayEmpresa = serviceCliente.GetEntity(idCliente).Nombre_emp,
                DisplayRutEmpresa = serviceCliente.GetEntity(idCliente).Rut_emp,
                DisplayGerente = serviceGerente.GetEntity(idGerente).Nombre_gerente
            };
            string nombre = serviceProfesional.GetEntity(idProfesional).Nombre_prof;
            string apellido = serviceProfesional.GetEntity(idProfesional).Apellido_prof;
            string nombreProf = nombre + " " + apellido;
            clienteTarjetaCompleta.DisplayProfNombre = nombreProf;
            clienteTarjetaCompleta.DisplayMailGerente = serviceGerente.GetEntity(idGerente).Mail_gerente;
            clienteTarjetaCompleta.DisplayTelefonoEmpresa = serviceCliente.GetEntity(idCliente).Fono_cliente;
            clienteTarjetaCompleta.DisplayDireccion = serviceCliente.GetEntity(idCliente).Direccion_emp;
            //---------------------------------------------------------------------------------------------
            foreach (Actividad _actividades in serviceActividad.GetEntities())
            {
                //Debug.WriteLine("idActividad es "+idActividad);
                //Debug.WriteLine("idCliente es "+idCliente);
                //No me trae la id=1
                if (idCliente == _actividades.Cliente_id_emp)
                {
                    var tipoAct = _actividades.Tipo_actividad;
                    //Debug.WriteLine("tipo act es " + tipoAct + "idCliente es " + idCliente);
                    //Debug.WriteLine("Comparamos con " + _actividades.Tipo_actividad);
                    if (tipoAct == "Visita")
                    {
                        StackVisita stackVisita = new();
                        Debug.WriteLine("__________________________________");
                        Debug.WriteLine("El tipo de act es " + tipoAct + " idAct es " + idCliente);
                        Debug.WriteLine("__________________________________");
                        stackVisita.DisplayFechaVisita = _actividades.Fecha_act.ToString();
                        stackVisita.DisplayHoraVisita = _actividades.Hora_act.ToString();
                        clienteTarjetaCompleta.StckVisita.Children.Add(stackVisita);
                        //Debug.WriteLine("Visita " + tipoAct);
                        //Debug.WriteLine(visita);
                        //Debug.WriteLine("La visita n "+idActividad+" es el día "+date+" a la hora "+time);
                    }
                    if (tipoAct == "Capacitación")
                    {
                        StackCapacitacion stackCapacitacion = new();
                        Debug.WriteLine("__________________________________");
                        Debug.WriteLine("El tipo de act es " + tipoAct + " idAct es " + idCliente);
                        Debug.WriteLine("__________________________________");
                        Debug.WriteLine("__________________________________");
                        //stackCapacitacion.displayNombreCapacitacion = serviceCapacitacion.GetEntity(_actividades.id_act).Nombre_cap;
                        //stackCapacitacion.displayFechaCapacitacion = _actividades.Fecha_act.ToString();
                        //stackCapacitacion.displayHoraCapacitacion = _actividades.Hora_act.ToString();
                        //clienteTarjetaCompleta.stckCapacitacion.Children.Add(stackCapacitacion);
                        //Debug.WriteLine("Capacitacion "+tipoAct);
                        //Debug.WriteLine("La capacitacion n " + idActividad +" de nombre "+ name +" es el día " + date + " a la hora " + time);
                    }
                    if (tipoAct == "Act Mejora")
                    {
                        Debug.WriteLine("__________________________________");
                        Debug.WriteLine("El tipo de act es " + tipoAct + " idAct es " + idCliente);
                        Debug.WriteLine("__________________________________");
                        //Debug.WriteLine(tipoAct);
                        //Debug.WriteLine(idActividad);
                        clienteTarjetaCompleta.DisplayActMejora = serviceActMejora.GetEntity(idCliente).Nombre_act_mejora;
                        //Debug.WriteLine("La Asesoria n " + idActividad + " de nombre " + name);
                        //Debug.WriteLine("Act Mejora " + tipoAct);
                    }
                    //Debug.WriteLine("Esto es una " + tipoAct + " Comparada a Asesoria" + tipoAct.Equals("Asesoria"));
                    if (tipoAct == "Asesoria")
                    {
                        StackAsesoria stackAsesoria = new();
                        Debug.WriteLine("__________________________________");
                        Debug.WriteLine("El tipo de act es " + tipoAct + " idAct es " + idCliente);
                        Debug.WriteLine("__________________________________");
                        //Debug.WriteLine(tipoAct);
                        //Debug.WriteLine(idActividad);
                        stackAsesoria.DisplayRazonAsesoria = serviceAsesoria.GetEntity(_actividades.id_act).Razon_ases;
                        stackAsesoria.DisplayFechaAsesoria = _actividades.Fecha_act.ToString();
                        stackAsesoria.DisplayHoraAsesoria = _actividades.Hora_act.ToString();
                        clienteTarjetaCompleta.StckAsesoria.Children.Add(stackAsesoria);
                        //Debug.WriteLine(asesoria);
                        //var name = serviceAsesoria.GetEntity(_actividades.id_act).Razon_ases;
                        //var date = _actividades.Fecha_act.ToString();
                        //var time = _actividades.Hora_act.ToString();
                        //Debug.WriteLine("La "+name+" es a la fecha " + date+ " en la hora "+time);
                        //Debug.WriteLine("Asesoria " + tipoAct);
                    }
                }
            }
            return clienteTarjetaCompleta;
        }
        public void MostrarClientes()
        {
            ServiceGerente serviceGerente = new();
            foreach (Gerente _gerente in serviceGerente.GetEntities())
            {
                stckPanelTarjetas.Children.Add(CrearTarjetaCliente(_gerente.id_gerente));
            }
        }
        public static TarjetaAsesoria CrearTarjetaAsesoria(int idActividad)
        {
            ServiceActividad serviceActividad = new();
            ServiceCliente serviceCliente = new();
            ServiceProfesional serviceProfesional = new();
            ServiceGerente serviceGerente = new();
            ServiceAsesoria serviceAsesoria = new();
            var idCliente = serviceActividad.GetEntity(idActividad).Cliente_id_emp;
            var idProfesional = serviceActividad.GetEntity(idCliente).Prof_id_profe;

            TarjetaAsesoria tarjetaAsesoria = new()
            {
                DisplayNombreEmpresa = serviceCliente.GetEntity(idCliente).Nombre_emp,
                DisplayRutEmpresa = serviceCliente.GetEntity(idCliente).Rut_emp,
                DisplayNombreGerente = serviceGerente.GetEntity(idCliente).Nombre_gerente
            };
            string nombre = serviceProfesional.GetEntity(idProfesional).Nombre_prof;
            string apellido = serviceProfesional.GetEntity(idProfesional).Apellido_prof;
            string nombreProf = nombre + " " + apellido;
            tarjetaAsesoria.DisplayNombreProfesional = nombreProf;
            tarjetaAsesoria.DisplayRazon = serviceAsesoria.GetEntity(idActividad).Razon_ases;
            tarjetaAsesoria.DisplayCaso = serviceAsesoria.GetEntity(idActividad).Estado_caso;
            tarjetaAsesoria.DisplayDescripcionAsesoria = serviceAsesoria.GetEntity(idActividad).Descripcion;
            return tarjetaAsesoria;
        }
        public void MostrarAsesorias()
        {
            ServiceAsesoria serviceAsesoria = new();
            foreach (Asesoria asesorias in serviceAsesoria.GetEntities())
            {
                stckPanelTarjetas.Children.Add(CrearTarjetaAsesoria(asesorias.Actividad_id_act));
            }
        }
        public static TarjetaSolicitud CrearTarjetSolicitud(int idSolicitud)
        {
            TarjetaSolicitud tarjetaSolicitud = new();
            ServiceSolicitud serviceSolicitud = new();
            ServiceCliente serviceCliente = new();
            ServiceGerente serviceGerente = new();
            ServiceProfesional serviceProfesional = new();
            var idGerente = serviceSolicitud.GetEntity(idSolicitud).Gerente_id_gerente;
            /*
            Prueba de tarjeta por consola
            var nombreProf = serviceProfesional.GetEntity(idSolicitud).Nombre_prof;
            var nombre = serviceSolicitud.GetEntity(idSolicitud).Razon_soli;
            var nombreGere = serviceGerente.GetEntity(idGerente).Nombre_gerente;
            var nombreEmp = serviceCliente.GetEntity(idGerente).Nombre_emp;
            var rutEmp = serviceCliente.GetEntity(idGerente).Rut_emp;
            var razon = serviceSolicitud.GetEntity(idSolicitud).Razon_soli;
            Debug.WriteLine(nombre +" Profesional "+nombreProf );
            Debug.WriteLine(nombre + " Gerente " + nombreGere+" "+ idGerente);
            Debug.WriteLine(nombre + " Empresa " + nombreEmp + " " + rutEmp);
            Debug.WriteLine(razon + " janco ");
            */
            tarjetaSolicitud.DisplayNombreEmpresa = serviceCliente.GetEntity(idGerente).Nombre_emp;
            tarjetaSolicitud.DisplayRutEmpresa = serviceCliente.GetEntity(idGerente).Rut_emp;
            tarjetaSolicitud.DisplayNombreGerente = serviceGerente.GetEntity(idGerente).Nombre_gerente;
            string nombre = serviceProfesional.GetEntity(idSolicitud).Nombre_prof;
            string apellido = serviceProfesional.GetEntity(idSolicitud).Apellido_prof;
            string nombreProf = nombre + " " + apellido;
            tarjetaSolicitud.DisplayNombreProfesional = nombreProf;
            tarjetaSolicitud.DisplayNombreProfesional = nombreProf;
            tarjetaSolicitud.DisplayRazonSolicitud = serviceSolicitud.GetEntity(idSolicitud).Razon_soli;
            tarjetaSolicitud.DisplayDescripcionSolicitud = serviceSolicitud.GetEntity(idSolicitud).Descripcion;
            tarjetaSolicitud.DisplayFechaSolicitud = serviceSolicitud.GetEntity(idSolicitud).Fecha_CreacionSolicitud.ToString("dd/MM/yyyy");
            tarjetaSolicitud.DisplayHoraSolicitud = new DateTime(serviceSolicitud.GetEntity(idSolicitud).Hora_CreacionSolicitud.Ticks).ToString("hh:mm tt");
            return tarjetaSolicitud;
        }
        public void MostrarSolicitudes()
        {
            ServiceSolicitud serviceSolicitud = new();
            foreach (Solicitud _solicitudes in serviceSolicitud.GetEntities())
            {
                stckPanelTarjetas.Children.Add(CrearTarjetSolicitud(_solicitudes.id_solicitud));
            }
        }
        public static TarjetaRevision CrearTarjetaRevision(int idActividad)
        {
            ServiceActMejora serviceActMejora = new();
            ServiceActividad serviceActividad = new();
            ServiceCliente serviceCliente = new();
            ServiceGerente serviceGerente = new();
            ServiceProfesional serviceProfesional = new();
            TarjetaRevision tarjetaRevision = new();
            var nombreActMejora = serviceActMejora.GetEntity(idActividad).Nombre_act_mejora;
            var fechaAct = serviceActividad.GetEntity(idActividad).Fecha_act.ToString();
            var horaAct = serviceActividad.GetEntity(idActividad).Hora_act.ToString();
            var idCliente = serviceActividad.GetEntity(idActividad).Cliente_id_emp;
            var nombreCliente = serviceCliente.GetEntity(idCliente).Nombre_emp;
            var nombreGerente = serviceGerente.GetEntity(idCliente).Nombre_gerente;
            Debug.WriteLine(nombreActMejora + " es el día " + fechaAct + " a la hora " + horaAct);
            Debug.WriteLine(idCliente + " es su id " + nombreCliente + " es su nombre " + " y tiene un gerente llamado " + nombreGerente);
            
            tarjetaRevision.DisplayNombreEmpresa = serviceCliente.GetEntity(idCliente).Nombre_emp;
            tarjetaRevision.DisplayRutEmpresa = serviceCliente.GetEntity(idCliente).Rut_emp;
            tarjetaRevision.DisplayNombreGerente = serviceGerente.GetEntity(idCliente).Nombre_gerente;
            string nombre = serviceProfesional.GetEntity(idCliente).Nombre_prof;
            string apellido = serviceProfesional.GetEntity(idCliente).Apellido_prof;
            string nombreProf = nombre + " " + apellido;
            tarjetaRevision.DisplayNombreProfesional = nombreProf;
            tarjetaRevision.DisplayNombreActMejora = serviceActMejora.GetEntity(idActividad).Nombre_act_mejora;
            tarjetaRevision.DisplayFechaActMejora = serviceActividad.GetEntity(idActividad).Fecha_act.ToString("dd/MM/yyyy");
            tarjetaRevision.DisplayHoraActMejora = new DateTime(serviceActividad.GetEntity(idActividad).Hora_act.Ticks).ToString("hh:mm tt");
            tarjetaRevision.DisplayDescripcionActMejora = serviceActMejora.GetEntity(idActividad).Descripcion_act_mejora.ToString();
            return tarjetaRevision;
        }
        public void MostrarRevisiones()
        {
            ServiceActMejora serviceActMejora = new();
            foreach (Act_de_mejora _acts_de_mejora in serviceActMejora.GetEntities())
            {
                stckPanelTarjetas.Children.Add(CrearTarjetaRevision(_acts_de_mejora.Actividad_id_act));
            }
        }
        private void TabItemOpciones1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (TabItemOpciones1.Header.Equals("CLIENTE"))
            {
                BtnCheckList.Visibility = Visibility.Visible;
                BtnCasoAsesoria.Visibility = Visibility.Visible;
                stckPanelTarjetas.Children.Clear();
                MostrarClientes();
            }
            else if (TabItemOpciones1.Header.Equals("REVISIÓN"))
            {
                BtnCheckList.Visibility = Visibility.Collapsed;
                BtnCasoAsesoria.Visibility = Visibility.Collapsed;
                stckPanelTarjetas.Children.Clear();
                MostrarRevisiones();
            }
            else
            {
                MessageBox.Show("Work in progress");
            }
        }
        private void TabItemOpciones2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BtnCheckList.Visibility = Visibility.Collapsed;
            BtnCasoAsesoria.Visibility = Visibility.Collapsed;
            if (TabItemOpciones2.Header.Equals("ASESORIAS"))
            {
                stckPanelTarjetas.Children.Clear();
                MostrarAsesorias();
            }
            else
            {
                MessageBox.Show("Work in progress");
            }
        }
        private void TabItemOpciones3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BtnCheckList.Visibility = Visibility.Collapsed;
            BtnCasoAsesoria.Visibility = Visibility.Collapsed;
            if (TabItemOpciones3.Header.Equals("SOLICITUDES"))
            {
                stckPanelTarjetas.Children.Clear();
                MostrarSolicitudes();
            }
            else
            {
                MessageBox.Show("Work in progress");
            }
        }
        private void BtnCheckList_Click(object sender, RoutedEventArgs e)
        {
            VentanaNuevoChecklist ventanaNuevoChecklist = new();
            ventanaNuevoChecklist.ShowDialog();
        }
    }
}