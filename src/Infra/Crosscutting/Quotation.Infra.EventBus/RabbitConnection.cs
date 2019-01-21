using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quotation.Infra.EventBus {

    public class RabbitConnection: IRabbitConnection {

        private readonly object _lock = new object();
        private  IConnection _connection = null;
        private readonly IModel _channel = null;

        public RabbitConnection(string host, int port, string user, string password, string vHost) {
            if (_channel == null) {
                lock (_lock) {
                    if (_channel == null) {

                        var factory = new ConnectionFactory() {
                            VirtualHost = vHost,
                            HostName = host,
                            Port = port,
                            UserName = user,
                            Password = password,
                            AutomaticRecoveryEnabled = true
                        };

                        _connection = factory.CreateConnection();
                        _channel = _connection.CreateModel();
                    }
                }
            }
        }

        public IModel GetModel() {
            return _channel;
        }

        public string GetExchange() {
            throw new NotImplementedException();
        }

        public string GetRoutingKey() {
            throw new NotImplementedException();
        }
    }
}
