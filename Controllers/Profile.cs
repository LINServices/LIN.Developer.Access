namespace LIN.Access.Developer.Controllers;

public static class Profile
{

    /// <summary>
    /// Crear perfil.
    /// </summary>
    /// <param name="modelo">Modelo.</param>
    /// <param name="cancellationToken">Token de cancelación</param>
    public static async Task<CreateResponse> Create(ProfileDataModel modelo, string token, CancellationToken cancellationToken = default)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("profiles");

        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Post<CreateResponse>(modelo, cancellationToken: cancellationToken);

        // Retornar.
        return Content;

    }


    /// <summary>
    /// Verificar si existe un perfil para una cuenta.
    /// </summary>
    /// <param name="id">Id de la cuenta.</param>
    /// <param name="cancellationToken">Token de cancelación</param>
    public static async Task<ReadOneResponse<bool>> HasProfile(int id, CancellationToken cancellationToken = default)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("profiles/haveFor");

        // Parámetros.
        client.AddParameter("id", id);

        // Resultado.
        var Content = await client.Get<ReadOneResponse<bool>>(cancellationToken: cancellationToken);

        // Retornar.
        return Content;

    }


    /// <summary>
    /// Encontrar un perfil.
    /// </summary>
    /// <param name="id">Id de la cuenta.</param>
    /// <param name="cancellationToken">Token de cancelación</param>
    public static async Task<ReadOneResponse<ProfileDataModel>> Find(int id, CancellationToken cancellationToken = default)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("profiles");

        // Parámetros.
        client.AddParameter("id", id);

        // Resultado.
        var Content = await client.Get<ReadOneResponse<ProfileDataModel>>(cancellationToken: cancellationToken);

        // Retornar.
        return Content;

    }


    /// <summary>
    /// Actualizar las preferencias del perfil de la cuenta del token.
    /// </summary>
    /// <param name="token">Token de la cuenta.</param>
    /// <param name="acceptUpdates">Aceptar recibir actualizaciones.</param>
    /// <param name="sharePartners">Aceptar compartir con partners.</param>
    /// <param name="termsAcceptedAt">Fecha de aceptación de términos.</param>
    /// <param name="cancellationToken">Token de cancelación</param>
    public static async Task<ResponseBase> UpdatePreferences(string token, bool acceptUpdates, bool sharePartners, DateTime? termsAcceptedAt, CancellationToken cancellationToken = default)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("profiles/preferences");

        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Put<ResponseBase>(new
        {
            AcceptUpdates = acceptUpdates,
            SharePartners = sharePartners,
            TermsAcceptedAt = termsAcceptedAt
        }, cancellationToken: cancellationToken);

        // Retornar.
        return Content;

    }


    /// <summary>
    /// Buscar perfiles.
    /// </summary>
    /// <param name="token">Token de acceso.</param>
    /// <param name="param">Parámetros de búsqueda.</param>
    /// <param name="cancellationToken">Token de cancelación</param>
    public static async Task<ReadAllResponse<ProfileDataModel>> Search(string token, string param, CancellationToken cancellationToken = default)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("profiles/search");

        // Parámetros.
        client.AddParameter("value", param);
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<ProfileDataModel>>(cancellationToken: cancellationToken);

        // Retornar.
        return Content;

    }

}