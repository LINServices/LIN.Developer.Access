using LIN.Types.Developer.Models.Rbac;

namespace LIN.Access.Developer.Controllers;

public static class RolePermissions
{

    /// <summary>
    /// Obtiene todos los permisos asignados a un rol específico.
    /// </summary>
    /// <param name="token">Token de acceso</param>
    /// <param name="roleId">ID del rol</param>
    /// <param name="resourceId">ID del recurso</param>
    public static async Task<ReadAllResponse<PermissionModel>> GetByRole(string token, int roleId, int resourceId)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("rbac/roles/permissions/all");

        // Headers.
        client.AddHeader("token", token);

        // Parámetros.
        client.AddParameter("roleId", roleId.ToString());
        client.AddParameter("resourceId", resourceId.ToString());

        // Resultado.
        var Content = await client.Get<ReadAllResponse<PermissionModel>>();

        // Retornar.
        return Content;

    }


    /// <summary>
    /// Asigna un permiso a un rol.
    /// </summary>
    /// <param name="token">Token de acceso</param>
    /// <param name="roleId">ID del rol</param>
    /// <param name="permissionId">ID del permiso</param>
    /// <param name="resourceId">ID del recurso</param>
    public static async Task<ResponseBase> AddPermission(string token, int roleId, int permissionId, int resourceId)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("rbac/roles/permissions");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Post<ResponseBase>(new
        {
            RoleId = roleId,
            PermissionId = permissionId,
            ResourceId = resourceId
        });

        // Retornar.
        return Content;

    }


    /// <summary>
    /// Elimina un permiso de un rol.
    /// </summary>
    /// <param name="token">Token de acceso</param>
    /// <param name="roleId">ID del rol</param>
    /// <param name="permissionId">ID del permiso</param>
    /// <param name="resourceId">ID del recurso</param>
    public static async Task<ResponseBase> RemovePermission(string token, int roleId, int permissionId, int resourceId)
    {
        // Cliente HTTP.
        Client client = Service.GetClient("rbac/roles/permissions");

        // Headers.
        client.AddHeader("token", token);

        // Parámetros.
        client.AddParameter("roleId", roleId.ToString());
        client.AddParameter("permissionId", permissionId.ToString());
        client.AddParameter("resourceId", resourceId.ToString());

        // Resultado.
        var Content = await client.Delete<ResponseBase>();

        // Retornar.
        return Content;
    }

}
