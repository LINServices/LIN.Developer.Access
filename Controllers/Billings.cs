namespace LIN.Access.Developer.Controllers;

public class Billings
{

    /// <summary>
    /// Crear una transacción.
    /// </summary>
    /// <param name="key">Llave de un recurso.</param>
    /// <param name="amount">Valor a cobrar.</param>
    public static async Task<ReadOneResponse<TransactionResultModel>> Create(string key, decimal amount)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("billing");

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
    /// Obtener las transacciones.
    /// </summary>
    /// <param name="token">Token de acceso.</param>
    public static async Task<ReadAllResponse<TransactionDataModel>> ReadAll(string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("billing/all");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<TransactionDataModel>>();

        // Retornar.
        return Content;

    }

}