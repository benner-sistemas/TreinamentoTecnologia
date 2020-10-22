using Benner.Reservas.Comum;
using Benner.Reservas.Interfaces;
using Benner.Tecnologia.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benner.Reservas.Componentes.Tasks
{
    public class NotificadorReservasAprovadasTask : BusinessComponent<NotificadorReservasAprovadasTask>, INotificadorReservasAprovadas
    {
        public void Run(NotificacaoReservaAprovadaRequest request)
        {
            MailMessage.Send("danton.franco@benner.com.br",
                 string.Join(",", request.Destinatarios),
                 request.Titulo,
                 request.Mensagem);
        }
    }
}
