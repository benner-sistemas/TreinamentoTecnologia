using Benner.Reservas.Componentes;
using Benner.Reservas.Componentes.Tasks;
using Benner.Reservas.Interfaces;
using Benner.Tecnologia.Business;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benner.Reservas.Nucleo.IoC
{
    public class RegistradorDependencias : NinjectModule
    {
        public override void Load()
        {
            BusinessComponent.Register<IGerenciadorReservas, GerenciadorReservas>(Kernel);
            BusinessComponent.Register<INotificadorReservasAprovadas, NotificadorReservasAprovadasTask>(Kernel);
        }
    }
}
