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
4.  Run Test from Test Explorer
