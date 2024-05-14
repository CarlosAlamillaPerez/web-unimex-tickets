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
        private string _usuario;
        private string _nombre;
        private string _ap_paterno;
        private string _ap_materno;
        private bool _estatus;
        private string _password;
        
        public decimal  ClaveUsuario    {   set { _claveusuario = value;    }   get { return _claveusuario; }   }
        public string   Usuario         {   set { _usuario = value;         }   get { return _usuario;      }   }
        public string   Nombre          {   set { _nombre = value;          }   get { return _nombre;       }   }
        public string   ap_paterno      {   set { _ap_paterno = value;      }   get { return _ap_paterno;   }   }
        public string   ap_materno      {   set { _ap_materno = value;      }   get { return _ap_materno;   }   }
        public bool     Estatus         {   set { _estatus = value;         }   get { return _estatus;      }   }
        public string   Password        {   set { _password = value;        }   get { return _password;     }   }
    }
}
