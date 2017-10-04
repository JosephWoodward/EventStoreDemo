using System;
using System.Net;
using System.Text;
using EventStore.ClientAPI;

namespace EventStoreSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113));

            // Don't forget to tell the connection to connect!
            connection.ConnectAsync().Wait();
            var myEvent = new EventData(Guid.NewGuid(), "JoesEvent", false, Encoding.UTF8.GetBytes("Hello world data"), Encoding.UTF8.GetBytes("Hello World Meta Data!"));

            connection.AppendToStreamAsync("joes-stream", ExpectedVersion.Any, myEvent).Wait();

            StreamEventsSlice streamEvents;
            do
            {
                streamEvents = connection.ReadStreamEventsForwardAsync("joes-stream", 0, 1, false).Result;
                foreach (var @event in streamEvents.Events)
                {
                    var res = @event.Event.Data;
                    Console.WriteLine("Read event with data: {0}, metadata: {1}", Encoding.UTF8.GetString(res), Encoding.UTF8.GetString(@event.Event.Metadata));
                }
                
            } while (!streamEvents.IsEndOfStream);
            Console.ReadLine();
        }
    }
}
