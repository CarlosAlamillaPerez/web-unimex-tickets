using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TicketsSistemas.Infraestructura
{
    public class FactoryConection
    {
        #region [Establece Conexión]
        public string GeneraConexion(int clavePlantel)
        {

            var conexion = string.Empty;
            var password = new EncryptedStrings().Desencripta(ConfigurationManager.ConnectionStrings["ConexionMP"].ToString());

            try
            {
                switch (clavePlantel)
                {
                    case 2: //Izacalli
                        conexion = ConfigurationManager.ConnectionStrings["ConexionIZC"].ToString();
                        break;
                    case 3: //Satelite
                        conexion = ConfigurationManager.ConnectionStrings["ConexionSAT"].ToString();
                        break;
                    case 4: //Polanco
                        conexion = ConfigurationManager.ConnectionStrings["ConexionPOL"].ToString();
                        break;
                    case 5: //Veracruz
                        conexion = ConfigurationManager.ConnectionStrings["ConexionVER"].ToString();
                        break;
                    case 6: //Milenio General
                        conexion = ConfigurationManager.ConnectionStrings["ConexionMG"].ConnectionString;
                        break;
                    case 7: //Milenio
                        conexion = ConfigurationManager.ConnectionStrings["ConexionM"].ToString();
                        break;
                    case 8:
                        conexion = ConfigurationManager.ConnectionStrings["ConSistemas"].ToString();
                        break;
                    case 9:
                        conexion = ConfigurationManager.ConnectionStrings["ConProv01"].ToString();
                        break;
                    case 10:
                        conexion = ConfigurationManager.ConnectionStrings["ConProv02"].ToString();
                        break;
                    case 11:
                        conexion = ConfigurationManager.ConnectionStrings["ConProv03"].ToString();
                        break;
                    case 12:
                        conexion = ConfigurationManager.ConnectionStrings["ConProv04"].ToString();
                        break;
                    case 13:
                        conexion = ConfigurationManager.ConnectionStrings["ConProv05"].ToString();
                        break;
                    case 14:
                        break;
                }
                return conexion + password;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}