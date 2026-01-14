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


    public static async Task<ReadAllResponse<BillingAccount>> ReadAllBillingAccounts(string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("billing");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<BillingAccount>>();

        // Retornar.
        return Content;

    }

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


    public static async Task<CreateResponse> Create(string name, BillingAccountTypes types, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("billing/create");

        // Headers.
        client.AddHeader("token", token);
        client.AddParameter("name", name);
        client.AddParameter("type", (int)types);

        // Resultado.
        var Content = await client.Post<CreateResponse>();

        // Retornar.
        return Content;

    }


    public static async Task<ReadOneResponse<BillingAccount>> ReadBillingAccount(string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("billing");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadOneResponse<BillingAccount>>();

        // Retornar.
        return Content;

    }



    public static async Task<ReadAllResponse<SubscriptionPayment>> Payments(string token, int resource)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("payment/all");

        // Headers.
        client.AddHeader("token", token);
        client.AddHeader("resource", resource);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<SubscriptionPayment>>();

        // Retornar.
        return Content;

    }

}