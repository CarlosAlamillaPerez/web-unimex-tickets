<%@ Page Language="C#" MasterPageFile="~/MASTERPAGE/MasterPage.Master" AutoEventWireup="true" CodeBehind="MensajeError.aspx.cs" Inherits="TicketsSistemas.MensajeError" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControl/Message.ascx" TagPrefix="UCMessageBox" TagName="Msgbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:TextBox ID="txtmensaje" runat="server" TextMode="MultiLine" Enabled="false" Style="margin-top: 3%; resize: none; height: 70%; width: 100%; font-family: Arial, Helvetica, Sans-serif; color: white; background-color: #004f93; font-size: 21px;"></asp:TextBox>


    <div class="ref-div">
        <UCMessageBox:Msgbox ID="Msgbox" runat="server" EnableViewState="true" />
    </div>
</asp:Content>
