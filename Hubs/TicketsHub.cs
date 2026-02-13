using Microsoft.AspNetCore.SignalR.Client;

namespace LIN.Access.Developer.Hubs;

public class TicketsHubClient
{
    private readonly HubConnection _connection;

    public event Action<string>? OnTicketUpdated;
    public event Action<string>? OnTicketEventUpdated;
    public event Action? OnConnected;
    public event Action? OnDisconnected;
    public event Action<Exception?>? OnReconnecting;

    public TicketsHubClient(string token)
    {
        _connection = new HubConnectionBuilder()
            .WithUrl(Service._Service.Url + $"hubs/tickets?access_token={token}")
            .WithAutomaticReconnect()
            .Build();

        RegisterEvents();
    }

    private void RegisterEvents()
    {
        // Evento enviado por el servidor
        _connection.On<string>("TicketEventAdded", message =>
        {
            OnTicketEventUpdated?.Invoke(message);
        });

        _connection.On<string>("TicketUpdated", message =>
        {
            OnTicketUpdated?.Invoke(message);
        });

        _connection.Reconnecting += error =>
        {
            OnReconnecting?.Invoke(error);
            return Task.CompletedTask;
        };

        _connection.Reconnected += _ =>
        {
            OnConnected?.Invoke();
            return Task.CompletedTask;
        };

        _connection.Closed += _ =>
        {
            OnDisconnected?.Invoke();
            return Task.CompletedTask;
        };
    }

    public async Task ConnectAsync()
    {
        if (_connection.State == HubConnectionState.Connected)
            return;

        await _connection.StartAsync();
        OnConnected?.Invoke();
    }

    public async Task DisconnectAsync()
    {
        if (_connection.State != HubConnectionState.Connected)
            return;

        await _connection.StopAsync();
    }

    public async Task<SubscribeResponse?> SubscribeAsync(string ticketId)
    {
        await EnsureConnected();
        return await _connection.InvokeAsync<SubscribeResponse>("Subscribe", ticketId);
    }

    public async Task UnsubscribeAsync(string ticketId)
    {
        await EnsureConnected();
        await _connection.InvokeAsync("Unsubscribe", ticketId);
    }

    private async Task EnsureConnected()
    {
        if (_connection.State != HubConnectionState.Connected)
        {
            await _connection.StartAsync();
        }
    }
}

public class SubscribeResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
}