//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PersistenciaBD
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuarios
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
        public string rol { get; set; }
        public Nullable<int> Profecional_id_prof { get; set; }
        public Nullable<int> Cliente_id_emp { get; set; }
        public Nullable<int> Administrador_id_adm { get; set; }
    
        public virtual Administrador Administrador { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Profesional Profesional { get; set; }
    }
}
