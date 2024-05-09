using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicketsSistemas.UserControl
{
    public partial class Message : System.Web.UI.UserControl
    {
        #region enums
        /// <summary>
        ///     Determina que botones se mostraran
        /// </summary>
        public enum EnumBotones { AbortRetryIgnore, OK, OKCancel, RetryCancel, YesNo, YesNoCancel }
        /// <summary>
        ///     Determina que imagen se mostrara
        /// </summary>
        public enum EnumImages { Aceptar, Cancelar, Aviso, Preguntar }
        #endregion

        #region EventArguments
        public class wucMessageBoxEventArgs : EventArgs
        {
            public readonly string Comando;
            public wucMessageBoxEventArgs(string Comando)
            {
                this.Comando = Comando;
            }
        }
        #endregion

        #region clsMsg
        /// <summary>
        /// Clase para guardar mensaje
        /// </summary>
        public class clsMsg
        {
            #region Constructor
            public clsMsg()
            {
                Titulo = string.Empty;
                Mensaje = string.Empty;
                Detalle = string.Empty;
            }
            public clsMsg(string Titulo, string Mensaje, string Detalle)
            {
                _titulo = Titulo;
                _Mensaje = Mensaje;
                _Detalle = Detalle;
            }

            public clsMsg(string Titulo, string Mensaje)
            {
                _titulo = Titulo;
                _Mensaje = Mensaje;

            }
            #endregion

            #region filds
            private string _titulo;
            private string _Mensaje;
            private string _Detalle;
            #endregion

            #region Propiedades
            public string Titulo { get { return _titulo; } set { _titulo = value; } }
            public string Mensaje { get { return _Mensaje; } set { _Mensaje = value; } }
            public string Detalle { get { return _Detalle; } set { _Detalle = value; } }
            #endregion
        }

        #endregion
        public delegate void ControlCommandHandler(object sender, wucMessageBoxEventArgs e);
        public event ControlCommandHandler ControlCommand;
        protected void OnControlCommand(object sender, wucMessageBoxEventArgs e)
        {
            if (ControlCommand != null)
            {
                ControlCommand(sender, e);
            }
        }

        #region propiedades        
        public int widthMessage
        {
            set
            {
                CelMensaje.Width = value <= 150 ? 150 : value;
                pnlDetalle.Width = value <= 150 ? 250 : value;
            }
        }
        public int heightMessage
        {
            set
            {
                CelMensaje.Height = value;
                pnlDetalle.Height = value / 2;
            }
        }
        #endregion

        #region eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    btnAceptar.Attributes.Add("onClick", "habilitar(false);");
                    btnCancelar.Attributes.Add("onClick", "habilitar(false);");
                    btnSi.Attributes.Add("onClick", "habilitar(false);");
                    btnNo.Attributes.Add("onClick", "habilitar(false);");
                    btnReintentar.Attributes.Add("onClick", "habilitar(false);");
                    btnAnular.Attributes.Add("onClick", "habilitar(false);");
                    btnOmitir.Attributes.Add("onClick", "habilitar(false);");
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            try
            {
                mpeSeleccion.Hide();
                OnControlCommand(sender, new wucMessageBoxEventArgs(((Button)sender).ID.Substring(3)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region metodos
        public void Show(clsMsg Mensage, EnumBotones botones, EnumImages imagenes)
        {
            try
            {
                MuestraBotones(botones);
                MuestraImagen(imagenes);
                lblTitulo.Text = Mensage.Titulo;
                lblMensaje.Text = Mensage.Mensaje;
                pnlDetalle.Visible = Mensage.Detalle == null ? false : true;
                lblDetalle.Text = Mensage.Detalle;
                mpeSeleccion.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void MuestraBotones(EnumBotones botones)
        {
            try
            {
                switch (botones)
                {
                    case EnumBotones.AbortRetryIgnore:
                        btnAceptar.Visible = false;
                        btnCancelar.Visible = false;
                        btnSi.Visible = false;
                        btnNo.Visible = false;
                        btnReintentar.Visible = true;
                        btnAnular.Visible = true;
                        btnOmitir.Visible = true;

                        break;
                    case EnumBotones.OK:
                        btnAceptar.Visible = true;
                        btnCancelar.Visible = false;
                        btnSi.Visible = false;
                        btnNo.Visible = false;
                        btnReintentar.Visible = false;
                        btnAnular.Visible = false;
                        btnOmitir.Visible = false;
                        break;
                    case EnumBotones.OKCancel:
                        btnAceptar.Visible = true;
                        btnCancelar.Visible = true;
                        btnSi.Visible = false;
                        btnNo.Visible = false;
                        btnReintentar.Visible = false;
                        btnAnular.Visible = false;
                        btnOmitir.Visible = false;
                        break;
                    case EnumBotones.RetryCancel:
                        btnAceptar.Visible = false;
                        btnCancelar.Visible = true;
                        btnSi.Visible = false;
                        btnNo.Visible = false;
                        btnReintentar.Visible = true;
                        btnAnular.Visible = false;
                        btnOmitir.Visible = false;
                        break;
                    case EnumBotones.YesNo:
                        btnAceptar.Visible = false;
                        btnCancelar.Visible = false;
                        btnSi.Visible = true;
                        btnNo.Visible = true;
                        btnReintentar.Visible = false;
                        btnAnular.Visible = false;
                        btnOmitir.Visible = false;
                        break;
                    case EnumBotones.YesNoCancel:
                        btnAceptar.Visible = false;
                        btnCancelar.Visible = true;
                        btnSi.Visible = true;
                        btnNo.Visible = true;
                        btnReintentar.Visible = false;
                        btnAnular.Visible = false;
                        btnOmitir.Visible = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void MuestraImagen(EnumImages Imagen)
        {
            try
            {
                switch (Imagen)
                {
                    case EnumImages.Aceptar:
                        imgIcon.ImageUrl = "~/Imagenes/Botones/Mensajes/Aceptar.svg";
                        break;
                    case EnumImages.Cancelar:
                        imgIcon.ImageUrl = "~/Imagenes/Botones/Mensajes/Cancelar.svg";
                        break;
                    case EnumImages.Aviso:
                        imgIcon.ImageUrl = "~/Imagenes/Botones/Mensajes/Aviso.svg";
                        break;
                    case EnumImages.Preguntar:
                        imgIcon.ImageUrl = "~/Imagenes/Botones/Mensajes/Preguntar.svg";
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}