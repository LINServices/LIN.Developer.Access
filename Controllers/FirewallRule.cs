namespace LIN.Access.Developer.Controllers;

public static class FirewallRule
{

    /// <summary>
    /// Crea una regla de firewall
    /// </summary>
    /// <param name="modelo">Modelo de la regla</param>
    /// <param name="token">Token de acceso</param>
    public static async Task<CreateResponse> Create(FirewallRuleModel modelo, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("firewall");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Post<CreateResponse>(modelo);

        // Retornar.
        return Content;

    }


    /// <summary>
    /// Obtiene las reglas de firewall
    /// </summary>
    /// <param name="id">ID del proyecto</param>
    /// <param name="token">Token de acceso</param>
    public static async Task<ReadAllResponse<FirewallRuleModel>> ReadAllAsync(int id, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("firewall/all");

        // Headers.
        client.AddHeader("token", token);

        // Parámetros.
        client.AddParameter("id", id);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<FirewallRuleModel>>();

        // Retornar.
        return Content;

    }


    /// <summary>
    /// Elimina una regla de acceso
    /// </summary>
    /// <param name="id">ID de la regla</param>
    /// <param name="token">Token de acceso</param>
    public static async Task<ResponseBase> Delete(int id, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("firewall");

        // Headers.
        client.AddHeader("token", token);

        // Parámetros.
        client.AddParameter("id", id);

        // Resultado.
        var Content = await client.Delete<ResponseBase>();

        // Retornar.
        return Content;

    }

}