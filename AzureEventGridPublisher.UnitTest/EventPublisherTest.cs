using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AzureEventGridPublisher.Service;
using AzureEventGridPublisher.Service.Settings;
using AzureEventGridPublisher.UnitTest.Events;
using AzureEventGridPublisher.UnitTest.Helpers;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace AzureEventGridPublisher.UnitTest
{
    public class EventPublisherTest
    {
        [Fact]
        public async Task Publish_an_event()
        {
            var hybridConnectionSetting = await GetHybridConnectionSetting();
            var eventGridSetting = await GetEventGridSetting();

            var hybridConnectionListenerHelper = new HybridConnectionListenerHelper(hybridConnectionSetting);
            hybridConnectionListenerHelper.Start();
            var moqLogger = new Mock<ILogger<EventPublisher>>();

            var eventBus = new EventPublisher(eventGridSetting, moqLogger.Object);
            var orderCheckoutEvent = new OrderCheckoutEvent { OrderId = Guid.NewGuid() };

            await eventBus.Publish("ordercheckout", "Order Checkout", orderCheckoutEvent);
            var eventMessages = await hybridConnectionListenerHelper.GetReceivedEvent("ordercheckout");
            
            Assert.Single(eventMessages);
            var receivedEvent = GetEventData(eventMessages);
            Assert.Equal(orderCheckoutEvent.OrderId, receivedEvent.OrderId);
            
            await hybridConnectionListenerHelper.Stop();
        }

        #region Supported Methods

        private async Task<HybridConnectionSetting> GetHybridConnectionSetting()
        {
            var jsonData = await File.ReadAllTextAsync(@"Setup/HybridConnectionSetting.json");
            return JsonConvert.DeserializeObject<HybridConnectionSetting>(jsonData);
        }

        private async Task<EventGridSetting> GetEventGridSetting()
        {
            var jsonData = await File.ReadAllTextAsync(@"Setup/EventGridSetting.json");
            return JsonConvert.DeserializeObject<EventGridSetting>(jsonData);
        }

        private OrderCheckoutEvent GetEventData(List<EventGridEvent> messages)
        {
            var data = messages.First().Data;
            var jsonString = JsonConvert.SerializeObject(data);
            return JsonConvert.DeserializeObject<OrderCheckoutEvent>(jsonString);
        }

        #endregion
    }
}