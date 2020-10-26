using Benner.Reservas.Comum;
using Benner.Reservas.Interfaces;
using Benner.Tecnologia.Business;
using Benner.Tecnologia.Business.Services;
using Benner.Tecnologia.Common;
using Benner.Tecnologia.Metadata.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benner.Reservas.Componentes.Tasks
{
    public class NotificadorReservasAprovadasTask : BusinessComponent<NotificadorReservasAprovadasTask>, INotificadorReservasAprovadas
    {
        private readonly IMailService _mailService;

        public NotificadorReservasAprovadasTask(IMailService mailService)
        {
            _mailService = mailService;
        }

        public void Run(NotificacaoReservaAprovadaRequest request)
        {
            //MailMessage.Send("danton.franco@benner.com.br",
            //     string.Join(",", request.Destinatarios),
            //     request.Titulo,
            //     request.Mensagem);

            var usuario = ZAgendamentos.Get(new Criteria("A.TIPO = 6")).Usuario.Instance; //engine de envio de e-mail
            var msg = _mailService.NewMailMessage();
            msg.SendTo = string.Join(", ", request.Destinatarios);
            msg.Subject = request.Titulo;
            msg.Body = request.Mensagem;
            msg.SystemUser = usuario.Handle; //ZGrupoUsuarios.Get("SYSDBA").Handle;
            msg.From = usuario.Email; //ZGrupoUsuarios.Get("SYSDBA").Email;
            _mailService.Send(msg);
        }
    }
}
