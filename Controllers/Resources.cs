using LIN.Types.Developer.TransactionModels;

namespace LIN.Access.Developer.Controllers;

public static class Resources
{

    /// <summary>
    /// Crea un nuevo recurso.
    /// </summary>
    /// <param name="modelo">Modelo del recurso</param>
    /// <param name="token">Token de acceso</param>
    public static async Task<CreateResponse> Create(ProjectDataModel modelo, string token, Dictionary<string, object> adicional)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("resources");

        client.TimeOut = 60;

        // Headers.
        client.AddHeader("token", token);

        // Parámetros.
        foreach (var item in adicional)
            client.AddParameter(item.Key, item.Value.ToString());

        // Resultado.
        var Content = await client.Post<CreateResponse>(modelo);

        // Retornar.
        return Content;

    }


    /// <summary>
    /// Obtiene los recursos asociados a un perfil.
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
    /// Obtiene un recurso.
    /// </summary>
    /// <param name="id">ID del recurso.</param>
    /// <param name="token">Token de acceso</param>
    public static async Task<ReadOneResponse<ProjectDataModel>> ReadOne(int id, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("resources");

        client.TimeOut = 40;

        // Headers.
        client.AddHeader("token", token);

        // Parámetros.
        client.AddParameter("id", id);

        Dictionary<string, Type> types = new()
        {
            {"default", typeof(ProjectDataModel) },
            {"postgre.db", typeof(LIN.Types.Developer.Resources.Databases.PostgresResource) },
            {"bucket", typeof(LIN.Types.Developer.Resources.BucketResource) },
            {"mongo", typeof(LIN.Types.Developer.Resources.Databases.MongoResource) },
            {"payments", typeof(LIN.Types.Developer.Resources.PaymentResource) },
            {"redis", typeof(LIN.Types.Developer.Resources.Databases.RedisResource) },
            {"rabbit", typeof(LIN.Types.Developer.Resources.Queues.RabbitResource) },
            {"functions", typeof(LIN.Types.Developer.Resources.FunctionResource) },
        };

        // Resultado.
        var Content = await client.Get<ReadOneResponse<ProjectDataModel>, ProjectDataModel>(types, "Type");

        // Retornar.
        return Content;

    }


    /// <summary>
    /// Elimina un recurso.
    /// </summary>
    /// <param name="id">ID del recurso.</param>
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


    /// <summary>
    /// Validar el acceso a un recurso.
    /// </summary>
    /// <param name="key">Llave de acceso.</param>
    /// <param name="ip">Ip de acceso.</param>
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


    /// <summary>
    /// Validar el acceso a un recurso.
    /// </summary>
    /// <param name="token">Token de acceso.</param>
    /// <param name="resource">id del recurso.</param>
    /// <returns></returns>
    public static async Task<ReadOneResponse<bool>> Validate(string token, int resource)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("resources/validations/profile");

        // Headers.
        client.AddHeader("token", token);

        // Parámetros.
        client.AddParameter("resource", resource);

        // Resultado.
        var Content = await client.Get<ReadOneResponse<bool>>();

        // Retornar.
        return Content;
    }


    /// <summary>
    /// Obtiene los precios de los recursos.
    /// </summary>
    /// <param name="token">Token de acceso.</param>
    /// <param name="type">Tipo del recurso.</param>
    /// <param name="adicional">Propiedades adicionales.</param>
    public static async Task<ReadAllResponse<PricingModel>> Pricings(string token, string type, Dictionary<string, object> adicional)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("resources/pricing");

        // Headers.
        client.AddHeader("token", token);

        client.AddParameter("type", type);

        foreach (var item in adicional)
            client.AddParameter(item.Key, item.Value.ToString());

        // Resultado.
        var Content = await client.Get<ReadAllResponse<PricingModel>>();

        // Retornar.
        return Content;
    }


    /// <summary>
    /// Confirma el acceso a un recurso.
    /// </summary>
    /// <param name="cloud">Token de acceso cloud.</param>
    public static async Task<ResponseBase> Confirm(string cloud)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("resources/validations/confirm");

        // Headers.
        client.AddHeader("cloud", cloud);

        // Resultado.
        var Content = await client.Patch<ResponseBase>();

        // Retornar.
        return Content;
    }

}