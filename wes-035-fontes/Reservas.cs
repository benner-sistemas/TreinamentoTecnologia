using Benner.Tecnologia.Business;
using Benner.Tecnologia.Business.Validation;
using Benner.Tecnologia.Common;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;


namespace Benner.Reservas.Entidades
{
    
    
    /// <summary>
    /// Nome da Tabela: RESERVAS.
    /// Essa é uma classe parcial, os atributos, herança e propriedades estão definidos no arquivo Reservas.properties.cs
    /// </summary>
    public partial class Reservas
    {
        public override void Validate(ValidationResults validationResults)
        {
            if(this.DataInicio > this.DataFim)
            {
                validationResults.AddResult(new EntityValidationResult("A data final não pode ser menor que a data inicial!"));
            }
            base.Validate(validationResults);
        }

        protected override void Saving()
        { 
            if (this.State == EntityState.Initialized)
            {
                this.DataSolicitacao = DateTime.Now;
            }

            if (this.DataFim > this.PlanoInstance.DataFim)
            {
                throw new BusinessException("Plano já estará vencido na data de devolução!");
            }

            string mensagem = "Esta reserva custará R$ ";

            if (this.PlanoInstance.Tipo == PlanosTipoListaItens.ItemKilometragem)
            {
                if (this.Kilometragem != null && this.Kilometragem.Value > 0m)
                {
                    mensagem += this.PlanoInstance.ValorReferencia.Value * this.Kilometragem;
                }
            }
            else if (this.PlanoInstance.Tipo == PlanosTipoListaItens.ItemDiaria)
            {
                int numeroDias = (this.DataFim - this.DataInicio).Value.Days;
                mensagem += this.PlanoInstance.ValorReferencia * numeroDias;
            }
            else if (this.PlanoInstance.Tipo == PlanosTipoListaItens.ItemValorFechado)
            {
                mensagem += this.PlanoInstance.ValorReferencia;
            }
            this.Observacoes = mensagem;
            base.Saving();
        }

        protected override void Saved()
        {
            DocumentosFinanceiros documentosFinanceiros = DocumentosFinanceiros.Create();
            documentosFinanceiros.Valor = 0;
            documentosFinanceiros.Tipo = DocumentosFinanceirosTipoListaItens.ItemCredito;
            documentosFinanceiros.Save();

            ReservaDocumentos reservaDocumentos = ReservaDocumentos.Create();
            reservaDocumentos.ReservaInstance = this;
            reservaDocumentos.DocumentoFinanceiro.Instance = documentosFinanceiros;
            reservaDocumentos.Save();

            base.Saved();
        }
    }
}
