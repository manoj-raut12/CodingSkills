using Azure.Identity;
using Azure.Messaging.ServiceBus;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;

namespace CodingSkills.ServiceBus
{
    public class BlobStorageExample
    {
      
        private const string BlobConnectionString = "<Your-Blob-Storage-Connection-String>";
        private const string ContainerName = "<Your-Blob-Container-Name>";
        private const string ServiceBusConnectionString = "<Your-Service-Bus-Connection-String>";
        private const string QueueName = "<Your-Queue-Name>";

        static async Task UploadPayloadToBlob(string payload)
        {
            string filePath = "largePayload.txt"; // Path to the large file
            string blobName = Guid.NewGuid().ToString();

            // Upload the file to Blob Storage
            BlobServiceClient blobServiceClient = new(BlobConnectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(ContainerName);
            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            await blobClient.UploadAsync(filePath, overwrite: true);

            Console.WriteLine($"Blob uploaded: {blobClient.Uri}");
            // Send blobClient.Uri in your Service Bus message
            await SendPayloadToServiceBus(blobClient.Uri.ToString());

            //alternate we can generate Shared access signature (SAS) Url using below code and send it to Azure Buse service

            // Step : Generate a SAS URL
            string sasUrl = blobClient.GenerateSasUri(BlobSasPermissions.Read, DateTimeOffset.UtcNow.AddHours(1)).ToString();
            Console.WriteLine($"SAS URL: {sasUrl}");
            await SendPayloadToServiceBus(sasUrl);
        }
        static async Task SendPayloadToServiceBus(string blobUri)
        {
            //string blobUri = "<Blob-URI>"; // The URI of the uploaded blob

            ServiceBusClient client = new(ServiceBusConnectionString);
            ServiceBusSender sender = client.CreateSender(QueueName);

            ServiceBusMessage message = new ServiceBusMessage(blobUri)
            {
                ContentType = "application/json"
            };
            message.ApplicationProperties["FileName"] = "fileName.json";
            await sender.SendMessageAsync(message);
            Console.WriteLine("Message sent with Blob URI and payload fileName.");
        }

        // Consumer will use this method to read the message from blob combination with Service bus
        static async Task ReceivePayloadFromServiceBus()
        {
            ServiceBusClient serviceBusClient = new(ServiceBusConnectionString);
            ServiceBusProcessor processor = serviceBusClient.CreateProcessor(QueueName);

            processor.ProcessMessageAsync += async (args) =>
            {
                // Step 1: Retrieve the Blob URI from the message
                string blobUri = args.Message.Body.ToString();
                Console.WriteLine($"Received Blob URI: {blobUri}");

                // Step 2: Use Managed Identity to access Blob Storage
                BlobClient blobClient = new(new Uri(blobUri), new DefaultAzureCredential()); 

                var downloadResponse = await blobClient.DownloadAsync();
                using (StreamReader reader = new(downloadResponse.Value.Content))
                {
                    string content = await reader.ReadToEndAsync();
                    Console.WriteLine($"Downloaded Payload: {content}");
                }

                // Complete the message
                await args.CompleteMessageAsync(args.Message);
            };

            processor.ProcessErrorAsync += (args) =>
            {
                Console.WriteLine($"Error: {args.Exception.Message}");
                return Task.CompletedTask;
            };

            await processor.StartProcessingAsync();
            Console.WriteLine("Press any key to stop processing...");
            Console.ReadKey();
            await processor.StopProcessingAsync();
        }
    }
}
