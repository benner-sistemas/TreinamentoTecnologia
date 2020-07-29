using Benner.Tecnologia.Business;
using Benner.Tecnologia.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benner.Reservas.Entidades
{
    public partial interface ICarrosDao
    {
        IList<EntityBase> CarrosDisponiveisPorModeloEPeriodo(Handle modelo, DateTime dataInicio, DateTime dataFim);
    }
    public partial class CarrosDao : ICarrosDao
    {
        public IList<EntityBase> CarrosDisponiveisPorModeloEPeriodo(Handle modelo, DateTime dataInicio, DateTime dataFim)
        {
            Query query = new Query(@"SELECT CAR.HANDLE, CAR.IDENTIFICADOR, MOD.NOME
                    FROM CARROS CAR
                        JOIN MODELOSCARROS MOD ON CAR.MODELO = MOD.HANDLE
                    WHERE CAR.MODELO = :MODELO
                        AND CAR.ATIVO = 'S'
                        AND CAR.HANDLE NOT IN 
                        (
                            SELECT CARRO FROM RESERVAS RE
                                WHERE RE.STATUS = 2
                                AND 
                                    (:DATAINICIO BETWEEN RE.DATAINICIO AND RE.DATAFIM
                                    OR :DATAFIM BETWEEN RE.DATAINICIO AND RE.DATAFIM
                                    OR RE.DATAINICIO BETWEEN :DATAINICIO AND :DATAFIM
                                    OR RE.DATAFIM BETWEEN :DATAINICIO AND :DATAFIM)
                        )");
            query.Parameters.Add(new Parameter("MODELO", modelo));
            query.Parameters.Add(new Parameter("DATAINICIO", dataInicio));
            query.Parameters.Add(new Parameter("DATAFIM", dataFim));

            return query.Execute();

        }
    }
}
