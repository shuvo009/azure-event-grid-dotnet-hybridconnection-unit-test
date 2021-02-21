# Microsoft Azure Event Grid Hybrid Connection Unit Test Sample For C#
This contains a C# sample to unit test events from Azure Event Grid using an Azure relay hybrid connection listener.

## Features
This sample demonstrates how to unit test event grid events using Azure relay hybrid connection.

The above sample uses the Event Grid data plane SDK (Microsoft.Azure.EventGrid) and Azure Relay SDK (Microsoft.Azure.Relay).

## Getting Started

### Prerequisites
* .NET Core 5 or higher
* Azure subscription

### Running the Sample
1.  Load AzureEventGridPublisher solution in Visual Studio.
2.  Set **Key and TopicUrl** at `Setup/EventGridSetting.json`
3.  Set **RelayNamespace, ConnectionName, KeyName and Key** at `Setup/HybridConnectionSetting.json`
4.  Run Test from **Test Explorer**

### Azure Event Grid Topic Creation Steps
* Step 1 
![alt text](https://github.com/shuvo009/azure-event-grid-dotnet-hybridconnection-unit-test/blob/main/img/EventGrid1.PNG "Azure Event Grid Topic Creation Steps")

* Setp 2
![alt text](https://github.com/shuvo009/azure-event-grid-dotnet-hybridconnection-unit-test/blob/main/img/EventGrid2.PNG "Azure Event Grid Topic Creation Steps")

* Step 3 (Getting TopicUrl)
![alt text](https://github.com/shuvo009/azure-event-grid-dotnet-hybridconnection-unit-test/blob/main/img/EventGrid3.PNG "Azure Event Grid Topic Creation Steps")

* Step 4 (Getting Key)
![alt text](https://github.com/shuvo009/azure-event-grid-dotnet-hybridconnection-unit-test/blob/main/img/EventGrid4.PNG "Azure Event Grid Topic Creation Steps")

### Azure Relays Creation Steps
* Step 1 
![alt text](https://github.com/shuvo009/azure-event-grid-dotnet-hybridconnection-unit-test/blob/main/img/AzureRelays5.PNG "Azure Event Grid Topic Creation Steps")

* Step 2 
![alt text](https://github.com/shuvo009/azure-event-grid-dotnet-hybridconnection-unit-test/blob/main/img/AzureRelays6.PNG "Azure Event Grid Topic Creation Steps")

* Step 3
![alt text](https://github.com/shuvo009/azure-event-grid-dotnet-hybridconnection-unit-test/blob/main/img/AzureRelays7.PNG "Azure Event Grid Topic Creation Steps")

* Step 4 (Getting RelayNamespace and ConnectionName) 
![alt text](https://github.com/shuvo009/azure-event-grid-dotnet-hybridconnection-unit-test/blob/main/img/AzureRelays8.PNG "Azure Event Grid Topic Creation Steps")

* Step 5 (Getting KeyName and Key) 
![alt text](https://github.com/shuvo009/azure-event-grid-dotnet-hybridconnection-unit-test/blob/main/img/AzureRelays9.PNG "Azure Event Grid Topic Creation Steps")

### Connection Between Azure Event Grid Hybrid Connection
* Step 1 
![alt text](https://github.com/shuvo009/azure-event-grid-dotnet-hybridconnection-unit-test/blob/main/img/SubscriptionToHC10.PNG "Connection Between Azure Event Grid Hybrid Connection")

* Step 2
![alt text](https://github.com/shuvo009/azure-event-grid-dotnet-hybridconnection-unit-test/blob/main/img/SubscriptionToHC11.PNG "Connection Between Azure Event Grid Hybrid Connection")


## Resources
* https://docs.microsoft.com/en-us/azure/event-grid/overview
* https://docs.microsoft.com/en-us/azure/azure-relay/relay-what-is-it
* https://docs.microsoft.com/en-us/azure/azure-relay/relay-hybrid-connections-protocol
* https://docs.microsoft.com/en-us/azure/event-grid/custom-event-to-hybrid-connection
* https://docs.microsoft.com/en-us/azure/azure-relay/relay-hybrid-connections-http-requests-dotnet-get-started
