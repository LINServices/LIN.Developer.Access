namespace LIN.Access.Developer.Controllers;

public class Security
{

    /// <summary>
    /// Validar código OTP.
    /// </summary>
    /// <param name="id">Id del perfil.</param>
    /// <param name="otp">Código.</param>
    /// <param name="cancellationToken">Token de cancelación</param>
    public static async Task<ResponseBase> ValidateOTP(int id, string otp, CancellationToken cancellationToken = default)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("security/validate/otp");

        // Parámetros.
        client.AddParameter("id", id);
        client.AddParameter("otp", otp);

        // Resultado.
        var Content = await client.Post<ResponseBase>(cancellationToken: cancellationToken);

        // Retornar.
        return Content;

    }


    /// <summary>
    /// Remplazar el email.
    /// </summary>
    /// <param name="id">Id del perfil.</param>
    /// <param name="mail">Nuevo email.</param>
    /// <param name="cancellationToken">Token de cancelación</param>
    public static async Task<ResponseBase> ReplaceProfileMail(int id, string mail, CancellationToken cancellationToken = default)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("security/onCreating/replace/mail");

        // Parámetros.
        client.AddParameter("id", id);
        client.AddParameter("newEmail", mail);

        // Resultado.
        var Content = await client.Post<ResponseBase>(cancellationToken: cancellationToken);

        // Retornar.
        return Content;

    }

}