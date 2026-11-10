using LIN.Types.Developer.Models.Rbac;
namespace LIN.Access.Developer.Controllers;

public static class ProfileRoles
{

    /// <summary>
    /// Obtiene los roles asignados a un perfil en un recurso específico.
    /// </summary>
    /// <param name="profileId">Id del perfil.</param>
    /// <param name="resourceId">Id del recurso.</param>
    /// <param name="token">Token de acceso.</param>
    /// <param name="cancellationToken">Token de cancelación</param>
    public static async Task<ReadAllResponse<RoleModel>> GetAll(int profileId, int resourceId, string token, CancellationToken cancellationToken = default)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("rbac/profiles/roles/all");

        // Headers.
        client.AddHeader("token", token);

        // Parámetros de consulta.
        client.AddParameter("profileId", profileId.ToString());
        client.AddParameter("resourceId", resourceId.ToString());

        // Resultado.
        var Content = await client.Get<ReadAllResponse<RoleModel>>(cancellationToken: cancellationToken);

        // Retornar.
        return Content;

    }

    /// <summary>
    /// Asigna un rol a un perfil en un recurso específico.
    /// </summary>
    /// <param name="profileId">Id del perfil.</param>
    /// <param name="resourceId">Id del recurso.</param>
    /// <param name="roleId">Id del rol.</param>
    /// <param name="token">Token de acceso.</param>
    /// <param name="cancellationToken">Token de cancelación</param>
    public static async Task<ResponseBase> Add(int profileId, int resourceId, string roleId, string token, CancellationToken cancellationToken = default)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("rbac/profiles/roles");

        // Headers.
        client.AddHeader("token", token);

        // Cuerpo de la solicitud.
        var model = new AssignRoleRequest(profileId, resourceId, roleId);

        // Resultado.
        var Content = await client.Post<ResponseBase>(model, cancellationToken: cancellationToken);

        // Retornar.
        return Content;

    }

    /// <summary>
    /// Elimina un rol de un perfil en un recurso específico.
    /// </summary>
    /// <param name="profileId">Id del perfil.</param>
    /// <param name="resourceId">Id del recurso.</param>
    /// <param name="roleId">Id del rol.</param>
    /// <param name="token">Token de acceso.</param>
    /// <param name="cancellationToken">Token de cancelación</param>
    public static async Task<ResponseBase> Remove(int profileId, int resourceId, string roleId, string token, CancellationToken cancellationToken = default)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("rbac/profiles/roles");

        // Headers.
        client.AddHeader("token", token);

        // Parámetros de consulta.
        client.AddParameter("profileId", profileId.ToString());
        client.AddParameter("resourceId", resourceId.ToString());
        client.AddParameter("roleId", roleId.ToString());

        // Resultado.
        var Content = await client.Delete<ResponseBase>(cancellationToken: cancellationToken);

        // Retornar.
        return Content;

    }

}

// Registro auxiliar para las solicitudes de asignación de rol.
public record AssignRoleRequest(int ProfileId, int ResourceId, string RoleId);
