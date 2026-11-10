using LIN.Types.Cloud.Identity.Platform.Access;
using LIN.Types.Developer.Models.Rbac;
namespace LIN.Access.Developer.Controllers;

public static class Permissions
{

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
