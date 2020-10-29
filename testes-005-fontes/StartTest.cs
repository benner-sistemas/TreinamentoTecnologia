using Benner.Tecnologia.Business.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benner.Reservas.Componentes.Teste
{
    [TestClass]
    public class StartTest
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            BusinessTests.Start("localhost", "reservas", "sysdba", "masterkey", "C:\\Benner\\Workdirs\\RESERVAS");
        }

    }
}
