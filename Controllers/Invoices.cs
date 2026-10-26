using LIN.Types.Developer.BillingModels;
using LIN.Types.Developer.TransactionModels;

namespace LIN.Access.Developer.Controllers;

public class Invoices
{
    public static async Task<ReadAllResponse<InvoiceDto>> ReadAll(string token, int billingAccount, CancellationToken cancellationToken = default)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("invoices");

        // Headers.
        client.AddHeader("token", token);
        client.AddParameter("billing", billingAccount);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<InvoiceDto>>(cancellationToken: cancellationToken);

        // Retornar.
        return Content;
    }

    public static async Task<ReadOneResponse<InvoiceDto>> Read(string token, int invoice, CancellationToken cancellationToken = default)
    {

        // Cliente HTTP.
        Client client = Service.GetClient($"invoices/{invoice}");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadOneResponse<InvoiceDto>>(cancellationToken: cancellationToken);

        // Retornar.
        return Content;
    }

    public static async Task<ReadOneResponse<SubscriptionModel>> Subscription(string token, int resourceId, CancellationToken cancellationToken = default)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("invoices/subscription");

        // Headers.
        client.AddHeader("token", token);
        client.AddParameter("resourceId", resourceId);

        // Resultado.
        var Content = await client.Get<ReadOneResponse<SubscriptionModel>>(cancellationToken: cancellationToken);

        // Retornar.
        return Content;
    }
}