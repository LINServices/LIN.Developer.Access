namespace LIN.Access.Developer.Controllers;

public class Authentication
{
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