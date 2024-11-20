using Microsoft.AspNetCore.SignalR.Client;

// URL of SignalR Hub Server
var hubUrl = "https://localhost:2000/chatHub";

// Create a SignalR connection
var connection = new HubConnectionBuilder()
    .WithUrl(hubUrl) // URL of Hub
    .WithAutomaticReconnect() // Automatically reconnect
    .Build();

// Register event to receive messages from server
connection.On<string, string>("ReceiveMessage", (user, message) =>
{
    Console.WriteLine($"{user}: {message}");
});

// Connect to Hub
try
{
    Console.WriteLine("Connecting to SignalR Hub...");
    await connection.StartAsync();
    Console.WriteLine("Connected to SignalR Hub!");
}
catch (Exception ex)
{
    Console.WriteLine($"Error connecting to SignalR Hub: {ex.Message}");
    return;
}

// Send message to server
while (true)
{
    Console.Write("Enter your name: ");
    var user = Console.ReadLine();
    Console.Write("Enter a message: ");
    var message = Console.ReadLine();

    if (!string.IsNullOrEmpty(message))
    {
        try
        {
            await connection.InvokeAsync("SendMessage", user, message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending message: {ex.Message}");
        }
    }
}