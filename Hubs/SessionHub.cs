using Microsoft.AspNetCore.SignalR.Client;
using System.Diagnostics;

namespace LIN.Access.Developer.Hubs;

public class SessionHub
{
    private readonly HubConnection _connection;

    public event Action<int>? OnNewResource;
    public event Action<int>? OnUpdateResource;
    public event Action? OnNewNotification;

    public event Action? OnConnected;
    public event Action? OnDisconnected;
    public event Action<Exception?>? OnReconnecting;
    public event Action<Exception>? OnError;

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
        _connection.On<int>("#newResource", message =>
        {
            try
            {
                OnNewResource?.Invoke(message);
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        });

        _connection.On<int>("#updateResource", message =>
        {
            try
            {
                OnUpdateResource?.Invoke(message);
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        });

        _connection.On<int>("#newNotification", (id) =>
        {
            try
            {
                OnNewNotification?.Invoke();
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        });

        _connection.Reconnecting += error =>
        {
            try
            {
                OnReconnecting?.Invoke(error);
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }

            return Task.CompletedTask;
        };

        _connection.Reconnected += _ =>
        {
            try
            {
                OnConnected?.Invoke();
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }

            return Task.CompletedTask;
        };

        _connection.Closed += error =>
        {
            try
            {
                OnDisconnected?.Invoke();
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }

            return Task.CompletedTask;
        };
    }

    public async Task ConnectAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            if (_connection.State == HubConnectionState.Connected)
                return;

            await _connection.StartAsync(cancellationToken);

            try
            {
                OnConnected?.Invoke();
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }

            await SubscribeAsync(cancellationToken);
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            HandleError(ex);
        }
    }

    public async Task DisconnectAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            if (_connection.State != HubConnectionState.Connected)
                return;

            await _connection.StopAsync(cancellationToken);
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            HandleError(ex);
        }
    }

    public async Task ReconnectAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            // Si ya está conectado, no hace nada
            if (_connection.State == HubConnectionState.Connected)
                return;

            // Si está en proceso de conexión, espera
            if (_connection.State == HubConnectionState.Connecting ||
                _connection.State == HubConnectionState.Reconnecting)
                return;

            await _connection.StartAsync(cancellationToken);

            try
            {
                OnConnected?.Invoke();
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }

            await SubscribeAsync(cancellationToken);
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            HandleError(ex);
        }
    }

    public async Task SubscribeAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await EnsureConnected(cancellationToken);
            await _connection.InvokeAsync("Subscribe", cancellationToken);
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            HandleError(ex);
        }
    }

    private async Task EnsureConnected(CancellationToken cancellationToken = default)
    {
        try
        {
            if (_connection.State != HubConnectionState.Connected)
            {
                await _connection.StartAsync(cancellationToken);
            }
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            HandleError(ex);
        }
    }

    private void HandleError(Exception ex)
    {
        try
        {
            OnError?.Invoke(ex);
        }
        catch
        {
        }

        Debug.WriteLine(ex);
    }
}