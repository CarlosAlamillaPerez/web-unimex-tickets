using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cls_aplicaciones_seguridad
    {
        public Cls_aplicaciones_seguridad()
        { }

        private decimal _clave_usuario;
        public decimal Clave_usuario
        {
            get { return _clave_usuario; }
            set { _clave_usuario = value; }
        }

        private decimal _clave_aplicacion;
        public decimal Clave_aplicacion
        {
            get { return _clave_aplicacion; }
            set { _clave_aplicacion = value; }
        }

        private decimal _clave_nivel;
        public decimal Clave_nivel
        {
            get { return _clave_nivel; }
            set { _clave_nivel = value; }
        }

        private string _contrasena;
        public string Contrasena
        {
            get { return _contrasena; }
            set { _contrasena = value; }
        }

        private bool _estatusUsuario;
        public bool EstatusUsuario
        {
            get { return _estatusUsuario; }
            set { _estatusUsuario = value; }
        }

        private bool _estatus;
        public bool Estatus
        {
            get { return _estatus; }
            set { _estatus = value; }
        }

        private decimal _clave_nivel_acceso;
        public decimal Clave_nivel_acceso
        {
            get { return _clave_nivel_acceso; }
            set { _clave_nivel_acceso = value; }
        }

        private string _nom_aplicacion;
        public string Nom_aplicacion
        {
            get { return _nom_aplicacion; }
            set { _nom_aplicacion = value; }
        }

        private string _nom_menu;
        public string Nom_menu
        {
            get { return _nom_menu; }
            set { _nom_menu = value; }
        }

        private decimal _orden_aparicion;
        public decimal Orden_aparicion
        {
            get { return _orden_aparicion; }
            set { _orden_aparicion = value; }
        }

        private string _ruta_imagen;
        public string Ruta_imagen
        {
            get { return _ruta_imagen; }
            set { _ruta_imagen = value; }
        }

        private string _ruta_url;

        public string Ruta_url
        {
            get { return _ruta_url; }
            set { _ruta_url = value; }
        }
    }
}
