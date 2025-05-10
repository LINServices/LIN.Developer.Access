namespace LIN.Access.Developer.Controllers;

public class Subscriptions
{

    /// <summary>
    /// Crear una suscripción con la llave de acceso.
    /// </summary>
    /// <param name="key">Llave de un recurso.</param>
    /// <param name="amount">Valor total.</param>
    public static async Task<ReadOneResponse<TransactionResultModel>> Create(string key, decimal amount)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("billing/subscription");

        // Headers.
        client.AddHeader("key", key);

        // Params.
        client.AddParameter("amount", amount.ToString());

        // Resultado.
        var Content = await client.Post<ReadOneResponse<TransactionResultModel>>();

        // Retornar.
        return Content;
    }


    /// <summary>
    /// Crear una suscripción con token cloud.
    /// </summary>
    /// <param name="cloud">Token de acceso cloud.</param>
    /// <param name="amount">Valor total.</param>
    public static async Task<ReadOneResponse<TransactionResultModel>> CreateSubscriptionCloud(string cloud, decimal amount)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("billing/subscription/cloud");

        // Headers.
        client.AddHeader("cloud", cloud);

        // Params.
        client.AddParameter("amount", amount.ToString());

        // Resultado.
        var Content = await client.Post<ReadOneResponse<TransactionResultModel>>();

        // Retornar.
        return Content;
    }

}