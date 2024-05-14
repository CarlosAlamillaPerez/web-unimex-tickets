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
        public List<Cls_PlantelInfo> CargaPlanteles(string Conexion)
        {
            List<Cls_PlantelInfo> list = new List<Cls_PlantelInfo>();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spMostarEmpreAll", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        con.Open();

                        using (DbDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                list.Add(new Cls_PlantelInfo()
                                {
                                    Id_empresa = (decimal)dr["id_empresa"],
                                    Nombre_empresa = (string)dr["nombre_empresa"],
                                    Base_nom = (string)dr["base_nom"],
                                    Dsn = (string)dr["dsn"],
                                    Ip_address = (string)dr["ip_address"],
                                    Etiqueta_pantallas1 = (string)dr["etiqueta_pantallas1"],
                                    Etiqueta_pantallas2 = (string)dr["etiqueta_pantallas2"]
                                });
                            }
                        }
                    }
                }
                return list;
            }
            catch (Exception err)
            {
                return null;
            }
        }
        public Cls_Usuario ValidaAcceso(string usuario, string password, string conexion)
        {
            Cls_Usuario Loginuser = null;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                using (SqlCommand cmd = new SqlCommand("spLoginUser", con))
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
