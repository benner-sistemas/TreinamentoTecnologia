<%@ Page Title="Consulta Disponíveis" Language="C#" CodeFile="~/Pages/Carros/ConsultaDisponiveis.aspx.cs" Inherits="CarrosConsultaDisponiveisPage" %>

<%@ Register Assembly="Benner.Tecnologia.Wes.Components.WebApp" Namespace="Benner.Tecnologia.Wes.Components.WebApp" TagPrefix="wes" %>
<%@ Register Assembly="Benner.Tecnologia.Wes.Components" Namespace="Benner.Tecnologia.Wes.Components" TagPrefix="wes" %>
<%@ Register Assembly="Benner.Tecnologia.Wes.Components" Namespace="Benner.Tecnologia.Wes.Components.UI" TagPrefix="wes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">

        <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 widget">
            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">
                        Busca Carros Disponíveis
                    </div>
                </div>

                <div class="portlet-body form">
                    <div class="row">
                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                            <wes:SearchControl ID="Modelo" runat="server"></wes:SearchControl>
                        </div>

                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                            <asp:TextBox runat="server"
                                ID="Dia"
                                MaxLength="10"
                                class="form-control datepicker placeholder-no-fix"
                                placeholder="dd/mm/aaaa"
                                data-date-format="dd/mm/yyyy"
                                data-type="date">
                            </asp:TextBox>
                        </div>
                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                            <asp:LinkButton ID="Busca"
                                runat="server"
                                OnClick="Busca_Click"
                                CssClass="btn blue">
                                Buscar
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>


</asp:Content>
