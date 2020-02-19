<%@ Page Title="Pessoas com BEF" Language="C#" CodeFile="~/Pages/ComBEF/PessoasCB.aspx.cs" Inherits="ComBEFPessoasCBPage" %>

<%@ Register Assembly="Benner.Tecnologia.Wes.Components.WebApp" Namespace="Benner.Tecnologia.Wes.Components.WebApp" TagPrefix="wes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <div class="row">
        <asp:Label ID="lblNome" runat="server" Text="Nome" />
        <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" />
        <asp:Label ID="lblCPF" runat="server" Text="CPF" />
        <asp:TextBox ID="txtCPF" runat="server" CssClass="form-control" />
        <asp:Label ID="lblPais" runat="server" Text="País" />
        <asp:DropDownList ID="dropPaises" runat="server" CssClass="form-control" />
        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn blue" />
    </div>
    <div class="portlet light">
        <asp:GridView ID="gridPessoas" runat="server" />
    </div>
</asp:Content>
