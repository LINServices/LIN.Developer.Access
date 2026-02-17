using Microsoft.AspNetCore.SignalR.Client;

namespace LIN.Access.Developer.Hubs;

public class SessionHub
{
    private readonly HubConnection _connection;

    public event Action<int>? OnNewResource;
    public event Action<int>? OnUpdateResource;

    public event Action? OnConnected;
    public event Action? OnDisconnected;
    public event Action<Exception?>? OnReconnecting;

    public SessionHub(string token)
    {
        _connection = new HubConnectionBuilder()
            .WithUrl(Service._Service.Url + $"hubs/Ochestrator?access_token={token}")
            .WithAutomaticReconnect()
            .Build();

        RegisterEvents();
    }

    private void RegisterEvents()
    {
        // Evento enviado por el servidor
        _connection.On<int>("#newResource", message =>
        {
            OnNewResource?.Invoke(message);
        });

        _connection.On<int>("#updateResource", message =>
        {
            OnUpdateResource?.Invoke(message);
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
        await SubscribeAsync();
    }

    public async Task DisconnectAsync()
    {
        if (_connection.State != HubConnectionState.Connected)
            return;

        await _connection.StopAsync();
    }

    public async Task SubscribeAsync()
    {
        await EnsureConnected();
        await _connection.InvokeAsync("Subscribe");
    }


    private async Task EnsureConnected()
    {
        if (_connection.State != HubConnectionState.Connected)
        {
            await _connection.StartAsync();
        }
    }
}