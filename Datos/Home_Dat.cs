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
    public class Home_Dat
    {
        public Cls_Usuario Metodo_Acceso_Login(string usuario, string password, string conexion)
        {
            Cls_Usuario Loginuser = null;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Tickets_Metodo_Obtener_AccesoLogin", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@usuario", usuario.Trim());
                    cmd.Parameters.AddWithValue("@password", password.Trim());

                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Loginuser = new Cls_Usuario()
                            {
                                ClaveUsuario = (decimal)dr["clave_usuario"],
                                Usuario = (string)dr["usuario"],
                                Password = (string)dr["password"],
                                ap_paterno = (string)dr["ap_paterno"],
                                ap_materno = (string)dr["ap_materno"],
                                Nombre = (string)dr["nombre"],
                                Estatus = (bool)dr["estatus"]
                            };
                        }
                    }
                }
            }
            return Loginuser;
        }
    }
}
