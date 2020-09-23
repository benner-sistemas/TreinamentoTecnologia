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
    /// Nome da Tabela: PLANOS.
    /// Essa é uma classe parcial, os atributos, herança e propriedades estão definidos no arquivo Planos.properties.cs
    /// </summary>
    public partial class Planos
    {
        public static void AjustaValorReferencia(BusinessArgs args)
        {
            var planos = Planos.GetAll();
            foreach (var plano in planos)
            {
                var valorAtual = plano.ValorReferencia;
                plano.ValorReferencia = valorAtual + (valorAtual * Convert.ToDecimal(args.DataEntity.Fields["PERCENTUAL"]) / 100);
                plano.Save();
            }
            args.Message = "Atualização bem sucedida!!!";
        }
    }
}
