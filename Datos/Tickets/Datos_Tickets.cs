using System;
using System.Web;
using Entidades;
using System.Net.Mail;
using System.Net;
using Entidades.Tickets;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Datos.Tickets
{
    public class Datos_Tickets
    {
        private SqlConnection cadenaConexion;
        private SqlConnection conexionM;

        public Datos_Tickets()
        {
            ClsDesEncripta oDesEnc = new ClsDesEncripta();
            string BaseGeneralReg = ConfigurationManager.ConnectionStrings["ConSistemas"].ConnectionString;
            string partereg = oDesEnc.Desencripta(ConfigurationManager.ConnectionStrings["ConexionMP"].ConnectionString);
            cadenaConexion = new SqlConnection(BaseGeneralReg.ToString().Trim() + partereg.ToString().Trim());
        }

        public List<Cls_Tickets> Metodo_Obtener_TicketsDataTable(int id_usuario, int pagina, int filas, string filtro)
        {
            try
            {
                List<Cls_Tickets> lista = new List<Cls_Tickets>();

                ClsDesEncripta oDesEnc = new ClsDesEncripta();
                string BaseGeneralReg = ConfigurationManager.ConnectionStrings["ConSistemas"].ConnectionString;
                string partereg = oDesEnc.Desencripta(ConfigurationManager.ConnectionStrings["ConexionMP"].ConnectionString);
                cadenaConexion = new SqlConnection(BaseGeneralReg.ToString().Trim() + partereg.ToString().Trim());

                using (SqlCommand cmd = new SqlCommand("sp_TicketsTable", cadenaConexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                    cmd.Parameters.AddWithValue("@pagina", pagina);
                    cmd.Parameters.AddWithValue("@cantidad_filas", filas);
                    cmd.Parameters.AddWithValue("@filtro", filtro);

                    cadenaConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Cls_Tickets ticket = new Cls_Tickets
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                //Usuario = dr["Usuario"].ToString(),
                                Concepto = dr["Concepto"].ToString(),
                                Incidencia = dr["Incidencia"].ToString(),
                                Generado = dr["Generado"].ToString(),
                                Inicio = dr["Inicio"].ToString(),
                                Fin = dr["Fin"].ToString(),
                                Calificado = dr["Calificado"].ToString(),
                                AtencionTicket = dr["AtencionTicket"].ToString(),
                                Calificacion = dr["Calificacion"].ToString()
                            };
                            lista.Add(ticket);
                        }
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cadenaConexion.State == ConnectionState.Open)
                {
                    cadenaConexion.Close();
                }
            }
        }
        public List<Cls_Tickets> Metodo_Obtener_TicketsDataTable2(int id_usuario, int pagina, int filas, string filtro)
        {
            try
            {
                List<Cls_Tickets> lista = new List<Cls_Tickets>();

                ClsDesEncripta oDesEnc = new ClsDesEncripta();
                string BaseGeneralReg = ConfigurationManager.ConnectionStrings["ConSistemas"].ConnectionString;
                string partereg = oDesEnc.Desencripta(ConfigurationManager.ConnectionStrings["ConexionMP"].ConnectionString);
                cadenaConexion = new SqlConnection(BaseGeneralReg.ToString().Trim() + partereg.ToString().Trim());

                using (SqlCommand cmd = new SqlCommand("sp_TicketsTable_2", cadenaConexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                    cmd.Parameters.AddWithValue("@pagina", pagina);
                    cmd.Parameters.AddWithValue("@cantidad_filas", filas);
                    cmd.Parameters.AddWithValue("@filtro", filtro);

                    cadenaConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Cls_Tickets ticket = new Cls_Tickets
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                //Usuario = dr["Usuario"].ToString(),
                                Concepto = dr["Concepto"].ToString(),
                                Incidencia = dr["Incidencia"].ToString(),
                                Generado = dr["Generado"].ToString(),
                                Inicio = dr["Inicio"].ToString(),
                                Fin = dr["Fin"].ToString(),
                                //Calificado = dr["Calificado"].ToString(),
                                Status = dr["Status"].ToString(),
                                AtencionTicket = dr["AtencionTicket"].ToString()
                                //Calificacion = dr["Calificacion"].ToString()
                            };
                            lista.Add(ticket);
                        }
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cadenaConexion.State == ConnectionState.Open)
                {
                    cadenaConexion.Close();
                }
            }
        }
        public List<Cls_Tickets> Metodo_Obtener_CorreosNuevoTicket(int id_usuario)
        {
            try
            {
                List<Cls_Tickets> lst = new List<Cls_Tickets>();

                ClsDesEncripta oDesEnc = new ClsDesEncripta();
                string BaseGeneralReg = ConfigurationManager.ConnectionStrings["ConexionM"].ConnectionString;
                string partereg = oDesEnc.Desencripta(ConfigurationManager.ConnectionStrings["ConexionMP"].ConnectionString);
                conexionM = new SqlConnection(BaseGeneralReg.ToString().Trim() + partereg.ToString().Trim());

                using (SqlCommand cmd = new SqlCommand("sp_CorreoAltaTickets", conexionM))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_usuario", id_usuario);

                    conexionM.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Cls_Tickets ticket = new Cls_Tickets
                            {
                                nombre = dr["nombre"].ToString(),
                                id_puesto = Convert.ToInt32(dr["id_puesto"]),
                                puesto = dr["puesto"].ToString(),
                                ubicacion = dr["ubicacion"].ToString(),
                                id_empresa = Convert.ToInt32(dr["id_empresa"]),
                                nombre_empresa = dr["nombre_empresa"].ToString(),
                                correo = dr["correo"].ToString()
                            };
                            lst.Add(ticket);
                        }
                    }
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conexionM.State == ConnectionState.Open)
                {
                    conexionM.Close();
                }
            }
        }
        public List<Cls_Tickets> Metodo_DDL_Plantel(int clave_usuario)
        {
            try
            {
                List<Cls_Tickets> Lst = new List<Cls_Tickets>();

                SqlCommand cmd = new SqlCommand("sp_Muestra_Planteles_Tickets", cadenaConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@clave_usuario", clave_usuario);
                cmd.CommandTimeout = 0;

                cadenaConexion.Open();
                DbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Lst.Add(new Cls_Tickets()
                    {
                        id_empresa = Convert.ToInt32(dr["id_empresa"]),
                        nombre_empresa = Convert.ToString(dr["nombre_empresa"])
                    });
                }
                return Lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlConnection error = new SqlConnection();
                if (error.State != ConnectionState.Closed)
                    error.Close();
                error.Dispose();
            }
        }
        public List<Cls_Tickets> Metodo_DDL_Soporte()
        {
            try
            {
                List<Cls_Tickets> Lst = new List<Cls_Tickets>();

                SqlCommand cmd = new SqlCommand("sp_MuestraCatTipoSoporte", cadenaConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                cadenaConexion.Open();
                DbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Lst.Add(new Cls_Tickets()
                    {
                        id_tipo_soporte = Convert.ToInt32(dr["id_tipo_soporte"]),
                        ds_tipo_soporte = Convert.ToString(dr["ds_tipo_soporte"])
                    });
                }
                return Lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlConnection error = new SqlConnection();
                if (error.State != ConnectionState.Closed)
                    error.Close();
                error.Dispose();
            }
        }
        public List<Cls_Tickets> Metodo_DDL_Concepto(int id_tipo_soporte)
        {
            try
            {
                List<Cls_Tickets> Lst = new List<Cls_Tickets>();

                SqlCommand cmd = new SqlCommand("sp_MuestraCatConceptos", cadenaConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_tipo_soporte", id_tipo_soporte);
                cmd.CommandTimeout = 0;

                cadenaConexion.Open();
                DbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Lst.Add(new Cls_Tickets()
                    {
                        id_concepto = Convert.ToInt32(dr["id_concepto"]),
                        ds_concepto = Convert.ToString(dr["ds_concepto"])
                    });
                }
                return Lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlConnection error = new SqlConnection();
                if (error.State != ConnectionState.Closed)
                    error.Close();
                error.Dispose();
            }
        }

        public int Metodo_Obtener_TotalDataTable(string filtro,int id)
        {
            int total = 0;

            ClsDesEncripta oDesEnc = new ClsDesEncripta();
            string BaseGeneralReg = ConfigurationManager.ConnectionStrings["ConSistemas"].ConnectionString;
            string partereg = oDesEnc.Desencripta(ConfigurationManager.ConnectionStrings["ConexionMP"].ConnectionString);
            cadenaConexion = new SqlConnection(BaseGeneralReg.ToString().Trim() + partereg.ToString().Trim());

            using (SqlCommand cmd = new SqlCommand("select dbo.fn_dataTable_total(@filtro,@id_usuario)", cadenaConexion))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@filtro", filtro);
                cmd.Parameters.AddWithValue("@id_usuario", id);

                cadenaConexion.Open();

                total = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }
            return total;
        }
        public int Metodo_Obtener_TotalDataTable2(string filtro,int id)
        {
            int total = 0;

            ClsDesEncripta oDesEnc = new ClsDesEncripta();
            string BaseGeneralReg = ConfigurationManager.ConnectionStrings["ConSistemas"].ConnectionString;
            string partereg = oDesEnc.Desencripta(ConfigurationManager.ConnectionStrings["ConexionMP"].ConnectionString);
            cadenaConexion = new SqlConnection(BaseGeneralReg.ToString().Trim() + partereg.ToString().Trim());

            using (SqlCommand cmd = new SqlCommand("select dbo.fn_dataTable_total_atendido(@filtro,@id_usuario)", cadenaConexion))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@filtro", filtro);
                cmd.Parameters.AddWithValue("@id_usuario", id);

                cadenaConexion.Open();

                total = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }
            return total;
        }
        public string Metodo_Obtener_RutaArchivo(int id_ticket)
        {
            string ruta = "";
            try
            {
                using (cadenaConexion)
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Tickets_Metodo_Obtener_RutaArchivo", cadenaConexion))
                    {
                        cmd.Parameters.AddWithValue("@id_ticket", id_ticket);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cadenaConexion.Open();

                        ruta = cmd.ExecuteScalar() as string;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cadenaConexion.State != ConnectionState.Closed)
                    cadenaConexion.Close(); 
            }
            return ruta;
        }
        public bool Metodo_Guardar_RutaArchivo(string ruta, int id_ticket)
        {
            bool correcto = false;
            try
            {
                using (cadenaConexion)
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Tickets_Metodo_Guardar_RutaArchivo", cadenaConexion))
                    {
                        cmd.Parameters.AddWithValue("@id_ticket", id_ticket);
                        cmd.Parameters.AddWithValue("@ruta", ruta);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cadenaConexion.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                correcto = true;
            }
            catch (Exception ex)
            {
                correcto = false;
                throw ex;
            }
            finally
            {
                SqlConnection error = new SqlConnection();
                if (error.State != ConnectionState.Closed)
                    error.Close();
                error.Dispose();
            }
            return correcto;
        }
        public bool Metodo_EnviarCorreos_TicketGenerado(int id_ticket, string nombre_usuario, string incidencia, int id_usuario)
        {
            try
            {
                // Obtener los correos de la base de datos "ConexionM"
                List<Cls_Tickets> correos = Metodo_Obtener_CorreosNuevoTicket(id_usuario);

                // Configura el objeto System.Net.Mail.MailMessage
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                message.From = new System.Net.Mail.MailAddress(ConfigurationManager.AppSettings["EmisorEmail"].ToString(), "Administrador Unimex");
                message.Subject = "Nuevo Ticket de Soporte - Portal de Sistemas";
                message.Priority = System.Net.Mail.MailPriority.High;
                message.IsBodyHtml = true;

                // Configura el objeto System.Net.Mail.SmtpClient
                System.Net.Mail.SmtpClient ClienteSmtp = new System.Net.Mail.SmtpClient();
                ClienteSmtp.Host = ConfigurationManager.AppSettings["Host"].ToString();
                ClienteSmtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"].ToString());
                System.Net.NetworkCredential Credenciales = new System.Net.NetworkCredential();
                Credenciales.UserName = ConfigurationManager.AppSettings["EmisorEmail"].ToString();
                Credenciales.Password = ConfigurationManager.AppSettings["EmisorEmailPsw"].ToString();
                ClienteSmtp.Credentials = Credenciales;
                ClienteSmtp.EnableSsl = true;
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

                foreach (Cls_Tickets correo in correos)
                {
                    string nombreUsuario = correo.nombre;
                    string destinatario = correo.correo;

                    // Cuerpo del correo utilizando concatenación de cadenas
                    var body = "Estimado(a) usuario(a) " + nombreUsuario + ", Buen día.<br/><br/>" +
                        "Te informamos que se acaba de levantar el ticket #" + id_ticket + ", el soporte fue solicitado por " + nombre_usuario + ".<br/><br/>" +
                        "Los detalles de la incidencia son: " + incidencia + "<br/><br/>" +
                        "Por favor ingresa al Portal de Sistemas, para dar seguimiento al ticket levantado.<br/><br/>" +
                        "Atentamente: Gerencia Corporativa de Cómputo y Sistemas.";

                    message.Body = body;
                    message.To.Clear();
                    message.To.Add(new System.Net.Mail.MailAddress(destinatario.Trim()));

                    // Enviar el correo
                    ClienteSmtp.Send(message);
                }

                // Liberar los recursos
                message.Dispose();
                ClienteSmtp.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al enviar el correo electrónico: " + ex.Message, ex);
            }
        }

        public int Btn_Agregar(int id_empresa, int id_concepto, string detalle, int clave_usuario)
        {
            int id = 0;
            try
            {
                using (cadenaConexion)
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Tickets_Btn_Agregar", cadenaConexion))
                    {
                        cmd.Parameters.AddWithValue("@id_empresa", id_empresa);
                        cmd.Parameters.AddWithValue("@id_concepto", id_concepto);
                        cmd.Parameters.AddWithValue("@detalle", detalle);
                        cmd.Parameters.AddWithValue("@clave_usuario", clave_usuario);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cadenaConexion.Open();

                        id = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlConnection error = new SqlConnection();
                if (error.State != ConnectionState.Closed)
                    error.Close();
                error.Dispose();
            }
            return id;
        }
        public bool Btn_DataTable_Eliminar(int id_ticket)
        {
            bool correcto = false;
            try
            {
                using (cadenaConexion)
                {
                    using (SqlCommand cmd = new SqlCommand("spTicketsSistemas_EliminaTicket", cadenaConexion))
                    {
                        cmd.Parameters.AddWithValue("@id_ticket", id_ticket);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cadenaConexion.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                correcto = true;
            }
            catch (Exception ex)
            {
                correcto = false;
                throw ex;
            }
            finally
            {
                SqlConnection error = new SqlConnection();
                if (error.State != ConnectionState.Closed)
                    error.Close();
                error.Dispose();
            }
            return correcto;
        }
        public bool Btn_DataTable_Calificacion_Success(int id, int calificacion)
        {
            bool correcto = false;
            try
            {
                using (cadenaConexion)
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Tickets_Btn_Calificacion_Success", cadenaConexion))
                    {
                        cmd.Parameters.AddWithValue("@id_ticket", id);
                        cmd.Parameters.AddWithValue("@id_calificacion", calificacion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cadenaConexion.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                correcto = true;
            }
            catch (Exception ex)
            {
                correcto = false;
                throw ex;
            }
            finally
            {
                SqlConnection error = new SqlConnection();
                if (error.State != ConnectionState.Closed)
                    error.Close();
                error.Dispose();
            }
            return correcto;
        }
        public bool Btn_DataTable_Calificacion_Error(int id, string mensaje)
        {
            bool correcto = false;
            try
            {
                using (cadenaConexion)
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Tickets_Btn_Calificacion_Error", cadenaConexion))
                    {
                        cmd.Parameters.AddWithValue("@id_ticket", id);
                        cmd.Parameters.AddWithValue("@mensaje", mensaje);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cadenaConexion.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                correcto = true;
            }
            catch (Exception ex)
            {
                correcto = false;
                throw ex;
            }
            finally
            {
                SqlConnection error = new SqlConnection();
                if (error.State != ConnectionState.Closed)
                    error.Close();
                error.Dispose();
            }
            return correcto;
        }
    }
}
