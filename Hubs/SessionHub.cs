using Microsoft.AspNetCore.SignalR.Client;
using System.Diagnostics;

namespace LIN.Access.Developer.Hubs;

public class SessionHub
{
    private readonly HubConnection _connection;

    public event Action<int>? OnNewResource;
    public event Action<int>? OnUpdateResource;

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

    public async Task ConnectAsync()
    {
        try
        {
            if (_connection.State == HubConnectionState.Connected)
                return;

            await _connection.StartAsync();

            try
            {
                OnConnected?.Invoke();
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }

            await SubscribeAsync();
        }
        catch (Exception ex)
        {
            HandleError(ex);
        }
    }

    public async Task DisconnectAsync()
    {
        try
        {
            if (_connection.State != HubConnectionState.Connected)
                return;

            await _connection.StopAsync();
        }
        catch (Exception ex)
        {
            HandleError(ex);
        }
    }

    public async Task SubscribeAsync()
    {
        try
        {
            await EnsureConnected();
            await _connection.InvokeAsync("Subscribe");
        }
        catch (Exception ex)
        {
            HandleError(ex);
        }
    }

    private async Task EnsureConnected()
    {
        try
        {
            if (_connection.State != HubConnectionState.Connected)
            {
                await _connection.StartAsync();
            }
        }
        catch (Exception ex)
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