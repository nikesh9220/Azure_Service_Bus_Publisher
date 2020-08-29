using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using Nikesh.Publisher.ViewModels;

namespace Nikesh.Publisher.Services
{
    public class PublisherService : IPublisherService
    {
        private const string ServiceBusPrimaryConnectionString = "[Insert Your Connection String]";
        private const string TopicName = "sender-publisher";
        private static ITopicClient _topicClient;
        public PublisherService()
        {
            _topicClient = new TopicClient(
                ServiceBusPrimaryConnectionString, 
                TopicName);
        }

        public async Task Send(InformationViewModel viewModel)
        {
            var message = ToMessage(viewModel);

            try
            {
                await _topicClient.SendAsync(message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }
            finally
            {
                await _topicClient.CloseAsync();
            }
        }

        private static Message ToMessage(InformationViewModel model)
        {
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model));

            var message = new Message
            {
                Body = body,
                ContentType = "text/plain",
            };

            return message;
        }
    }
}