﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

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



public partial class SemBEFPessoasSBPage : WesPage
{
    private EntityDefinition pessoaDefinition = EntityDefinition.GetByName("PESSOAS");
    private EntityDefinition paisDefinition = EntityDefinition.GetByName("PAISES");

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        btnSalvar.Click += BtnSalvar_Click;
    }

    private void BtnSalvar_Click(object sender, EventArgs e)
    {
        Handle handle = new Handle(dropPaises.SelectedValue);
        EntityAssociation paisAssociation = new EntityAssociation(handle, paisDefinition);
        EntityBase pessoa = Entity.Create(pessoaDefinition);
        pessoa.Fields["NOME"] = txtNome.Text;
        pessoa.Fields["CPF"] = txtCPF.Text;
        pessoa.Fields["PAIS"] = paisAssociation;
        pessoa.Save();
        PintaGrid();
    }

    protected void Page_Load(object sender, System.EventArgs e)
    {
        CarregaDropPaises();
        if (!Page.IsPostBack)
        {
            PintaGrid();
        }
    }

    private void CarregaDropPaises()
    {
        var paises = Entity.GetAll(paisDefinition);
        foreach(EntityBase p in paises)
        {
            dropPaises.Items.Add(new System.Web.UI.WebControls.ListItem(p.Fields["NOME"].ToString(), p.Handle.ToString()));
        }
    }
    private void PintaGrid()
    {
        var pessoas = Entity.GetAll(pessoaDefinition);
        gridPessoas.DataSource = pessoas;
        gridPessoas.DataBind();
        gridPessoas.ApplyMetronicStyle();
    }
}
