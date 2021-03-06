﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Quotation.Domain.Seedwork;
using RabbitMQ.Client;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Quotation.Infra.EventBus {
    public class RabbitEventBus : IEventBus {

        private readonly IRabbitConnection rabbitConnection;

        public RabbitEventBus(IRabbitConnection rabbitConnection) {
            this.rabbitConnection = rabbitConnection;
        }

        public void AddEvent(IEvent @event) {

            var json = Serialize(@event);
            var channel = rabbitConnection.GetModel();

            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;

            channel.BasicPublish(
                exchange: rabbitConnection.GetExchange(),
                routingKey: rabbitConnection.GetRoutingKey(),
                basicProperties: properties,
                body: Encoding.UTF8.GetBytes(json)
            );
        }

        public void AddEvents(IReadOnlyCollection<IEvent> events) {
            events.ToList().ForEach(p => this.AddEvent(p));
        }

        private string Serialize(IEvent @event) => JsonConvert.SerializeObject(
           value: @event,
           formatting: Formatting.None,
           settings: new JsonSerializerSettings() {
               ContractResolver = new DefaultContractResolver() {
                   NamingStrategy = new SnakeCaseNamingStrategy()
               }
           }
       );
    }
}
