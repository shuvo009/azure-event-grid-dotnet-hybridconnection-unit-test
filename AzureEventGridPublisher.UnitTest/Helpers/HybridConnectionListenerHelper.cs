using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Azure.Relay;
using Newtonsoft.Json;

namespace AzureEventGridPublisher.UnitTest.Helpers
{
    public class HybridConnectionListenerHelper
    {
        private readonly List<EventGridEvent> _eventGridEvents = new List<EventGridEvent>();
        private readonly HybridConnectionSetting _heHybridConnectionSetting;

        private HybridConnectionListener _listener;
        private bool _stopThread;

        public HybridConnectionListenerHelper(HybridConnectionSetting heHybridConnectionSetting)
        {
            _heHybridConnectionSetting = heHybridConnectionSetting;
        }

        public void Start()
        {
            _stopThread = false;
            var hcThread = new Thread(async () => { await OpenAsync(); });
            hcThread.Start();
        }

        public async Task Stop()
        {
            _eventGridEvents.Clear();
            await _listener.CloseAsync();
            _stopThread = true;
        }

        public async Task<List<EventGridEvent>> GetReceivedEvent(string eventType)
        {
            var tryCount = 6;
            while (tryCount > 0)
            {
                var events = _eventGridEvents.Where(x => x.EventType == eventType).ToList();
                if (events.Any())
                    return events;
                tryCount--;
                await Task.Delay(500);
            }

            return new List<EventGridEvent>();
        }

        private async Task OpenAsync()
        {
            var tokenProvider =
                TokenProvider.CreateSharedAccessSignatureTokenProvider(_heHybridConnectionSetting.KeyName,
                    _heHybridConnectionSetting.Key);
            _listener = new HybridConnectionListener(
                new Uri(
                    $"sb://{_heHybridConnectionSetting.RelayNamespace}/{_heHybridConnectionSetting.ConnectionName}"),
                tokenProvider)
            {
                RequestHandler = context =>
                {
                    var content = new StreamReader(context.Request.InputStream).ReadToEnd();
                    var eventGridEvent = JsonConvert.DeserializeObject<List<EventGridEvent>>(content);
                    _eventGridEvents.AddRange(eventGridEvent);
                }
            };
            await _listener.OpenAsync();
            while (!_stopThread) await Task.Delay(500);
        }
    }

    public class HybridConnectionSetting
    {
        public string RelayNamespace { get; set; }
        public string ConnectionName { get; set; }
        public string KeyName { get; set; }
        public string Key { get; set; }
    }
}