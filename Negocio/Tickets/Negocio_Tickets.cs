﻿using Datos.Tickets;
using Entidades.Tickets;
using System;
using System.Collections.Generic;

namespace Negocio.Tickets
{
    public class Negocio_Tickets
    {
        public List<Cls_Tickets> Metodo_Obtener_TicketsDataTable(int id_usuario, int pagina, int filas, string filtro)
        {
            try
            {
                return (new Datos_Tickets()).Metodo_Obtener_TicketsDataTable(id_usuario, pagina, filas, filtro);
            }
            catch (Exception ex) { throw ex; }
        }
        public List<Cls_Tickets> Metodo_DDL_Plantel(int clave_usuario)
        {
            try
            {
                return (new Datos_Tickets()).Metodo_DDL_Plantel(clave_usuario);
            }
            catch (Exception ex) { throw ex; }
        }
        public List<Cls_Tickets> Metodo_DDL_Soporte()
        {
            try
            {
                return (new Datos_Tickets()).Metodo_DDL_Soporte();
            }
            catch (Exception ex) { throw ex; }
        }
        public List<Cls_Tickets> Metodo_DDL_Concepto(int id_tipo_soporte)
        {
            try
            {
                return (new Datos_Tickets()).Metodo_DDL_Concepto(id_tipo_soporte);
            }
            catch (Exception ex) { throw ex; }
        }
        public List<Cls_Tickets> Btn_DataTable_Informacion(int id_ticket)
        {
            try
            {
                List<Cls_Tickets> historial = new Datos_Tickets().Btn_DataTable_Informacion(id_ticket);
                return historial;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Metodo_Obtener_TotalDataTable(string filtro, int id)
        {
            return new Datos_Tickets().Metodo_Obtener_TotalDataTable(filtro, id);
        }
        public string Metodo_Obtener_RutaArchivo(int id_ticket)
        {
            return new Datos_Tickets().Metodo_Obtener_RutaArchivo(id_ticket);
        }
        public bool Metodo_Guardar_RutaArchivo(string ruta, int id_ticket)
        {
            try
            {
                return (new Datos_Tickets()).Metodo_Guardar_RutaArchivo(ruta, id_ticket);
            }
            catch (Exception ex) { throw ex; }
        }
        public bool Metodo_EnviarCorreos_TicketGenerado(int id_ticket, int id_usuario)
        {
            try
            {
                return new Datos_Tickets().Metodo_EnviarCorreos_TicketGenerado(id_ticket, id_usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Btn_Agregar(int id_empresa, int id_concepto, string detalle, int clave_usuario)
        {
            try
            {
                return (new Datos_Tickets()).Btn_Agregar(id_empresa, id_concepto, detalle, clave_usuario);
            }
            catch (Exception ex) { throw ex; }
        }
        public bool Btn_DataTable_Eliminar(int id_ticket)
        {
            try
            {
                return (new Datos_Tickets()).Btn_DataTable_Eliminar(id_ticket);
            }
            catch (Exception ex) { throw ex; }
        }
        public bool Btn_DataTable_Calificacion_Success(int id, int calificacion, string mensaje)
        {
            try
            {
                return (new Datos_Tickets()).Btn_DataTable_Calificacion_Success(id, calificacion, mensaje);
            }
            catch (Exception ex) { throw ex; }
        }

    }
}
