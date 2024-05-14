using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Usuario_Dat
    {
        public List<Cls_aplicaciones_seguridad> ValidarUsarioAccesoApp(decimal clave_usuario, decimal clave_aplicacion, string Conexion)
        {
            List<Cls_aplicaciones_seguridad> LoginAplicacionUser = new List<Cls_aplicaciones_seguridad>();
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Tickets_Metodo_Acceso_Login", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@clave_usuario", clave_usuario);
                    cmd.Parameters.AddWithValue("@clave_aplicacion", clave_aplicacion);
                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LoginAplicacionUser.Add(new Cls_aplicaciones_seguridad()
                            {
                                Clave_usuario = Convert.ToDecimal(dr["clave_usuario"]),
                                Clave_aplicacion = Convert.ToDecimal(dr["clave_aplicacion"]),
                                Clave_nivel_acceso = Convert.ToDecimal(dr["clave_nivel_acceso"]),
                                Estatus = Convert.ToBoolean(dr["estatus"])
                            });
                        }
                    }
                }
            }
            return LoginAplicacionUser;
        }
    }
}
