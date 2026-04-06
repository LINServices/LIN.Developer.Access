using LIN.Types.Developer.Models.Rbac;

namespace LIN.Access.Developer.Controllers;

public static class Roles
{

    /// <summary>
    /// Obtiene los roles disponibles para un recurso.
    /// </summary>
    /// <param name="token">Token de acceso</param>
    /// <param name="resourceId">ID del recurso</param>
    public static async Task<ReadAllResponse<RoleModel>> GetAll(string token, int resourceId)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("rbac/roles/all");

        // Headers.
        client.AddHeader("token", token);

        // Parámetros.
        client.AddParameter("resourceId", resourceId.ToString());

        // Resultado.
        var Content = await client.Get<ReadAllResponse<RoleModel>>();

        // Retornar.
        return Content;

    }


    /// <summary>
    /// Crea un nuevo rol personalizado dentro de un recurso.
    /// </summary>
    /// <param name="token">Token de acceso</param>
    /// <param name="model">Modelo del rol</param>
    public static async Task<CreateResponse> Create(string token, RoleModel model)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("rbac/roles");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Post<CreateResponse>( model);

        // Retornar.
        return Content;

    }

}
