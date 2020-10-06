using Benner.Reservas.Comum;
using Benner.Tecnologia.Business.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benner.Reservas.Interfaces
{
    public interface INotificadorReservasAprovadas : IBusinessTaskAction<NotificacaoReservaAprovadaRequest>
    {
    }
}
