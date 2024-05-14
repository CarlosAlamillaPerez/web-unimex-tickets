using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Home_Neg
    {
        public Cls_Usuario Metodo_Acceso_Login(string usuario, string password, string Conexion)
        {
            return (new Home_Dat().Metodo_Acceso_Login(usuario, password, Conexion));
        }
    }
}
