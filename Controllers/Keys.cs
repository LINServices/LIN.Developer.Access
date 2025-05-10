namespace LIN.Access.Developer.Controllers;

public static class Keys
{

    /// <summary>
    /// Crea una api key
    /// </summary>
    /// <param name="modelo">Modelo</param>
    /// <param name="token">Token de acceso</param>
    public static async Task<CreateResponse> Create(KeyModel modelo, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("keys");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Post<CreateResponse>(modelo);

        // Retornar.
        return Content;

    }


    /// <summary>
    /// Obtiene las llaves asociadas a un recurso.
    /// </summary>
    /// <param name="id">ID del recurso.</param>
    /// <param name="token">Token de acceso</param>
    public static async Task<ReadAllResponse<KeyModel>> ReadAll(int id, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("keys/all");

        // Headers.
        client.AddHeader("token", token);

        // Parámetros.
        client.AddParameter("id", id);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<KeyModel>>();

        // Retornar.
        return Content;

    }


    /// <summary>
    /// Cambia el estado de una llave.
    /// </summary>
    /// <param name="id">ID de la llave</param>
    /// <param name="estado">Nuevo estado</param>
    /// <param name="token">Token de acceso</param>
    public static async Task<ResponseBase> ChangeState(int id, ApiKeyStatus estado, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("keys");

        // Headers.
        client.AddHeader("token", token);

        // Parámetros.
        client.AddParameter("id", id);
        client.AddParameter("estado", (int)estado);

        // Resultado.
        var Content = await client.Patch<ResponseBase>();

        // Retornar.
        return Content;

    }

}