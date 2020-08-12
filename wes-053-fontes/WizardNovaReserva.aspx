<%@ Page Title="Wizard Nova Reserva" Language="C#" CodeFile="~/Pages/Reservas/WizardNovaReserva.aspx.cs" Inherits="ReservasWizardNovaReservaPage" %>

<%@ Register Assembly="Benner.Tecnologia.Wes.Components.WebApp" Namespace="Benner.Tecnologia.Wes.Components.WebApp" TagPrefix="wes" %>
<%@ Register Assembly="Benner.Tecnologia.Wes.Components" Namespace="Benner.Tecnologia.Wes.Components" TagPrefix="wes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <style>
        .alert.alert-info:not(.alert-request-confirmation) {
            display: none;
        }

        .btn-save i {
            float: right;
            padding: 4px 0 0 8px !important
        }
    </style>

    <asp:updatepanel id="UPStep" runat="server" updatemode="Always" xmlns:asp="http://www.asp.net"><ContentTemplate><asp:HiddenField runat="server" ID="CurrentStep" Value="1" ClientIDMode="Static" /></ContentTemplate></asp:updatepanel>
    <div class="portlet light" id="form_wizard">
        <div class="portlet-body form">
            <div class="form-wizard">
                <div class="form-body">
                    <ul class="nav nav-pills nav-justified steps">
                        <li><a data-toggle="tab" class="step" href="#tab1"><span class="number">1</span><span class="desc"><i class="fa fa-check"></i>Pessoa</span></a></li>
                        <li><a data-toggle="tab" class="step" href="#tab2"><span class="number">2</span><span class="desc"><i class="fa fa-check"></i>Reserva</span></a></li>
                        <li><a data-toggle="tab" class="step" href="#tab3"><span class="number">3</span><span class="desc"><i class="fa fa-check"></i>Confirmação</span></a></li>
                    </ul>
                    <div id="bar" class="progress progress-striped" role="progressbar">
                        <div class="progress-bar progress-bar-success"></div>
                    </div>
                    <div class="tab-content">
                        <div class="tab-pane active" id="tab1">
                            <div class="row">
                                <wes:AjaxForm runat="server" ID="PESSOA" Title="Pessoa" Subtitle="" PortletCssClass="" PortletLayout="Default" BootstrapCols="12" FontIcon="" ShowTitle="false" ProviderWidgetUniqueId="" ChromeState="Fixed" CanDelete="True" CanUpdate="True" CanInsert="True" EntityViewName="VT_WIZARD_PESSOA.FORM" FormMode="None" IncludeRecordInRecentItems="True" UserDefinedCommandsVisible="True" PageId="PAGES_RESERVAS_WIZARDNOVARESERVA" Level="20" Order="10" />
                            </div>
                        </div>
                        <div class="tab-pane" id="tab2">
                            <div class="row">
                                <wes:AjaxForm runat="server" ID="RESERVA" Title="Reserva" Subtitle="" PortletCssClass="" PortletLayout="Default" BootstrapCols="12" FontIcon="" ShowTitle="false" ProviderWidgetUniqueId="" ChromeState="Fixed" CanDelete="True" CanUpdate="True" CanInsert="True" EntityViewName="VT_WIZARD_RESERVA.FORM" FormMode="None" IncludeRecordInRecentItems="True" UserDefinedCommandsVisible="True" PageId="PAGES_RESERVAS_WIZARDNOVARESERVA" Level="20" Order="20" />
                            </div>
                        </div>
                        <div class="tab-pane" id="tab3">
                            <asp:UpdatePanel ID="UPConfirmacao" runat="server" UpdateMode="Always">
                                <ContentTemplate>
                                    <% if (CurrentStep.Value.Equals("3"))
                                        { %>
                                    <div class="row">
                                        <span>Verifique os dados antes de confirmar a reserva.</span>
                                        <wes:RequestConfirmationControl runat="server" ID="ConfirmacaoControl" Visible="false" Message="Deseja realmente cancelar a reserva?"></wes:RequestConfirmationControl>
                                    </div>
                                    <div class="form-actions top-menu nobg no-border commands-bar fluid">
                                        <asp:LinkButton runat="server"
                                            ID="Voltar"
                                            OnClick="Voltar_Click"
                                            CssClass="btn command-action custom-action default">
                                            <i class="fa fa-chevron-circle-left btn-action"></i> Voltar
                                        </asp:LinkButton>
                                        <asp:LinkButton runat="server"
                                            ID="Concluir"
                                            OnClick="Concluir_Click"
                                            CssClass="btn blue command-action predef-action editable">
                                            <i class="fa fa-check btn-action"></i> Concluir
                                        </asp:LinkButton>
                                        <asp:LinkButton runat="server"
                                            ID="Cancelar"
                                            OnClick="Cancelar_Click"
                                            CssClass="btn grey-silver btn-cancel command-action predef-action editable">
                                            <i class="fa fa-times btn-action"></i> Cancelar
                                        </asp:LinkButton>
                                    </div>
                                    <div class="row static-info">
                                        <div class="col-lg-2 col-md-2 col-sm-6 col-xs-6">
                                            Nome:
                                        </div>
                                        <div class="col-lg-4 col-md-4 col-sm-6 col-xs-6">
                                            <%=this.VtPessoa.PessoaJaECadastrada == Benner.Reservas.Entradas.VtWizardPessoaPessoaJaECadastradaTabItens.ItemSim
                                            ? this.VtPessoa.PessoaInstance.Nome : this.VtPessoa.Nome %>
                                        </div>
                                        <div class="col-lg-2 col-md-2 col-sm-6 col-xs-6">
                                            Modelo carro:
                                        </div>
                                        <div class="col-lg-4 col-md-4 col-sm-6 col-xs-6">
                                            <%= this.VtReserva.ModeloCarroInstance.Nome %>
                                        </div>
                                    </div>
                                    <div class="row static-info">
                                        <div class="col-lg-2 col-md-2 col-sm-6 col-xs-6">
                                            Data início:
                                        </div>
                                        <div class="col-lg-4 col-md-4 col-sm-6 col-xs-6">
                                            <%= this.VtReserva.DataInicio %>
                                        </div>
                                        <div class="col-lg-2 col-md-2 col-sm-6 col-xs-6">
                                            Data fim:
                                        </div>
                                        <div class="col-lg-4 col-md-4 col-sm-6 col-xs-6">
                                            <%= this.VtReserva.DataFim %>
                                        </div>
                                    </div>
                                    <% } %>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            // default form wizard
            $('#form_wizard').bootstrapWizard({
                onTabClick: function (tab, navigation, index, clickedIndex) {
                    return false;
                },
                onNext: function (tab, navigation, index) {
                },
                onPrevious: function (tab, navigation, index) {
                },
                onTabShow: function (tab, navigation, index) {
                    var total = navigation.find('li').length;
                    var current = index + 1;
                    var $percent = (current / total) * 100;
                    $('#form_wizard').find('.progress-bar').css({
                        width: $percent + '%'
                    });
                }
            });

            selectCurrentStep = function () {
                var currentStep = $("#CurrentStep").val();
                $('[href="#tab' + currentStep + '"]').tab('show');
            };

            changeCommandsOrder = function () {
                $(".tab-pane.active .custom-action").each(function (index) {
                    let save = $(".tab-pane.active .btn-save").eq(index);
                    $(save).before(this);
                    $(this).after("&nbsp;");
                });
            };

            // Application event handlers for component developers.
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            if (!prm.get_isInAsyncPostBack()) {
                prm.add_endRequest(function (sender, args) {
                    selectCurrentStep();
                    changeCommandsOrder(0);
                    changeCommandsOrder(1);
                });
            }

            selectCurrentStep();
        });
    </script>
</asp:Content>
