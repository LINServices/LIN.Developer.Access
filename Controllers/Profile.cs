namespace LIN.Access.Developer.Controllers;

public static class Profile
{

    /// <summary>
    /// Crear perfil.
    /// </summary>
    /// <param name="modelo">Modelo.</param>
    public static async Task<CreateResponse> Create(ProfileDataModel modelo, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("profiles");

        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Post<CreateResponse>(modelo);

        // Retornar.
        return Content;

    }


    /// <summary>
    /// Verificar si existe un perfil para una cuenta.
    /// </summary>
    /// <param name="id">Id de la cuenta.</param>
    public static async Task<ReadOneResponse<bool>> HasProfile(int id)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("profiles/haveFor");

        // Parámetros.
        client.AddParameter("id", id);

        // Resultado.
        var Content = await client.Get<ReadOneResponse<bool>>();

        // Retornar.
        return Content;

    }


    /// <summary>
    /// Encontrar un perfil.
    /// </summary>
    /// <param name="id">Id de la cuenta.</param>
    public static async Task<ReadOneResponse<ProfileDataModel>> Find(int id)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("profiles");

        // Parámetros.
        client.AddParameter("id", id);

        // Resultado.
        var Content = await client.Get<ReadOneResponse<ProfileDataModel>>();

        // Retornar.
        return Content;

    }


    /// <summary>
    /// Buscar perfiles.
    /// </summary>
    /// <param name="token">Token de acceso.</param>
    /// <param name="param">Parámetros de búsqueda.</param>
    public static async Task<ReadAllResponse<ProfileDataModel>> Search(string token, string param)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("profiles/search");

        // Parámetros.
        client.AddParameter("value", param);
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<ProfileDataModel>>();

        // Retornar.
        return Content;

    }

}