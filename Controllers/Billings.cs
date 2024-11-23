namespace LIN.Access.Developer.Controllers;


public class Billings
{


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



    public static async Task<ReadAllResponse<TransactionDataModel>> ReadAllAsync(string token)
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
