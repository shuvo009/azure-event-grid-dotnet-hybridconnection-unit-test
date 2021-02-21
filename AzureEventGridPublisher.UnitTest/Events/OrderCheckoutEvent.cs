using System;

namespace AzureEventGridPublisher.UnitTest.Events
{
    public class OrderCheckoutEvent
    {
        public Guid OrderId { get; set; }
    }
}
