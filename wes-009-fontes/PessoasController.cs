using Benner.Reservas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/// <summary>
/// Summary description for PessoasController
/// </summary>
public class PessoasController : Controller
{
    public PessoasController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public ActionResult Salvar([Bind(Include = "txtNome, txtCpf, selPais")] DadosPessoa dadosPessoa)
    {
        Pessoas pessoa = Pessoas.Create();
        pessoa.Nome = dadosPessoa.TxtNome;
        pessoa.Cpf = dadosPessoa.TxtCpf;
        pessoa.PaisHandle = dadosPessoa.SelPais;
        pessoa.Save();
        ViewBag.Paises = Paises.GetAll();
        ViewBag.Pessoas = Pessoas.GetAll();
        return View("Index", ViewBag);
    }

    public ActionResult Index()
    {
        ViewBag.Paises = Paises.GetAll();
        ViewBag.Pessoas = Pessoas.GetAll();
        return View(ViewBag);
    }

}

public class DadosPessoa
{
    public string TxtNome { get; set; }
    public string TxtCpf { get; set; }
    public int SelPais { get; set; }
}