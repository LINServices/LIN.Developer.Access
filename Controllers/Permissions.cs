using LIN.Types.Developer.Models.Rbac;
namespace LIN.Access.Developer.Controllers;

public static class Permissions
{

    /// <summary>
    /// Obtiene el catálogo completo de permisos de la plataforma.
    /// </summary>
    /// <param name="token">Token de acceso</param>
    public static async Task<ReadAllResponse<PermissionModel>> GetAll(string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("rbac/permissions/all");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<PermissionModel>>();

        // Retornar.
        return Content;

    }


    public static async Task<ReadAllResponse<PermissionModel>> GetAll(string token, int resource)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("rbac/profiles/roles/permissions");

        // Headers.
        client.AddHeader("token", token);
        client.AddParameter("resourceId", resource);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<PermissionModel>>();

        // Retornar.
        return Content;

    }

}
