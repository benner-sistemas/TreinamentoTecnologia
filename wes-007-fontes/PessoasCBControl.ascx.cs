using Benner.Reservas.Entidades;
using Benner.Tecnologia.Common;
using Benner.Tecnologia.Wes.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class uc_PessoasCBControl : System.Web.UI.UserControl
{

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        btnSalvar.Click += BtnSalvar_Click;
    }

    private void BtnSalvar_Click(object sender, EventArgs e)
    {
        Paises pais = Paises.Get(new Handle(dropPaises.SelectedValue));
        Pessoas pessoa = Pessoas.Create();
        pessoa.Nome = txtNome.Text;
        pessoa.Cpf = txtCPF.Text;
        pessoa.PaisInstance = pais;
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
        var paises = Paises.GetAll();
        foreach (Paises p in paises)
        {
            dropPaises.Items.Add(new System.Web.UI.WebControls.ListItem(p.Nome, p.Handle.ToString()));
        }
    }
    private void PintaGrid()
    {
        var pessoas = Pessoas.GetAll();
        gridPessoas.DataSource = pessoas;
        gridPessoas.DataBind();
        gridPessoas.ApplyMetronicStyle();
    }

}