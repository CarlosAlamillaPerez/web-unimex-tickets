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
        public List<Cls_aplicaciones_seguridad> ValidarUsarioAccesoApp(decimal clave_usuario, decimal clave_aplicacion, string Conexion)
        {
            return (new Usuario_Dat()).ValidarUsarioAccesoApp(clave_usuario, clave_aplicacion, Conexion);
        }
    }
}
