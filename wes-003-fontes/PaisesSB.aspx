<%@ Page Title="Países sem BEF" Language="C#" CodeFile="~/Pages/SemBEF/PaisesSB.aspx.cs" Inherits="SemBEFPaisesSBPage" %>

<%@ Register Assembly="Benner.Tecnologia.Wes.Components.WebApp" Namespace="Benner.Tecnologia.Wes.Components.WebApp" TagPrefix="wes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <div class="row">
        <asp:Label ID="lblPais" runat="server" Text="País" />
        <asp:TextBox ID="txtPais" runat="server" />
        <asp:Button ID="btnSalva" runat="server" Text="Salvar" />
    </div>
    <div>
        <asp:GridView ID="gridPaises" runat="server" />
    </div>
</asp:Content>
