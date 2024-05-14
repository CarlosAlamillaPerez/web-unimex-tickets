using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Tickets
{
    public class Cls_Tickets
    {
        // Metodo_DDL_Concepto
        public int id_concepto { get; set; }
        public string ds_concepto { get; set; }
        // Metodo_DDL_Soporte
        public int id_tipo_soporte { get; set; }
        public string ds_tipo_soporte { get; set; }

        // Metodo_DDL_Plantel
        public int id_empresa { get; set; } // Utiliza: Metodo_Obtener_CorreosNuevoTicket
        public string nombre_empresa { get; set; }

        // Metodo_Obtener_CorreosNuevoTicket
        public string nombre { get; set; }
        public int id_puesto { get; set; }
        public string puesto { get; set; }
        public string ubicacion { get; set; }
        public string correo { get; set; }

        // Metodo_Obtener_TicketsDataTable
        public int Id { get; set; }
        public int HasFile { get; set; }
        public string Concepto { get; set; }
        public string Incidencia { get; set; }//Utiliza: Btn_DataTable_Informacion
        public string Generado { get; set; }
        public string Inicio { get; set; }
        public string Fin { get; set; }
        public string Calificado { get; set; }
        public string AtencionTicket { get; set; }
        public string Calificacion { get; set; } // Utiliza: Btn_DataTable_Informacion
        public string Status { get; set; }

        // Btn_DataTable_Informacion
        public string Asistente { get; set; }
        public string Soporte { get; set; }
        public string FechaIniciado { get; set; }
        public string Usuario { get; set; }
        public string FechaProceso { get; set; }
        public string UsuarioAtiende { get; set; }
        public string FechaAtendido { get; set; }
        public string Observaciones { get; set; }
        public string FechaCerrado { get; set; }
        public string ObsCerrado { get; set; }
        public string TiempoRespuesta { get; set; }

    }
}
