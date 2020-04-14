using MediatR;
using MicroBanking.Domain.Core.Bus;
using MicroBanking.Domain.Core.Commands;
using MicroBanking.Domain.Core.Events;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBanking.Infrastructure.Bus
{
    public sealed class RabbitMQBus : IEventBus
    {
        private readonly IMediator mediator;
        private readonly IDictionary<string, IList<Type>> handlers;
        private readonly IList<Type> eventTypes;
        private readonly IServiceScopeFactory serviceScopeFactory;

        public RabbitMQBus(IMediator mediator, IServiceScopeFactory serviceScopeFactory)
        {
            this.mediator = mediator;
            this.serviceScopeFactory = serviceScopeFactory;
            handlers = new Dictionary<string, IList<Type>>();
            eventTypes = new List<Type>();
        }

        public async Task SendCommandAsync<T>(T command) where T : Command
        {
            await mediator.Send(command);
        }

        public void Publish<T>(T @event) where T : Event
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            var eventName = @event.GetType().Name;
            channel.QueueDeclare(queue: eventName, exclusive: false, autoDelete: false);

            var message = JsonConvert.SerializeObject(@event);
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish("", eventName, null, body);
        }

        public void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>
        {
            var eventName = typeof(T).Name;
            var handlerType = typeof(TH);

            if (!eventTypes.Contains(typeof(T)))
            {
                eventTypes.Add(typeof(T));
            }

            if (!handlers.ContainsKey(eventName))
            {
                handlers.Add(eventName, new List<Type>());
            }

            if (handlers[eventName].Any(s => s.GetType() == handlerType))
            {
                throw new ArgumentException($"Handler type {handlerType.Name} already is registered for '${eventName}'", nameof(handlerType));
            }

            handlers[eventName].Add(handlerType);

            StartBasicConsume<T>();
        }

        private void StartBasicConsume<T>() where T : Event
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                DispatchConsumersAsync = true
            };

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            var eventName = typeof(T).Name;

            channel.QueueDeclare(queue: eventName, exclusive: false, autoDelete: false);

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.Received += ConsumerReceived;

            channel.BasicConsume(eventName, true, consumer);
        }

        private async Task ConsumerReceived(object sender, BasicDeliverEventArgs @event)
        {
            var eventName = @event.RoutingKey;
            var message = Encoding.UTF8.GetString(@event.Body);

            try
            {
                await ProcessEvent(eventName, message).ConfigureAwait(false);
            }
            catch (Exception)
            {
            }
        }

        private async Task ProcessEvent(string eventName, string message)
        {
            if (handlers.ContainsKey(eventName))
            {
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    var subscriptions = handlers[eventName];
                    foreach (var subscription in subscriptions)
                    {
                        var handler = scope.ServiceProvider.GetService(subscription);
                        if (handler != null)
                        {
                            var eventType = eventTypes.SingleOrDefault(t => t.Name == eventName);
                            var @event = JsonConvert.DeserializeObject(message, eventType);

                            var concreteType = typeof(IEventHandler<>).MakeGenericType(eventType);
                            await (Task)concreteType.GetMethod("Handle").Invoke(handler, new object[] { @event });
                        }
                    }
                }
            }
        }
    }
}
