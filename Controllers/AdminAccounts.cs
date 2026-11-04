using LIN.Access.Developer.Models;

namespace LIN.Access.Developer.Controllers;

/// <summary>
/// Administración de cuentas de facturación (LIN.Cloud.Orchestrator.Admin, solo administradores).
/// </summary>
public class AdminAccounts
{
    /// <summary>
    /// Indica si el perfil del token es administrador de la plataforma.
    /// </summary>
    public static async Task<ReadOneResponse<bool>> IsAdmin(string token, CancellationToken cancellationToken = default)
    {
        Client client = Service.GetAdminClient("admin/me");

        client.AddHeader("token", token);

        return await client.Get<ReadOneResponse<bool>>(cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Solicitudes Enterprise pendientes.
    /// </summary>
    public static async Task<ReadAllResponse<PendingEnterpriseDto>> ReadPending(string token, CancellationToken cancellationToken = default)
    {
        Client client = Service.GetAdminClient("admin/enterprise/pending");

        client.AddHeader("token", token);

        return await client.Get<ReadAllResponse<PendingEnterpriseDto>>(cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Cuentas Professional/Enterprise con su nivel de confianza.
    /// </summary>
    public static async Task<ReadAllResponse<AdminAccountDto>> ReadAccounts(string token, CancellationToken cancellationToken = default)
    {
        Client client = Service.GetAdminClient("admin/accounts");

        client.AddHeader("token", token);

        return await client.Get<ReadAllResponse<AdminAccountDto>>(cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Aprobar una cuenta Enterprise.
    /// </summary>
    public static async Task<ResponseBase> Approve(string token, int accountId, CancellationToken cancellationToken = default)
    {
        Client client = Service.GetAdminClient("admin/enterprise/approve");

        client.AddHeader("token", token);
        client.AddParameter("accountId", accountId);

        return await client.Patch<ResponseBase>(cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Rechazar una cuenta Enterprise.
    /// </summary>
    public static async Task<ResponseBase> Reject(string token, int accountId, string reason, CancellationToken cancellationToken = default)
    {
        Client client = Service.GetAdminClient("admin/enterprise/reject");

        client.AddHeader("token", token);
        client.AddParameter("accountId", accountId);
        client.AddParameter("reason", reason);

        return await client.Patch<ResponseBase>(cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Cambiar el tipo de cuenta (plan) de una cuenta de facturación.
    /// </summary>
    public static async Task<ResponseBase> SetPlan(string token, int accountId, BillingPlan plan, CancellationToken cancellationToken = default)
    {
        Client client = Service.GetAdminClient("admin/accounts/plan");

        client.AddHeader("token", token);
        client.AddParameter("accountId", accountId);
        client.AddParameter("plan", (int)plan);

        return await client.Patch<ResponseBase>(cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Reintentar la reactivación de una cuenta desactivada.
    /// </summary>
    public static async Task<ResponseBase> Reactivate(string token, int accountId, CancellationToken cancellationToken = default)
    {
        Client client = Service.GetAdminClient("admin/accounts/reactivate");

        client.AddHeader("token", token);
        client.AddParameter("accountId", accountId);

        return await client.Patch<ResponseBase>(cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Fijar (-1..2) o quitar (null) el nivel de confianza manual.
    /// </summary>
    public static async Task<ResponseBase> SetTrust(string token, int accountId, int? level, CancellationToken cancellationToken = default)
    {
        Client client = Service.GetAdminClient("admin/accounts/trust");

        client.AddHeader("token", token);
        client.AddParameter("accountId", accountId);

        if (level is not null)
            client.AddParameter("level", level.Value);

        return await client.Patch<ResponseBase>(cancellationToken: cancellationToken);
    }
}
