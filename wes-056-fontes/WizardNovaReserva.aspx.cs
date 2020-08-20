﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

using Benner.Reservas.Comum;
using Benner.Reservas.Entradas;
using Benner.Tecnologia.Common;
using Benner.Tecnologia.Common.Components;
using Benner.Tecnologia.Wes.Components;
using Benner.Tecnologia.Wes.Components.WebApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class ReservasWizardNovaReservaPage : WesPage
{
    public VtWizardReserva VtReserva
    {
        get
        {
            return RESERVA.GetEntity() as VtWizardReserva;
        }
    }

    public VtWizardPessoa VtPessoa
    {
        get
        {
            return PESSOA.GetEntity() as VtWizardPessoa;
        }
    }

    protected void Page_Load(object sender, System.EventArgs e)
    {
        PESSOA.CommandExecuted += PESSOA_CommandExecuted;
        RESERVA.CommandExecuted += RESERVA_CommandExecuted;
        RESERVA.CommandExecute += RESERVA_CommandExecute;
        ConfirmacaoControl.Command += ConfirmacaoControl_Command;
    }

    private void ConfirmacaoControl_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandArgument.Equals(true.ToString()))
        {
            CancelaOperacao();
        }
        else
        {
            ConfirmacaoControl.Visible = false;
        }
    }

    private void RESERVA_CommandExecute(object sender, FormCommandExecuteArgs e)
    {
        if (e.CommandName.Equals(PredefinedAction.ActionType.Cancel.ToString()))
        {
            (sender as AjaxForm).EntityViewCommands.Commands["Cancel"].RequestConfirmation = true;
            (sender as AjaxForm).EntityViewCommands.Commands["Cancel"].RequestConfirmationMessage = "Deseja realmente cancelar a reserva?";
        }
        if (e.ConfirmationAccepted)
        {
            CancelaOperacao();
        }
    }

    private void CancelaOperacao()
    {
        FormLinkDefinition link = new FormLinkDefinition();
        link.Url = "~/Pages/Reservas/WizardNovaReserva.aspx";
        var url = Benner.Tecnologia.Wes.Components.UriBuilder.Create(link);
        Response.Redirect(url);
    }

    private void RESERVA_CommandExecuted(object sender, FormCommandExecuteArgs e)
    {
        if (e.CommandName.Equals(PredefinedAction.ActionType.Save.ToString()))
        {
            CurrentStep.Value = 3.ToString();
        }
        else if (e.CommandName.Equals("CMD_Voltar"))
        {
            CurrentStep.Value = 1.ToString();
        }
    }

    private void PESSOA_CommandExecuted(object sender, FormCommandExecuteArgs e)
    {
        CurrentStep.Value = 2.ToString();
    }

    protected void Voltar_Click(object sender, EventArgs e)
    {
        ConfirmacaoControl.Visible = false;
        CurrentStep.Value = 2.ToString();
    }

    protected void Concluir_Click(object sender, EventArgs e)
    {
        if (VtPessoa.PessoaJaECadastrada == VtWizardPessoaPessoaJaECadastradaTabItens.ItemSim)
        {
            var request = new NovaReservaRequest();
            request.HandlePessoa = VtPessoa.PessoaHandle;
            request.HandleModeloCarro = VtReserva.ModeloCarroHandle;
            request.HandlePlano = VtReserva.PlanoHandle;
            request.DataInicio = VtReserva.DataInicio.Value;
            request.DataFim = VtReserva.DataFim != null ? VtReserva.DataFim.Value : VtReserva.DataInicio.Value.AddDays(7);

            var response = BennerContext.BusinessComponent.Call("Benner.Reservas.Componentes.GerenciadorReservas, Benner.Reservas.Componentes",
                "CriarNovaReserva",
                (object)request) as NovaReservaResponse;

            FormLinkDefinition linkDef = new FormLinkDefinition();
            linkDef.Url = "~/Pages/Reservas/Form.aspx";
            linkDef.TargetSystemInstanceName = BennerContext.Administration.DefaultSystemInstanceName;
            linkDef.TargetEntityDefinitionName = "RESERVAS";
            linkDef.TargetFormMode = FormLinkDefinition.FormMode.View;
            linkDef.TargetEntityHandle = response.HandleReservaCriada;

            Response.Redirect(Benner.Tecnologia.Wes.Components.UriBuilder.Create(linkDef));
        }
        else
        {
            var request = new NovaPessoaNovaReservaRequest();
            request.Nome = VtPessoa.Nome;
            request.Cpf = VtPessoa.Cpf;
            request.Email = VtPessoa.Email;
            request.TelefoneMovel = VtPessoa.TelefoneMovel;
            request.HandleModeloCarro = VtReserva.ModeloCarroHandle;
            request.HandlePlano = VtReserva.PlanoHandle;
            request.DataInicio = VtReserva.DataInicio.Value;
            request.DataFim = VtReserva.DataFim != null ? VtReserva.DataFim.Value : VtReserva.DataInicio.Value.AddDays(7);

            var response = BennerContext.BusinessComponent.Call("Benner.Reservas.Componentes.GerenciadorReservas, Benner.Reservas.Componentes",
                "CriarNovaPessoaEReserva",
                (object)request) as NovaPessoaNovaReservaResponse;

            FormLinkDefinition linkDef = new FormLinkDefinition();
            linkDef.Url = "~/Pages/Pessoas/Form.aspx?novaReserva";
            linkDef.TargetSystemInstanceName = BennerContext.Administration.DefaultSystemInstanceName;
            linkDef.TargetEntityDefinitionName = "PESSOAS";
            linkDef.TargetFormMode = FormLinkDefinition.FormMode.View;
            linkDef.TargetEntityHandle = response.HandlePessoaCriada;

            Response.Redirect(Benner.Tecnologia.Wes.Components.UriBuilder.Create(linkDef));
        }
    }

    protected void Cancelar_Click(object sender, EventArgs e)
    {
        ConfirmacaoControl.Visible = true;
    }
}
