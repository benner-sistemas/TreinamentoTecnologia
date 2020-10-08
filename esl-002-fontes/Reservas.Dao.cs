using Benner.Tecnologia.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benner.Reservas.Entidades
{
    public partial interface IReservasDao
    {
        bool ExisteReservaAgora(Handle carro);
        IList<IReservas> ReservasPorStatusEspecifico(int status);
        IList<IReservas> ReservasPorStatusEspecifico(int status, DateTime dataInicio, DateTime dataFim);
    }
    public partial class ReservasDao : IReservasDao
    {
        public bool ExisteReservaAgora(Handle carro)
        {
            bool result = false;
            Criteria criteria = new Criteria(@"A.CARRO = :CARRO
                                                    AND
                                              @HOJE BETWEEN A.DATAINICIO AND A.DATAFIM");
            criteria.Parameters.Add("CARRO", carro);
            result = GetMany(criteria).Count > 0;
            return result;
        }

        public IList<IReservas> ReservasPorStatusEspecifico(int status)
        {
            IList<IReservas> result = new List<IReservas>();
            Criteria criteria = new Criteria(@"A.STATUS = :STATUS");
            criteria.Parameters.Add("STATUS", status);
            result = GetMany(criteria);
            return result;
        }

        public IList<IReservas> ReservasPorStatusEspecifico(int status, DateTime dataInicio, DateTime dataFim)
        {
            IList<IReservas> result = new List<IReservas>();
            Criteria criteria = new Criteria(@"A.STATUS = :STATUS
                                                    AND
                                               (:DATAINICIO BETWEEN A.DATAINICIO AND A.DATAFIM
                                                OR :DATAFIM BETWEEN A.DATAINICIO AND A.DATAFIM
                                                OR A.DATAINICIO BETWEEN :DATAINICIO AND :DATAFIM
                                                OR A.DATAFIM BETWEEN :DATAINICIO AND :DATAFIM)");
            criteria.Parameters.Add("STATUS", status);
            criteria.Parameters.Add("DATAINICIO", dataInicio);
            criteria.Parameters.Add("DATAFIM", dataFim);
            result = GetMany(criteria);
            return result;
        }

    }
}
