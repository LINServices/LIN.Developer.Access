namespace LIN.Access.Developer.Controllers;


public class Billings
{



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
