namespace LIN.Access.Developer.Controllers;

public class Billings
{

    public static async Task<ReadOneResponse<TransactionResultModel>> Create(string key, decimal amount, CancellationToken cancellationToken = default)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("billing");

        // Headers.
        client.AddHeader("key", key);

        // Params.
        client.AddParameter("amount", amount.ToString());

        // Resultado.
        var Content = await client.Post<ReadOneResponse<TransactionResultModel>>(cancellationToken: cancellationToken);

        // Retornar.
        return Content;

    }


    public static async Task<ReadAllResponse<BillingAccount>> ReadAllBillingAccounts(string token, CancellationToken cancellationToken = default)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("billing");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<BillingAccount>>(cancellationToken: cancellationToken);

        // Retornar.
        return Content;

    }


    public static async Task<ReadOneStringResponse> Charge(string token, int billing, string email, int amount, CancellationToken cancellationToken = default)
    {
        // Cliente HTTP.
        Client client = Service.GetClient("billing/charge");

        // Headers.
        client.AddHeader("token", token);
        client.AddParameter("accountId", billing);
        client.AddParameter("email", email);
        client.AddParameter("amount", amount);

        // Resultado.
        var Content = await client.Patch<ReadOneStringResponse>(cancellationToken: cancellationToken);

        // Retornar.
        return Content;
    }

    public static async Task<ReadAllResponse<TransactionDataModel>> ReadAll(string token, CancellationToken cancellationToken = default)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("billing/all");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<TransactionDataModel>>(cancellationToken: cancellationToken);

        // Retornar.
        return Content;

    }


    public static async Task<CreateResponse> Create(string name, BillingAccountTypes types, string token, CancellationToken cancellationToken = default)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("billing/create");

        // Headers.
        client.AddHeader("token", token);
        client.AddParameter("name", name);
        client.AddParameter("type", (int)types);

        // Resultado.
        var Content = await client.Post<CreateResponse>(cancellationToken: cancellationToken);

        // Retornar.
        return Content;

    }


    public static async Task<ResponseBase> Delete(int id, string token, CancellationToken cancellationToken = default)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("billing");

        // Headers.
        client.AddHeader("token", token);
        client.AddParameter("id", id);

        // Resultado.
        var Content = await client.Delete<ResponseBase>(cancellationToken: cancellationToken);

        // Retornar.
        return Content;

    }


    public static async Task<ReadOneResponse<BillingAccount>> ReadBillingAccount(string token, int billing, CancellationToken cancellationToken = default)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("billing/byid");

        // Headers.
        client.AddHeader("token", token);
        client.AddHeader("id", billing);

        // Resultado.
        var Content = await client.Get<ReadOneResponse<BillingAccount>>(cancellationToken: cancellationToken);

        // Retornar.
        return Content;

    }



}