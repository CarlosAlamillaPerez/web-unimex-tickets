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
                using (SqlCommand cmd = new SqlCommand("spLoginUserAppAcceso", con))
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

        //Validar Usuario y password
        public Cls_Usuario ValidarUserPass(string usuario, string password, string Conexion)
        {
            Cls_Usuario Loginuser = null;
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                using (SqlCommand cmd = new SqlCommand("spLoginUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@usuario", usuario.Trim());
                    cmd.Parameters.AddWithValue("@password", password.Trim());

                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Loginuser = (new Cls_Usuario()
                            {
                                Clave_usuario = (decimal)dr["clave_usuario"],
                                Usuario = (string)dr["usuario"],
                                Password = (string)dr["password"],
                                Ap_paterno = (string)dr["ap_paterno"],
                                Ap_materno = (string)dr["ap_materno"],
                                Nombre = (string)dr["nombre"],
                                Estatus = (bool)dr["estatus"],
                                Id_empresa = (decimal)dr["id_empresa"],
                                Usuario_sql = (Guid)dr["usuario_sql"],
                                Sexo = (string)dr["sexo"],
                                Correo = (string)dr["correo"]

                            });

                        }

                    }
                }
            }
            return Loginuser;
        }

        //Validar caracteristicas de seguridad de la contraseña
        public Cls_Usuario ValidarUserPassSecurity(string password, string Conexion)
        {
            Cls_Usuario Loginuser = null;
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                using (SqlCommand cmd = new SqlCommand("spvalidaCaracteristicas", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@password", password.Trim());

                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Loginuser = (new Cls_Usuario()
                            {
                                Password = (string)dr["password"],
                                Salida = Convert.ToDecimal(dr["salida"])

                            });

                        }

                    }
                }
            }
            return Loginuser;
        }
    }
}
