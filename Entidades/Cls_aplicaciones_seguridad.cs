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
        private decimal _clave_aplicacion;
        private bool _estatus;
        private decimal _clave_nivel_acceso;
        
        public decimal Clave_usuario        { get { return _clave_usuario;      }  set { _clave_usuario = value;        }   }
        public decimal Clave_aplicacion     { get { return _clave_aplicacion;   }  set { _clave_aplicacion = value;     }   }
        public bool Estatus                 { get { return _estatus;            }  set { _estatus = value;              }   }
        public decimal Clave_nivel_acceso   { get { return _clave_nivel_acceso; }  set { _clave_nivel_acceso = value;   }   }
    }
}
