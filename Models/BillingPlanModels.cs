namespace LIN.Access.Developer.Models;

/// <summary>
/// Política vigente de una cuenta de facturación (GET billing/policy).
/// </summary>
public class BillingPolicyResponse
{
    public int AccountId { get; set; }
    public BillingPlan Plan { get; set; }

    /// <summary>
    /// Nivel de confianza efectivo (-1..2).
    /// </summary>
    public int TrustLevel { get; set; }
    public BillingAccountStatus State { get; set; }
    public DateTime GeneratedAt { get; set; }
}

/// <summary>
/// Cuenta Enterprise pendiente de aprobación.
/// </summary>
public class PendingEnterpriseDto
{
    public int AccountId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime RequestedAt { get; set; }
    public string OwnerEmail { get; set; } = string.Empty;
    public string OwnerAlias { get; set; } = string.Empty;
}

/// <summary>
/// Cuenta Professional/Enterprise con su nivel de confianza (vista de administración).
/// </summary>
public class AdminAccountDto
{
    public int AccountId { get; set; }
    public string Name { get; set; } = string.Empty;
    public BillingPlan Plan { get; set; }
    public BillingAccountStatus State { get; set; }
    public decimal Balance { get; set; }

    /// <summary>
    /// Nivel calculado automáticamente.
    /// </summary>
    public int TrustLevel { get; set; }

    /// <summary>
    /// Nivel fijado manualmente (null si no hay ajuste).
    /// </summary>
    public int? TrustLevelOverride { get; set; }
}

internal class EnterpriseRequestModel
{
    public string Name { get; set; } = string.Empty;
}

/// <summary>
/// Solicitud para aplicar un descuento a una factura (POST admin/invoices/{id}/discounts).
/// </summary>
public class AddDiscountRequest
{
    public string Name { get; set; } = string.Empty;
    public LIN.Types.Developer.BillingModels.DiscountType Type { get; set; }
    public decimal Value { get; set; }

    /// <summary>
    /// Orden de aplicación; null = al final.
    /// </summary>
    public int? Order { get; set; }

    /// <summary>
    /// Motivo (obligatorio, queda auditado).
    /// </summary>
    public string Reason { get; set; } = string.Empty;
}

/// <summary>
/// Ajuste manual de una factura (POST admin/invoices/{id}/items). Monto negativo = crédito.
/// </summary>
public class AddInvoiceItemRequest
{
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Reason { get; set; } = string.Empty;
}

/// <summary>
/// Resumen administrativo de las facturas de una cuenta.
/// </summary>
public class InvoiceSummaryDto
{
    public int BillingAccountId { get; set; }
    public decimal UnpaidTotal { get; set; }
    public bool HasOverdue { get; set; }
}
