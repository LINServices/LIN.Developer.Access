using LIN.Types.Cloud.Identity.Platform.Access;
using LIN.Types.Developer.Models.Rbac;
namespace LIN.Access.Developer.Controllers;

public static class Permissions
{

    /// <summary>
    /// Obtiene el catálogo completo de permisos de la plataforma.
    /// </summary>
    /// <param name="token">Token de acceso</param>
    /// <param name="cancellationToken">Token de cancelación</param>
    public static async Task<ReadAllResponse<PermissionModel>> GetAll(string token, CancellationToken cancellationToken = default)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("rbac/permissions/all");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<PermissionModel>>(cancellationToken: cancellationToken);

        // Retornar.
        return Content;

    }


    public static async Task<ReadAllResponse<AccessGrant>> GetAll(string token, int resource, CancellationToken cancellationToken = default)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("rbac/profiles/roles/permissions");

        // Headers.
        client.AddHeader("token", token);
        client.AddParameter("resourceId", resource);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<AccessGrant>>(cancellationToken: cancellationToken);

        // Retornar.
        return Content;

    }

}
