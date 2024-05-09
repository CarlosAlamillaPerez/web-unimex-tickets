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
        public List<Cls_PlantelInfo> CargaPlanteles(string Conexion)
        {
            try
            {
                return (new Home_Dat()).CargaPlanteles(Conexion);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Cls_Usuario ValidaAcceso(string usuario, string password, string Conexion)
        {
            return (new Home_Dat().ValidaAcceso(usuario, password, Conexion));
        }
    }
}
