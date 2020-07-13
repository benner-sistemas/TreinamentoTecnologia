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
    public class GerenciadorReservas : BusinessComponent<GerenciadorReservas>, IGerenciadorReservas
    {
        private readonly ICarrosDao _carrosDao;
        private readonly IReservasDao _reservasDao;

        public GerenciadorReservas(ICarrosDao carrosDao, IReservasDao reservasDao)
        {
            _carrosDao = carrosDao;
            _reservasDao = reservasDao;
        }

        public string AprovarReserva(IReservas reserva)
        {
            string mensagem = string.Empty;

            if (reserva.Status != ReservasStatusListaItens.ItemAguardandoAprovacao)
            {
                throw new BusinessException("Esta reserva não está aguardando aprovação!");
            }

            var carrosDisponiveis = _carrosDao.CarrosDisponiveisPorModeloEPeriodo(reserva.ModeloCarroHandle, reserva.DataInicio.Value, reserva.DataFim.Value);

            if (carrosDisponiveis != null && carrosDisponiveis.Count > 0)
            {
                reserva.CarroHandle = carrosDisponiveis[0]["HANDLE"].GetInt32();
                reserva.Status = ReservasStatusListaItens.ItemReservado;
                mensagem = "Reserva aprovada com sucesso!!!";
            } else
            {
                reserva.Status = ReservasStatusListaItens.ItemRecusado;
                mensagem = "Reserva Recusada! Não existem carros do modelo selecionado no período requisitado!";
            }
            _reservasDao.Save(reserva);

            return mensagem;
        }
    }
}
