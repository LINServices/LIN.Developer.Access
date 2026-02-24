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
    public static async Task<ReadAllResponse<ProjectDataModel>> ReadAllAsync(string token, int? baseResource = null)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("resources/all");

        // Headers.
        client.AddHeader("token", token);

        if (baseResource != null)
        {
            client.AddParameter("baseResource", baseResource.Value);
        }

        // Resultado.
        var Content = await client.Get<ReadAllResponse<ProjectDataModel>>();

        // Retornar.
        return Content;

    }

    public static async Task<ReadAllResponse<ProjectDataModel>> ReadAllBases(string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("resources/groups/all");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<ProjectDataModel>>();

        // Retornar.
        return Content;

    }


    public static async Task<CreateResponse> GetTokenCloud(string token, int resource)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("resources/token/cloud");

        // Headers.
        client.AddHeader("token", token);
        client.AddHeader("resource", resource);

        // Resultado.
        var Content = await client.Get<CreateResponse>();

        // Retornar.
        return Content;
    }

    public static async Task<ResponseBase> Asociate(string token, int resource, int? group)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("resources/groups/asociate");

        // Headers.
        client.AddHeader("token", token);
        client.AddParameter("resource", resource);

        if (group != null)
        client.AddParameter("group", group.Value);

        // Resultado.
        var Content = await client.Post<ResponseBase>();

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
            {"dotnet", typeof(LIN.Types.Developer.Resources.DotnetResource) },
            {"valkey", typeof(LIN.Types.Developer.Resources.Databases.ValkeyResource) },
            {"staticweb", typeof(LIN.Types.Developer.Resources.StaticWebSiteResource) },
            {"mysql", typeof(LIN.Types.Developer.Resources.Databases.MySqlResource) },
            {"gateway", typeof(LIN.Types.Developer.Resources.OcelotResource) },
            {"node", typeof(LIN.Types.Developer.Resources.NodeResource) },
        };

        // Resultado.
        var Content = await client.Get<ReadOneResponse<ProjectDataModel>, ProjectDataModel>(types, "Type");

        // Retornar.
        return Content;

    }

    public static async Task<ReadOneResponse<ProjectDataModel>> ReadOneByKey(string key)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("resources/validations/readproject");

        client.TimeOut = 40;

        // Headers.
        client.AddHeader("key", key);

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
            {"dotnet", typeof(LIN.Types.Developer.Resources.DotnetResource) },
            {"valkey", typeof(LIN.Types.Developer.Resources.Databases.ValkeyResource) },
            {"mysql", typeof(LIN.Types.Developer.Resources.Databases.MySqlResource) },
            {"gateway", typeof(LIN.Types.Developer.Resources.OcelotResource) },
            {"node", typeof(LIN.Types.Developer.Resources.NodeResource) },
        };

        // Resultado.
        var Content = await client.Get<ReadOneResponse<ProjectDataModel>, ProjectDataModel>(types, "Type");

        // Retornar.
        return Content;
    }


    public static async Task<ReadOneResponse<ProjectDataModel>> ReadOneByCloud(string cloud)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("resources/validations/readprojectbycloud");

        client.TimeOut = 40;

        // Headers.
        client.AddHeader("cloud", cloud);

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
            {"dotnet", typeof(LIN.Types.Developer.Resources.DotnetResource) },
            {"valkey", typeof(LIN.Types.Developer.Resources.Databases.ValkeyResource) },
            {"mysql", typeof(LIN.Types.Developer.Resources.Databases.MySqlResource) },
            {"gateway", typeof(LIN.Types.Developer.Resources.OcelotResource) },
            {"node", typeof(LIN.Types.Developer.Resources.NodeResource) },
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


    public static async Task<ResponseBase> UpdateName(string token, int resource, string name)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("resources/name");

        // Headers.
        client.AddHeader("token", token);

        // Parámetros.
        client.AddParameter("resource", resource);
        client.AddParameter("name", name);

        // Resultado.
        var Content = await client.Post<ResponseBase>();

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



    /// <summary>
    /// Crea un nuevo recurso.
    /// </summary>
    /// <param name="modelo">Modelo del recurso</param>
    /// <param name="token">Token de acceso</param>
    public static async Task<CreateResponse> Share(InviteUserDto userDto, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("ResourcesShare");

        client.TimeOut = 60;

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Post<CreateResponse>(userDto);

        // Retornar.
        return Content;

    }


    public static async Task<ResponseBase> Update(InviteUserDto userDto, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("ResourcesShare");

        client.TimeOut = 60;

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Patch<ResponseBase>(userDto);

        // Retornar.
        return Content;

    }


    public static async Task<ResponseBase> DeleteMember(InviteUserDto userDto, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("ResourcesShare");

        client.TimeOut = 60;

        // Headers.
        client.AddHeader("token", token);
        client.AddParameter("profile", userDto.ProfileId);
        client.AddParameter("resource", userDto.ResourceId);

        // Resultado.
        var Content = await client.Delete<ResponseBase>();

        // Retornar.
        return Content;

    }


    public static async Task<ReadAllResponse<OwnerModel>> ReadMembers(int resource, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("ResourcesShare");

        client.TimeOut = 60;

        // Headers.
        client.AddHeader("token", token);
        client.AddHeader("resource", resource);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<OwnerModel>>();

        // Retornar.
        return Content;

    }

}