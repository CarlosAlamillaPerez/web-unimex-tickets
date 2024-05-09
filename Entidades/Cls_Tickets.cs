using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Tickets
{
    public class Cls_Tickets
    {
        public int id_concepto { get; set; }
        public string ds_concepto { get; set; }

        public int id_tipo_soporte { get; set; }
        public string ds_tipo_soporte { get; set; }

        public int id_empresa { get; set; }
        public string nombre_empresa { get; set; }

        public int id_calificacion { get; set; }
        public string ds_calificacion { get; set; }

        public int cerrar_id_ticket { get; set; }
        public string cerrar_nombre_empresa { get; set; }
        public string cerrar_ds_concepto { get; set; }
        public string cerrar_detalle { get; set; }
        public string cerrar_fecha_iniciado { get; set; }
        public int cerrar_id_calificacion { get; set; }
        public string cerrar_fecha_proceso { get; set; }
        public string cerrar_fecha_atendido { get; set; }
        public string cerrar_obs_atendido { get; set; }
        public string cerrar_fecha_cerrado { get; set; }
        public string cerrar_obs_cerrado { get; set; }
        public string usuario_levanta { get; set; }
        public string usuario_atiende { get; set; }
        public string gv_ruta_evidencia { get; set; }
        public string tiempo_respuesta { get; set; }
        public string correo_atiende { get; set; }


        public int id_estatus { get; set; }
        public string ds_estatus { get; set; }
    }
}
