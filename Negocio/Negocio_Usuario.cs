using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class Negocio_Usuario
    {
        public List<Cls_aplicaciones_seguridad> Metodo_Obtener_Acceso(decimal clave_usuario, decimal clave_aplicacion, string Conexion)
        {
            return (new Usuario_Dat()).Metodo_Obtener_Acceso(clave_usuario, clave_aplicacion, Conexion);
        }
    }
}
