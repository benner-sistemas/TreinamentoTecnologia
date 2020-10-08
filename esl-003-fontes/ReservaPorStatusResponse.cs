using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benner.Reservas.Comum
{
    public class ReservaPorStatusResponse
    {
        public string Pessoa { get; set; }
        public string Plano { get; set; }
        public string Carro { get; set; }
        public int Status { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
