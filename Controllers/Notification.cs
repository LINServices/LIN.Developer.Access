namespace LIN.Access.Developer.Controllers;

public static class Notifications
{
    public static async Task<ReadAllResponse<NotificationModel>> ReadAllAsync(string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("notifications");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<NotificationModel>>();

        // Retornar.
        return Content;

    }
    public static async Task<ResponseBase> MarkRead(string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("notifications/read-all");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Put<ResponseBase>();

        // Retornar.
        return Content;

    }

}