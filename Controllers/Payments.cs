namespace LIN.Access.Developer.Controllers;

public class Payments
{
    public static async Task<ReadAllResponse<TransactionDataModel>> ReadAll(int resource, string token, CancellationToken cancellationToken = default)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("payment/all");

        // Headers.
        client.AddHeader("token", token);
        client.AddHeader("resource", resource);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<TransactionDataModel>>(cancellationToken: cancellationToken);

        // Retornar.
        return Content;
    }

    public static async Task<ReadAllResponse<TransactionDataModel>> ReadAllByBilling(int billingAccount, string token, CancellationToken cancellationToken = default)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("payment/all/account");

        // Headers.
        client.AddHeader("token", token);
        client.AddHeader("billingAccount", billingAccount);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<TransactionDataModel>>(cancellationToken: cancellationToken);

        // Retornar.
        return Content;
    }


}