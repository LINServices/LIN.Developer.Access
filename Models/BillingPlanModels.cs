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

internal class EnterpriseRequestModel
{
    public string Name { get; set; } = string.Empty;
}
