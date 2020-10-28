using System;
using Benner.Reservas.Entidades;
using Benner.Tecnologia.Business;
using Benner.Tecnologia.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Benner.Reservas.Componentes.Teste
{
    [TestClass]
    public class GerenciadorReservasTest
    {
        [TestMethod]
        [ExpectedException(typeof(BusinessException), "Teste reserva já aprovada falhou.")]
        public void ReservaAprovadaDeveLevantarExcecaoDeReservaNaoEstaAguardandoAprovacao()
        {
            var gerenciador = new GerenciadorReservas(Substitute.For<ITransactionContextFactory>(),
                                                      Substitute.For<ICarrosDao>(),
                                                      Substitute.For<IReservasDao>(),
                                                      Substitute.For<IPessoasDao>());

            var reserva = new EntityBuilder<IReservas>().Build();
            reserva.Status = ReservasStatusListaItens.ItemReservado;

            gerenciador.AprovarReserva(reserva);
        }

        [TestMethod]
        public void DevolverReservaDeItemReservadoDeveExecutarMetodoSave()
        {
            var substituteReserva = Substitute.For<IReservasDao>();

            var gerenciador = new GerenciadorReservas(Substitute.For<ITransactionContextFactory>(),
                                                      Substitute.For<ICarrosDao>(),
                                                      substituteReserva,
                                                      Substitute.For<IPessoasDao>());

            var reserva = new EntityBuilder<IReservas>().Build();
            reserva.Status = ReservasStatusListaItens.ItemReservado;
            gerenciador.DevolverReserva(reserva);
            substituteReserva.Received().Save(reserva);
        }

    }
}
