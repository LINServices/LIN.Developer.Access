using LIN.Access.Developer.Models;
using LIN.Types.Developer.BillingModels;
using LIN.Types.Developer.TransactionModels;

namespace LIN.Access.Developer.Controllers;

/// <summary>
/// Administración de facturas (LIN.Cloud.Orchestrator.Admin, solo administradores).
/// </summary>
public class AdminInvoices
{
    /// <summary>
    /// Buscar facturas de cualquier cuenta (máximo 200 resultados).
    /// </summary>
    public static async Task<ReadAllResponse<InvoiceDto>> Search(string token, int? billing = null, InvoiceStatus? status = null, DateTime? from = null, DateTime? to = null, int take = 50, CancellationToken cancellationToken = default)
    {
        Client client = Service.GetAdminClient("admin/invoices");

        client.AddHeader("token", token);
        client.AddParameter("take", take);

        if (billing is not null)
            client.AddParameter("billing", billing.Value);

        if (status is not null)
            client.AddParameter("status", (int)status.Value);

        if (from is not null)
            client.AddParameter("from", from.Value.ToString("o"));

        if (to is not null)
            client.AddParameter("to", to.Value.ToString("o"));

        return await client.Get<ReadAllResponse<InvoiceDto>>(cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Detalle de una factura con ítems, descuentos y total final.
    /// </summary>
    public static async Task<ReadOneResponse<InvoiceDto>> Read(string token, int invoiceId, CancellationToken cancellationToken = default)
    {
        Client client = Service.GetAdminClient($"admin/invoices/{invoiceId}");

        client.AddHeader("token", token);

        return await client.Get<ReadOneResponse<InvoiceDto>>(cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Resumen de lo pendiente de cobro de una cuenta.
    /// </summary>
    public static async Task<ReadOneResponse<InvoiceSummaryDto>> Summary(string token, int billing, CancellationToken cancellationToken = default)
    {
        Client client = Service.GetAdminClient("admin/invoices/summary");

        client.AddHeader("token", token);
        client.AddParameter("billing", billing);

        return await client.Get<ReadOneResponse<InvoiceSummaryDto>>(cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Aplicar un descuento (porcentaje o monto fijo) a una factura no pagada.
    /// </summary>
    public static async Task<CreateResponse> AddDiscount(string token, int invoiceId, AddDiscountRequest request, CancellationToken cancellationToken = default)
    {
        Client client = Service.GetAdminClient($"admin/invoices/{invoiceId}/discounts");

        client.AddHeader("token", token);

        return await client.Post<CreateResponse>(request, cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Quitar un descuento de una factura no pagada.
    /// </summary>
    public static async Task<ResponseBase> RemoveDiscount(string token, int invoiceId, int discountId, string reason, CancellationToken cancellationToken = default)
    {
        Client client = Service.GetAdminClient($"admin/invoices/{invoiceId}/discounts/{discountId}");

        client.AddHeader("token", token);
        client.AddParameter("reason", reason);

        return await client.Delete<ResponseBase>(cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Agregar un ajuste manual (monto positivo = cargo, negativo = crédito).
    /// </summary>
    public static async Task<ResponseBase> AddItem(string token, int invoiceId, AddInvoiceItemRequest request, CancellationToken cancellationToken = default)
    {
        Client client = Service.GetAdminClient($"admin/invoices/{invoiceId}/items");

        client.AddHeader("token", token);

        return await client.Post<ResponseBase>(request, cancellationToken: cancellationToken);
    }
}
