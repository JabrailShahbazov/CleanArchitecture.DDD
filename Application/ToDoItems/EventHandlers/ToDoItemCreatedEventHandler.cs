using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AppDomain.Events;
using Application.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.ToDoItems.EventHandlers
{
    public class TodoItemCreatedEventHandler : INotificationHandler<DomainEventNotification<ToDoItemCreatedEvent>>
    {
        private readonly ILogger<ToDoItemCreatedEvent> _logger;

        public TodoItemCreatedEventHandler(ILogger<ToDoItemCreatedEvent> logger)
        {
            _logger = logger;
        }


        public Task Handle(DomainEventNotification<ToDoItemCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;
            _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
