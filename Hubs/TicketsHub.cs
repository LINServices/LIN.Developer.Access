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

    public async Task ConnectAsync(CancellationToken cancellationToken = default)
    {
        if (_connection.State == HubConnectionState.Connected)
            return;

        await _connection.StartAsync(cancellationToken);
        OnConnected?.Invoke();
    }

    public async Task DisconnectAsync(CancellationToken cancellationToken = default)
    {
        if (_connection.State != HubConnectionState.Connected)
            return;

        await _connection.StopAsync(cancellationToken);
    }

    public async Task<SubscribeResponse?> SubscribeAsync(string ticketId, CancellationToken cancellationToken = default)
    {
        await EnsureConnected(cancellationToken);
        return await _connection.InvokeAsync<SubscribeResponse>("Subscribe", ticketId, cancellationToken);
    }

    public async Task UnsubscribeAsync(string ticketId, CancellationToken cancellationToken = default)
    {
        await EnsureConnected(cancellationToken);
        await _connection.InvokeAsync("Unsubscribe", ticketId, cancellationToken);
    }

    private async Task EnsureConnected(CancellationToken cancellationToken = default)
    {
        if (_connection.State != HubConnectionState.Connected)
        {
            await _connection.StartAsync(cancellationToken);
        }
    }
}

public class SubscribeResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
}