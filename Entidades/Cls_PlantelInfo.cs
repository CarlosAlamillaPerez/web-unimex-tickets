using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cls_PlantelInfo
    {
        // constructor 
        public Cls_PlantelInfo()
        { }

        private decimal _id_empresa;

        public decimal Id_empresa
        {
            get { return _id_empresa; }
            set { _id_empresa = value; }
        }

        private string _nombre_empresa;

        public string Nombre_empresa
        {
            get { return _nombre_empresa; }
            set { _nombre_empresa = value; }
        }

        private string _base_nom;

        public string Base_nom
        {
            get { return _base_nom; }
            set { _base_nom = value; }
        }

        private string _dsn;

        public string Dsn
        {
            get { return _dsn; }
            set { _dsn = value; }
        }

        private string _ip_address;

        public string Ip_address
        {
            get { return _ip_address; }
            set { _ip_address = value; }
        }

        private string _etiqueta_pantallas1;

        public string Etiqueta_pantallas1
        {
            get { return _etiqueta_pantallas1; }
            set { _etiqueta_pantallas1 = value; }
        }

        private string _etiqueta_pantallas2;

        public string Etiqueta_pantallas2
        {
            get { return _etiqueta_pantallas2; }
            set { _etiqueta_pantallas2 = value; }
        }

        private string _banner;

        public string Banner
        {
            get { return _banner; }
            set { _banner = value; }
        }
        private bool _act_cat_generales;

        public bool Act_cat_generales
        {
            get { return _act_cat_generales; }
            set { _act_cat_generales = value; }
        }
    }
}
