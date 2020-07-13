using Benner.Reservas.Entidades;
using Benner.Reservas.Interfaces;
using Benner.Tecnologia.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benner.Reservas.Componentes
{
    public class GerenciadorReservas : IGerenciadorReservas
    {
        public string AprovarReserva(IReservas reserva)
        {
            string mensagem = string.Empty;

            if (reserva.Status != ReservasStatusListaItens.ItemAguardandoAprovacao)
            {
                throw new BusinessException("Esta reserva não está aguardando aprovação!");
            }

            return mensagem;
        }
    }
}
