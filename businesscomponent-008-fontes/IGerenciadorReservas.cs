using Benner.Reservas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benner.Reservas.Interfaces
{
    public interface IGerenciadorReservas
    {
        string AprovarReserva(IReservas reserva);

        string DevolverReserva(IReservas reserva);

        string RecusarReserva(IReservas reserva);
    }
}
