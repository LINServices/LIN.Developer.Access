namespace LIN.Access.Developer.Controllers;


public class IA
{


    /// <summary>
    /// Utiliza la IA de sentimientos
    /// </summary>
    /// <param name="value">Valor a predecir</param>
    /// <param name="key">Llave</param>
    public async static Task<ReadOneResponse<Shared.Enumerations.Sentiment>> SentimentIA(string value, string key)
    {

        // Variables
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("apiKey", key);

        string url = ApiServer.PathURL("IA/predict/sentiment");
        string json = JsonConvert.SerializeObject(value);

        try
        {
            // Contenido
            StringContent content = new(json, Encoding.UTF8, "application/json");

            // Envia la solicitud
            HttpResponseMessage response = await client.PostAsync(url, content);

            // Lee la respuesta del servidor
            string responseContent = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<ReadOneResponse<Shared.Enumerations.Sentiment>>(responseContent) ?? new();

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
    public async static Task<ReadOneResponse<Shared.Enumerations.LangEnum>> LangIA(string value, string key)
    {

        // Variables
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("apiKey", key);


        string url = ApiServer.PathURL("IA/predict/lang");
        string json = JsonConvert.SerializeObject(value);

        try
        {
            // Contenido
            StringContent content = new(json, Encoding.UTF8, "application/json");

            // Envia la solicitud
            HttpResponseMessage response = await client.PostAsync(url, content);

            // Lee la respuesta del servidor
            string responseContent = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<ReadOneResponse<Shared.Enumerations.LangEnum>>(responseContent) ?? new();

            return obj ?? new();

        }
        catch
        {
        }

        return new();

    }





    public async static Task<ReadOneResponse<CategorizeModel>> Categorizar(string value, string entry, PayWith payWith)
    {

        // Variables
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("access", entry);


        string url = ApiServer.PathURL($"IA/Categorize/predict/{(int)payWith}");
        string json = JsonConvert.SerializeObject(value);

        try
        {
            // Contenido
            StringContent content = new(json, Encoding.UTF8, "application/json");

            // Envia la solicitud
            HttpResponseMessage response = await client.PostAsync(url, content);

            // Lee la respuesta del servidor
            string responseContent = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<ReadOneResponse<CategorizeModel>>(responseContent) ?? new();

            return obj ?? new();

        }
        catch
        {
        }

        return new();

    }


}