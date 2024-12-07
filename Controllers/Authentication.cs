namespace LIN.Access.Developer.Controllers;

public class Authentication
{

    /// <summary>
    /// Iniciar sesión.
    /// </summary>
    /// <param name="cuenta">Usuario.</param>
    /// <param name="password">Contraseña.</param>
    public static async Task<ReadOneResponse<Types.Cloud.Identity.Abstracts.AuthModel<ProfileDataModel>>> Login(string cuenta, string password)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("authentication/login");

        // Parámetros.
        client.AddParameter("user", cuenta);
        client.AddParameter("password", password);

        // Resultado.
        var Content = await client.Get<ReadOneResponse<Types.Cloud.Identity.Abstracts.AuthModel<ProfileDataModel>>>();

        // Retornar.
        return Content;

    }


    /// <summary>
    /// Iniciar sesión.
    /// </summary>
    /// <param name="token">Token de acceso.</param>
    public static async Task<ReadOneResponse<Types.Cloud.Identity.Abstracts.AuthModel<ProfileDataModel>>> Login(string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("authentication/login/token");

        // Parámetros.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadOneResponse<Types.Cloud.Identity.Abstracts.AuthModel<ProfileDataModel>>>();

        // Retornar.
        return Content;

    }

}