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
    }
}
