using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quotation.Infra.EventBus {
    public interface IRabbitConnection {

        IModel GetModel();
        string GetExchange();
        string GetRoutingKey();
    }
}
