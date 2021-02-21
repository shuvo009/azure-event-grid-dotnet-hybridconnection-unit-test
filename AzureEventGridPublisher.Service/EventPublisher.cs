using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzureEventGridPublisher.Service.Settings;
using Microsoft.Azure.EventGrid;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureEventGridPublisher.Service
{
    public class EventPublisher
    {
        private readonly EventGridSetting _eventGridSetting;
        private readonly ILogger<EventPublisher> _logger;

        public EventPublisher(EventGridSetting eventGridSetting, ILogger<EventPublisher> logger)
        {
            _eventGridSetting = eventGridSetting;
            _logger = logger;
        }

        public async Task Publish<T>(string eventType, string subject, T model)
        {
            var topicHostname = new Uri(_eventGridSetting.TopicUrl).Host;
            var eventGridEvent = new EventGridEvent
            {
                Data = model,
                Id = Guid.NewGuid().ToString(),
                DataVersion = "1.0",
                EventTime = DateTime.Now,
                EventType = eventType,
                Subject = subject
            };

            var topicCredentials = new TopicCredentials(_eventGridSetting.Key);
            var eventGridClient = new EventGridClient(topicCredentials);
            await eventGridClient.PublishEventsAsync(topicHostname, new List<EventGridEvent> {eventGridEvent});
            _logger.LogInformation($"Event :{eventType} is send with data : {JsonConvert.SerializeObject(model)}");
        }
    }
}