using Azure.Messaging.ServiceBus;

namespace CodingSkills.ServiceBus
{
    public class DeadLetterQueueConsumer
    {
        private const string ServiceBusConnectionString = "<Your-Service-Bus-Connection-String>";
        private const string DeadLetterQueueName = "<Your-Queue-Name>/$DeadLetterQueue";

        static async Task DeadeLetterQueueMessage()
        {
            ServiceBusClient client = new ServiceBusClient(ServiceBusConnectionString);
            ServiceBusReceiver receiver = client.CreateReceiver(DeadLetterQueueName);

            try
            {
                Console.WriteLine("Reading messages from the Dead Letter Queue...");

                while (true)
                {
                    ServiceBusReceivedMessage message = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(5));
                    if (message == null)
                    {
                        Console.WriteLine("No more messages in the Dead Letter Queue.");
                        break;
                    }

                    Console.WriteLine($"Dead-Lettered Message: {message.Body.ToString()}");
                    Console.WriteLine($"Reason: {message.DeadLetterReason}");
                    Console.WriteLine($"Error Description: {message.DeadLetterErrorDescription}");

                    // Complete the message to remove it from the Dead Letter Queue
                    await receiver.CompleteMessageAsync(message);
                }
            }
            finally
            {
                await receiver.DisposeAsync();
                await client.DisposeAsync();
            }
        }
    }
}
