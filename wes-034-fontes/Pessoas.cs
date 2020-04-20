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
    /// Nome da Tabela: PESSOAS.
    /// Essa é uma classe parcial, os atributos, herança e propriedades estão definidos no arquivo Pessoas.properties.cs
    /// </summary>
    public partial class Pessoas
    {
        public override void Validate(ValidationResults validationResults)
        {
            if (!this.Cpf.IsValidCPF())
            {
                validationResults.AddResult(new EntityValidationResult("CPF é inválido!!!"));
            }
            base.Validate(validationResults);
        }
    }
}
