using Azure.Messaging.ServiceBus;

namespace CodingSkills.ServiceBus
{
    public class ServiceBusConsumer
    {

        private const string ServiceBusConnectionString = "<Your-Service-Bus-Connection-String>"; //listner connection string
        private const string QueueName = "<Your-Queue-Name>";

        static async Task ConsumerMessage()
        {
            ServiceBusClient client = new ServiceBusClient(ServiceBusConnectionString);
            ServiceBusProcessor processor = client.CreateProcessor(QueueName, new ServiceBusProcessorOptions
            {
                AutoCompleteMessages = false,
                MaxConcurrentCalls = 1
            });

            processor.ProcessMessageAsync += ProcessMessageHandler;
            processor.ProcessErrorAsync += ErrorHandler;

            await processor.StartProcessingAsync();

            Console.WriteLine("Press any key to stop processing...");
            Console.ReadKey();

            await processor.StopProcessingAsync();
            await processor.DisposeAsync();
            await client.DisposeAsync();
        }

        private static async Task ProcessMessageHandler(ProcessMessageEventArgs args)
        {
            string body = args.Message.Body.ToString();
            Console.WriteLine($"Received: {body}");

            // Simulate a processing failure
            if (body.Contains("3"))
            {
                Console.WriteLine($"Dead-Lettering message: {body}");
                await args.DeadLetterMessageAsync(args.Message, "ProcessingFailed", "Simulated failure.");
            }
            else
            {
                await args.CompleteMessageAsync(args.Message);
            }
        }

        private static Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine($"Error: {args.Exception.Message}");
            return Task.CompletedTask;
        }
    }
}
