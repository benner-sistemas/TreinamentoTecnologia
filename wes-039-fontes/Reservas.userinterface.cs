using Benner.Tecnologia.Common.Scripting.UserInterface;
using System;

namespace Benner.Reservas.Entidades
{
    
    
    [ScriptUI()]
    public partial class Reservas
    {
        [ViewLoaded]
        public void ViewLoaded()
        {
            VerificaDataSolicitacao();
            MostrarQuilometragem();
        }

        public void VerificaDataSolicitacao()
        {
            if (this.DataSolicitacao.Value.AddDays(7) < DateTime.Now)
            {
                this[FieldNames.DataSolicitacao].Label = "Data de solicitação (mais 7 dias)";
            }
        }

        [FieldChanged(FieldNames.Plano)]
        public void PlanoChange()
        {
            MostrarQuilometragem();
        }

        private void MostrarQuilometragem()
        {
            this[FieldNames.Quilometragem].Visible = (this[FieldNames.Plano].GetInt32() == PlanosTipoListaItens.ItemKilometragem);
        }
    }
}
