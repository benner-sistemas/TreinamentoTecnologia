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
    /// Nome da Tabela: CARROS.
    /// Essa é uma classe parcial, os atributos, herança e propriedades estão definidos no arquivo Carros.properties.cs
    /// </summary>
    public partial class Carros
    {
        private bool PossuiReservasAgora()
        {
            bool result = false;
            Query query = new Query($@"SELECT COUNT(*) QTDE FROM RESERVAS R
                                        WHERE R.HANDLE = { this.Handle }
                                            AND
                                        @AGORA BETWEEN R.DATAINICIO AND R.DATAFIM");
            var dados = query.Execute();
            if (dados != null && dados.Count() > 0)
            {
                result = dados[0]["QTDE"].GetInt32() > 0;
            }
            return result;
        }

        public void Desativar(BusinessArgs args)
        {
            if (PossuiReservasAgora())
            {
                throw new BusinessException("Este carro não pode ser desativado, pois possui reservas ativas no momento!");
            }
            if (!this.Ativo.Value)
            {
                throw new BusinessException("Este carro já está inativo");
            }
            this.Ativo = false;
            this.Observacoes += $"Carro desativado em: { DateTime.Now.ToString("dd/MM/yyyy hh:mm") }.\n";
            this.Save();
        }
    }
}
