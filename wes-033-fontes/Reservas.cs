using Benner.Tecnologia.Business;
using Benner.Tecnologia.Common;
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
        protected override void Saving()
        { 
            if (this.State == EntityState.Initialized)
            {
                this.DataSolicitacao = DateTime.Now;
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
    }
}
