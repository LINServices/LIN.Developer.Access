namespace LIN.Access.Developer.Controllers;

public static class Notifications
{
    public static async Task<ReadAllResponse<NotificationModel>> ReadAllAsync(string token, CancellationToken cancellationToken = default)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("notifications");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<NotificationModel>>(cancellationToken: cancellationToken);

        // Retornar.
        return Content;

    }
    public static async Task<ResponseBase> MarkRead(string token, CancellationToken cancellationToken = default)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("notifications/read-all");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Put<ResponseBase>(cancellationToken: cancellationToken);

        // Retornar.
        return Content;

    }

}