using Benner.Reservas.Entidades;
using Benner.Reservas.Interfaces;
using Benner.Tecnologia.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benner.Reservas.Componentes.Teste
{
    [TestClass]
    public class GerenciadorReservasBITTest
    {
        [TestMethod]
        public void CriarEAprovarReservaComCarroDisponivelDeveAtribuirStatusReservado()
        {
            using (var transaction = new TransactionContext())
            {
                // Arrange
                var gerenciador = BusinessComponent.CreateInstance<IGerenciadorReservas>();
                var reservasDao = ReservasDao.CreateInstance();

                IReservas reserva = reservasDao.Create();
                reserva.PlanoHandle = 1;
                reserva.PessoaHandle = 1;
                reserva.Status = ReservasStatusListaItens.ItemAguardandoAprovacao;
                reserva.ModeloCarroHandle = 10; // Na nossa base Fiat 147
                reserva.DataInicio = DateTime.Now.AddMonths(1);
                reserva.DataFim = DateTime.Now.AddMonths(1).AddDays(5);

                // Act
                gerenciador.AprovarReserva(reserva);

                // Assert
                reserva = reservasDao.Get(reserva.Handle); // Buscar da base
                Assert.AreEqual(ReservasStatusListaItens.ItemReservado, reserva.Status);
                Assert.AreEqual(10, reserva.CarroInstance.ModeloHandle);

                //transaction.Complete();// Rollback
            }
        }

        [TestMethod]
        public void AprovarReservaComCarroDisponivelDeveAtribuirStatusReservado()
        {
            // Arrange
            var carrosDao = CarrosDao.CreateInstance();
            var reservasDao = new MockReservasDaoComSaveGet();
            var gerenciador = new GerenciadorReservas(Substitute.For<ITransactionContextFactory>(),
                                                      carrosDao,
                                                      reservasDao,
                                                      Substitute.For<IPessoasDao>());
            IReservas reserva = Entidades.Reservas.Get(6);
            reserva.Status = ReservasStatusListaItens.ItemAguardandoAprovacao;
            reserva.ModeloCarroHandle = 10; // Na nossa base Fiat 147
            reserva.DataInicio = DateTime.Now.AddMonths(6);
            reserva.DataFim = DateTime.Now.AddMonths(6).AddDays(5);

            // Act
            gerenciador.AprovarReserva(reserva);

            // Assert
            reserva = reservasDao.Get(reserva.Handle);
            Assert.AreEqual(ReservasStatusListaItens.ItemReservado, reserva.Status);
            Assert.AreEqual(10, reserva.CarroInstance.ModeloHandle);
        }


    }
}
