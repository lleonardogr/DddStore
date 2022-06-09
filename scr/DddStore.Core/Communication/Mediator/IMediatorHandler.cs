﻿using DddStore.Core.Messages;
using DddStore.Core.Messages.CommonMessages.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddStore.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task<bool> EnviarComando<T>(T evento) where T : Command;
        Task PublicaNotificacao<T>(T notificacao) where T : DomainNotification;
    }
}
