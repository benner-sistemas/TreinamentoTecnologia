using Benner.Reservas.Comum;
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
        private readonly ITransactionContextFactory _transactionContextFactory;
        private readonly ICarrosDao _carrosDao;
        private readonly IReservasDao _reservasDao;
        private readonly IPessoasDao _pessoasDao;

        public GerenciadorReservas(ITransactionContextFactory transactionContextFactory, ICarrosDao carrosDao, IReservasDao reservasDao, IPessoasDao pessoasDao)
        {
            _transactionContextFactory = transactionContextFactory;
            _carrosDao = carrosDao;
            _reservasDao = reservasDao;
            _pessoasDao = pessoasDao;
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
            }
            else
            {
                reserva.Status = ReservasStatusListaItens.ItemRecusado;
                mensagem = "Reserva Recusada! Não existem carros do modelo selecionado no período requisitado!";
            }
            _reservasDao.Save(reserva);

            return mensagem;
        }

        public NovaPessoaNovaReservaResponse CriarNovaPessoaEReserva(NovaPessoaNovaReservaRequest request)
        {
            NovaPessoaNovaReservaResponse response = new NovaPessoaNovaReservaResponse();
            using (ITransactionContext tc = _transactionContextFactory.Begin())
            {
                var handlePessoa = _pessoasDao.CriarPessoaSemRegraNegocio(request.Nome, request.Cpf, request.Email, request.TelefoneMovel);

                var reserva = _reservasDao.Create();
                reserva.PessoaHandle = handlePessoa;
                reserva.ModeloCarroHandle = request.HandleModeloCarro;
                reserva.PlanoHandle = request.HandlePlano;
                reserva.DataInicio = request.DataInicio;
                reserva.DataFim = request.DataFim;
                reserva.DataSolicitacao = DateTime.Now;

                _reservasDao.Save(reserva);

                response.HandleReservaCriada = reserva.Handle;
                response.HandlePessoaCriada = handlePessoa;

                tc.Complete();
            }
            return response;
        }

        public NovaReservaResponse CriarNovaReserva(NovaReservaRequest request)
        {
            NovaReservaResponse response = new NovaReservaResponse();

            var reserva = _reservasDao.Create();
            reserva.ModeloCarroHandle = request.HandleModeloCarro;
            reserva.PessoaHandle = request.HandlePessoa;
            reserva.PlanoHandle = request.HandlePlano;
            reserva.DataInicio = request.DataInicio;
            reserva.DataFim = request.DataFim;

            _reservasDao.Save(reserva);

            response.HandleReservaCriada = reserva.Handle;

            return response;
        }

        public string DevolverReserva(IReservas reserva)
        {
            string mensagem = string.Empty;

            if (reserva.Status == ReservasStatusListaItens.ItemReservado)
            {
                reserva.Status = ReservasStatusListaItens.ItemDevolvido;
                mensagem = "Reservas devolvida com sucesso!";
            }
            else
            {
                throw new BusinessException("Esta reserva não está efetiva - Status reservada!");
            }
            _reservasDao.Save(reserva);
            return mensagem;
        }

        public string RecusarReserva(IReservas reserva)
        {
            string mensagem = string.Empty;

            if (reserva.Status == ReservasStatusListaItens.ItemAguardandoAprovacao)
            {
                reserva.Status = ReservasStatusListaItens.ItemRecusado;
                mensagem = "Reserva recusada com sucesso!";
            }
            else
            {
                throw new BusinessException("A reserva não pode ser recusada, pois não está aguardando aprovação!");
            }
            _reservasDao.Save(reserva);

            return mensagem;
        }

        public ReservaPorStatusResponse[] ReservasPorStatus(int status)
        {
            var reservas = _reservasDao.ReservasPorStatusEspecifico(status);
            var response = CriaListaReservas(reservas);
            return response.ToArray();
        }

        public ReservaPorStatusResponse[] ReservasPorStatusData(ReservaPorStatusRequest request)
        {
            var reservas = _reservasDao.ReservasPorStatusEspecifico(request.Status, request.DataInicio, request.DataFim);
            var response = CriaListaReservas(reservas);
            return response.ToArray();
        }

        private List<ReservaPorStatusResponse> CriaListaReservas(IList<IReservas> reservas)
        {
            var result = new List<ReservaPorStatusResponse>();
            foreach (var reserva in reservas)
            {
                var reservaResponse = new ReservaPorStatusResponse();
                reservaResponse.Pessoa = reserva.PessoaInstance.Nome;
                reservaResponse.Plano = reserva.PlanoInstance.Identificador;
                reservaResponse.Carro = reserva.CarroInstance?.Identificador;
                reservaResponse.Status = reserva.Status;
                reservaResponse.DataInicio = reserva.DataInicio.Value;
                reservaResponse.DataFim = reserva.DataFim.Value;
                result.Add(reservaResponse);
            }
            return result;
        }
    }
}
