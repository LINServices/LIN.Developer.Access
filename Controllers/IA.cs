namespace LIN.Access.Developer.Controllers;
using Types.Enumerations;

public class IA
{


    /// <summary>
    /// Utiliza la IA de sentimientos
    /// </summary>
    /// <param name="value">Valor a predecir</param>
    /// <param name="key">Llave</param>
    public static async Task<ReadOneResponse<Sentiments>> SentimentIA(string value, string key)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("IA/predict/sentiment");

        // Headers.
        client.AddHeader("key", key);

        // Resultado.
        var Content = await client.Post<ReadOneResponse<Sentiments>>(value);

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Utiliza la IA de sentimientos
    /// </summary>
    /// <param name="value">Valor a predecir</param>
    /// <param name="key">Llave</param>
    public static async Task<ReadOneResponse<Languajes>> LangIA(string value, string key)
    {
        // Cliente HTTP.
        Client client = Service.GetClient("IA/predict/lang");

        // Headers.
        client.AddHeader("key", key);

        // Resultado.
        var Content = await client.Post<ReadOneResponse<Languajes>>(value);

        // Retornar.
        return Content;

    }




}