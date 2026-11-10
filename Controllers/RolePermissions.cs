using LIN.Types.Cloud.Identity.Platform.Access;
using LIN.Types.Developer.Models.Rbac;

namespace LIN.Access.Developer.Controllers;

public static class RolePermissions
{


    public static async Task<ReadOneResponse<bool>> Validate(string token, string permission, int resourceId, CancellationToken cancellationToken = default)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("rbac/profiles/permissions/validate");

        // Headers.
        client.AddHeader("token", token);

        // Parámetros.
        client.AddParameter("permission", permission);
        client.AddParameter("resourceId", resourceId.ToString());

        // Resultado.
        var Content = await client.Get<ReadOneResponse<bool>>(cancellationToken: cancellationToken);

        // Retornar.
        return Content;

    }

    public static async Task<ReadOneResponse<AccessCheckResult>> Validate(int identity, string permission, int resourceId, CancellationToken cancellationToken = default)
    {

        // Cliente HTTP.
        Client client = Service.GetClient($"rbac/profiles/permissions/{resourceId}/validate");

        // Parámetros.
        client.AddParameter("permission", permission);
        client.AddParameter("identity", identity);

        // Resultado.
        var Content = await client.Get<ReadOneResponse<AccessCheckResult>>(cancellationToken: cancellationToken);

        // Retornar.
        return Content;

    }

}