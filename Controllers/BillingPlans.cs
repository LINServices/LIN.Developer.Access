using LIN.Access.Developer.Models;

namespace LIN.Access.Developer.Controllers;

public class BillingPlans
{
    /// <summary>
    /// Pasar una cuenta Free a Professional (requiere una recarga mínima).
    /// </summary>
    public static async Task<ResponseBase> Upgrade(string token, int accountId, CancellationToken cancellationToken = default)
    {
        Client client = Service.GetClient("billing/upgrade");

        client.AddHeader("token", token);
        client.AddParameter("accountId", accountId);

        return await client.Patch<ResponseBase>(cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Solicitar una cuenta Enterprise (queda pendiente de aprobación).
    /// </summary>
    public static async Task<CreateResponse> RequestEnterprise(string token, string name, CancellationToken cancellationToken = default)
    {
        Client client = Service.GetClient("billing/enterprise/request");

        client.AddHeader("token", token);

        return await client.Post<CreateResponse>(new EnterpriseRequestModel { Name = name }, cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Obtener la política de la cuenta de facturación del proyecto dueño de la llave.
    /// </summary>
    public static async Task<ReadOneResponse<BillingPolicyResponse>> ReadPolicy(string key, CancellationToken cancellationToken = default)
    {
        Client client = Service.GetClient("billing/policy");

        client.AddHeader("key", key);

        return await client.Get<ReadOneResponse<BillingPolicyResponse>>(cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Solicitudes Enterprise pendientes (solo administradores).
    /// </summary>
    public static async Task<ReadAllResponse<PendingEnterpriseDto>> ReadPending(string token, CancellationToken cancellationToken = default)
    {
        Client client = Service.GetClient("billing/admin/pending");

        client.AddHeader("token", token);

        return await client.Get<ReadAllResponse<PendingEnterpriseDto>>(cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Aprobar una cuenta Enterprise (solo administradores).
    /// </summary>
    public static async Task<ResponseBase> Approve(string token, int accountId, CancellationToken cancellationToken = default)
    {
        Client client = Service.GetClient("billing/admin/approve");

        client.AddHeader("token", token);
        client.AddParameter("accountId", accountId);

        return await client.Patch<ResponseBase>(cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Rechazar una cuenta Enterprise (solo administradores).
    /// </summary>
    public static async Task<ResponseBase> Reject(string token, int accountId, string reason, CancellationToken cancellationToken = default)
    {
        Client client = Service.GetClient("billing/admin/reject");

        client.AddHeader("token", token);
        client.AddParameter("accountId", accountId);
        client.AddParameter("reason", reason);

        return await client.Patch<ResponseBase>(cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Fijar (-1..2) o quitar (null) el nivel de confianza manual (solo administradores).
    /// </summary>
    public static async Task<ResponseBase> SetTrust(string token, int accountId, int? level, CancellationToken cancellationToken = default)
    {
        Client client = Service.GetClient("billing/admin/trust");

        client.AddHeader("token", token);
        client.AddParameter("accountId", accountId);

        if (level is not null)
            client.AddParameter("level", level.Value);

        return await client.Patch<ResponseBase>(cancellationToken: cancellationToken);
    }
}
