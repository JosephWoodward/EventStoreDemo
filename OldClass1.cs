using System;
using System.Net;
using System.Text;
using EventStore.ClientAPI;

/*namespace EventStoreSandbox
{
    internal class Program
    {
        private static void Main(string[] args)
        {
                    var connection =
                EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113));

            // Don't forget to tell the connection to connect!
            connection.ConnectAsync().Wait();

            var myEvent = new EventData(Guid.NewGuid(), "JoesEvent", false, Encoding.UTF8.GetBytes("Hello world data"), Encoding.UTF8.GetBytes("Hello World Meta Data!"));

            connection.AppendToStreamAsync("joes-stream", ExpectedVersion.Any, myEvent).Wait();

            var streamEvents = connection.ReadStreamEventsForwardAsync("joes-stream", 0, 1, false).Result;

            var returnedEvent = streamEvents.Events[0].Event;
            Console.WriteLine("Read event with data: {0}, metadata: {1}", Encoding.UTF8.GetString(returnedEvent.Data), Encoding.UTF8.GetString(returnedEvent.Metadata));




            var connection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113));

            // Don't forget to tell the connection to connect!
            connection.ConnectAsync().Wait();

            var myEvent = new EventData(Guid.NewGuid(), "JoesEvent", false, Encoding.UTF8.GetBytes("Hello world data"),
                Encoding.UTF8.GetBytes("Hello World Meta Data!"));

            connection.AppendToStreamAsync("joes-stream", ExpectedVersion.Any, myEvent).Wait();
            StreamEventsSlice streamEvents;
            do
            {
                streamEvents = connection.ReadStreamEventsForwardAsync("joes-stream", 0, 1, false).Result;
                foreach (var @event in streamEvents.Events)
                {
                    var res = @event.Event.Data;
                    Console.WriteLine("Read event with data: {0}, metadata: {1}", Encoding.UTF8.GetString(res));
                }
                
            } while (!streamEvents.IsEndOfStream);
            
            Console.ReadLine();
        }
    }
}*/