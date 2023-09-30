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

        // Variables
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("apiKey", key);

        var url = ApiServer.PathURL("IA/predict/sentiment");
        var json = JsonConvert.SerializeObject(value);

        try
        {
            // Contenido
            StringContent content = new(json, Encoding.UTF8, "application/json");

            // Envia la solicitud
            var response = await client.PostAsync(url, content);

            // Lee la respuesta del servidor
            var responseContent = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<ReadOneResponse<Sentiments>>(responseContent) ?? new();

            return obj ?? new();

        }
        catch
        {
        }

        return new();

    }



    /// <summary>
    /// Utiliza la IA de sentimientos
    /// </summary>
    /// <param name="value">Valor a predecir</param>
    /// <param name="key">Llave</param>
    public static async Task<ReadOneResponse<Languajes>> LangIA(string value, string key)
    {

        // Variables
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("apiKey", key);


        var url = ApiServer.PathURL("IA/predict/lang");
        var json = JsonConvert.SerializeObject(value);

        try
        {
            // Contenido
            StringContent content = new(json, Encoding.UTF8, "application/json");

            // Envia la solicitud
            var response = await client.PostAsync(url, content);

            // Lee la respuesta del servidor
            var responseContent = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<ReadOneResponse<Languajes>>(responseContent) ?? new();

            return obj ?? new();

        }
        catch
        {
        }

        return new();

    }





    public static async Task<ReadOneResponse<CategorizeModel>> Categorizar(string value, string entry, PayWith payWith)
    {

        // Variables
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("access", entry);


        var url = ApiServer.PathURL($"IA/Categorize/predict/{(int)payWith}");
        var json = JsonConvert.SerializeObject(value);

        try
        {
            // Contenido
            StringContent content = new(json, Encoding.UTF8, "application/json");

            // Envia la solicitud
            var response = await client.PostAsync(url, content);

            // Lee la respuesta del servidor
            var responseContent = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<ReadOneResponse<CategorizeModel>>(responseContent) ?? new();

            return obj ?? new();

        }
        catch
        {
        }

        return new();

    }


}