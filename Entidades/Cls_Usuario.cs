using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cls_Usuario
    {
        private decimal _claveusuario;

        public decimal ClaveUsuario
        {
            set { _claveusuario = value; }
            get { return _claveusuario; }
        }

        private string _usuario;

        public string Usuario
        {
            set { _usuario = value; }
            get { return _usuario; }
        }

        private string _nombre;

        public string Nombre
        {
            set { _nombre = value; }
            get { return _nombre; }
        }

        private string _ap_paterno;

        public string ap_paterno
        {
            set { _ap_paterno = value; }
            get { return _ap_paterno; }
        }

        private string _ap_materno;

        public string ap_materno
        {
            set { _ap_materno = value; }
            get { return _ap_materno; }
        }

        private bool _estatus;

        public bool Estatus
        {
            get { return _estatus; }
            set { _estatus = value; }
        }

        private int _clavenivelacceso;

        public int ClaveNivelAcceso
        {
            set { _clavenivelacceso = value; }
            get { return _clavenivelacceso; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public decimal Clave_usuario { get; set; }
        public string Ap_paterno { get; set; }
        public string Ap_materno { get; set; }
        public decimal Id_empresa { get; set; }
        public Guid Usuario_sql { get; set; }
        public string Sexo { get; set; }
        public string Correo { get; set; }
        public decimal Salida { get; set; }
    }
}
