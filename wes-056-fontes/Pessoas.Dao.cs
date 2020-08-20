using Benner.Tecnologia.Business;
using Benner.Tecnologia.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benner.Reservas.Entidades
{
    public partial interface IPessoasDao
    {
        Handle CriarPessoaSemRegraNegocio(string nome, string cpf, string email, string telefoneMovel);
    }
    public partial class PessoasDao : IPessoasDao
    {
        public Handle CriarPessoaSemRegraNegocio(string nome, string cpf, string email, string telefoneMovel)
        {
            Handle handle = null;
            using (var tc = new TransactionContext())
            {
                handle = Pessoas.NovoHandle();

                RawEntityCommand command =
                    new RawEntityCommand(@"INSERT INTO PESSOAS
                                                (HANDLE, NOME, CPF, EMAIL, TELEFONEMOVEL) 
                                           VALUES
                                                (:HANDLE, :NOME, :CPF, :EMAIL, :TELEFONEMOVEL)
                                          ");
                command.Parameters.Add("HANDLE", handle);
                command.Parameters.Add("NOME", nome);
                command.Parameters.Add("CPF", cpf);
                command.Parameters.Add("EMAIL", email);
                command.Parameters.Add("TELEFONEMOVEL", telefoneMovel);

                Entity.Execute(command);

                tc.Complete();
            }
            return handle;
        }
    }
}
