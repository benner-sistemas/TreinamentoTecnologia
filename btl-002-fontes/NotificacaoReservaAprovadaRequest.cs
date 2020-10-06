using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benner.Reservas.Comum
{
    public class NotificacaoReservaAprovadaRequest
    {
        public IList<string> Destinatarios { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }

        public NotificacaoReservaAprovadaRequest()
        {
            this.Destinatarios = new List<string>();
        }

        public NotificacaoReservaAprovadaRequest(string email, string titulo, string mensagem) : this()
        {
            this.Destinatarios.Add(email);
            this.Titulo = titulo;
            this.Mensagem = mensagem;
        }
    }
}
