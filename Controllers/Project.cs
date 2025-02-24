namespace LIN.Access.Developer.Controllers;

public static class Project
{

    /// <summary>
    /// Crea un nuevo proyecto
    /// </summary>
    /// <param name="modelo">Modelo del proyecto</param>
    /// <param name="token">Token de acceso</param>
    public static async Task<CreateResponse> Create(ProjectDataModel modelo, string token, Dictionary<string, string> adicional)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("resources");

        // Headers.
        client.AddHeader("token", token);

        // Parámetros.
        foreach (var item in adicional)
            client.AddParameter(item.Key, item.Value);
        
        // Resultado.
        var Content = await client.Post<CreateResponse>(modelo);

        // Retornar.
        return Content;

    }


    /// <summary>
    /// Obtiene los proyectos asociados a un perfil
    /// </summary>
    /// <param name="token">Token de acceso</param>
    public static async Task<ReadAllResponse<ProjectDataModel>> ReadAllAsync(string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("resources/all");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<ProjectDataModel>>();

        // Retornar.
        return Content;

    }


    /// <summary>
    /// Obtiene un proyecto
    /// </summary>
    /// <param name="id">ID del proyecto</param>
    /// <param name="token">Token de acceso</param>
    public static async Task<ReadOneResponse<ProjectDataModel>> ReadOne(int id, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("resources");

        // Headers.
        client.AddHeader("token", token);

        // Parámetros.
        client.AddParameter("id", id);

        Dictionary<string, Type> types = new()
        {
            {"DEFAULT", typeof(ProjectDataModel) },
            {"postgre.db", typeof(LIN.Types.Developer.Projects.PostgreSQLProject) },
            {"bucket", typeof(LIN.Types.Developer.Projects.BucketProject) },
        };

        // Resultado.
        var Content = await client.Get<ReadOneResponse<ProjectDataModel>, ProjectDataModel>(types, "Type");

        // Retornar.
        return Content;

    }


    /// <summary>
    /// Elimina un proyecto
    /// </summary>
    /// <param name="id">ID del proyecto</param>
    /// <param name="token">Token de acceso</param>
    public static async Task<ResponseBase> Delete(int id, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("resources");

        // Headers.
        client.AddHeader("token", token);

        // Parámetros.
        client.AddParameter("id", id);

        // Resultado.
        var Content = await client.Delete<ResponseBase>();

        // Retornar.
        return Content;

    }



    public static async Task<ReadOneResponse<int>> Validate(string key, string ip)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("resources/validations");

        // Headers.
        client.AddHeader("key", key);

        // Parámetros.
        client.AddParameter("ip", ip);

        // Resultado.
        var Content = await client.Get<ReadOneResponse<int>>();

        // Retornar.
        return Content;
    }

}