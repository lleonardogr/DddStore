using EventStore.ClientAPI;
using Microsoft.Extensions.Configuration;

namespace EventSourcing
{
    public class EventStoreService : IEventStoreService
    {
        private readonly IEventStoreConnection _connection;

        public EventStoreService(IConfiguration configuration)
        {
            _connection = EventStoreConnection.Create(
                configuration.GetConnectionString("EventStoreConnection"),
                ConnectionSettings.Create().DisableServerCertificateValidation().DisableTls().KeepReconnecting(),
                "DddStore"
                );

            _connection.ConnectAsync().GetAwaiter().GetResult();
        }

        public IEventStoreConnection GetConnection()
        {
            return _connection;
        }
    }
}
