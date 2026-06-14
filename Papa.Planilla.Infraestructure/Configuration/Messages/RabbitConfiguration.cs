using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Infraestructure.Configuration.Messages
{
    public class RabbitConfiguration
    {
        private readonly RabbitSettings _settings;
        private IConnection? _connection;

        public RabbitConfiguration(RabbitSettings settings)
        {
            _settings = settings;
        }

        public async Task<IConnection> GetConnectionAsync()
        {
            if(_connection != null && _connection.IsOpen)
            {
                return _connection;
            }

            var factory = new ConnectionFactory
            {
                HostName = _settings.Hostname,
                UserName = _settings.Username,
                Password = _settings.Password
            };
            _connection = await factory.CreateConnectionAsync();
            return _connection;
        }
    }
}
