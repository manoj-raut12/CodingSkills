using Azure.Messaging.ServiceBus;

namespace CodingSkills.ServiceBus
{
    public class ServiceBusProducer
    {

        private const string ServiceBusConnectionString = "<Your-Service-Bus-Connection-String>"; //Shared access signature (send, Listen, manage) for sending use send
        private const string QueueName = "<Your-Queue-Name>";

        static async Task SendMessage(string[] args)
        {
            ServiceBusClient client = new ServiceBusClient(ServiceBusConnectionString);
            ServiceBusSender sender = client.CreateSender(QueueName);

            try
            {
                for (int i = 1; i <= 5; i++)
                {
                    string messageBody = $"Message {i}";
                    ServiceBusMessage message = new(messageBody)
                    {
                        TimeToLive = TimeSpan.FromSeconds(10) // Message expires in 10 seconds
                    };

                    Console.WriteLine($"Sending: {messageBody}");
                    await sender.SendMessageAsync(message);
                }
            }
            finally
            {
                await sender.DisposeAsync();
                await client.DisposeAsync();
            }
        }
    }
}
