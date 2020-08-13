using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benner.Reservas.Comum
{
    public class NovaReservaRequest
    {
        public long HandlePessoa { get; set; }
        public long HandleModeloCarro { get; set; }
        public long HandlePlano { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
