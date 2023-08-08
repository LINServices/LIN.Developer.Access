namespace LIN.Access.Developer.Controllers;


public static class ApiKey
{


    public async static Task<CreateResponse> Create(ApiKeyDataModel modelo)
    {

        // Variables
        var client = new HttpClient();

        string url = ApiServer.PathURL("apikey/create");
        string json = JsonConvert.SerializeObject(modelo);

        try
        {
            // Contenido
            StringContent content = new(json, Encoding.UTF8, "application/json");

            // Envia la solicitud
            HttpResponseMessage response = await client.PostAsync(url, content);

            // Lee la respuesta del servidor
            string responseContent = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<CreateResponse>(responseContent);

            return obj ?? new();

        }
        catch
        {
        }

        return new();

    }



    public async static Task<ReadAllResponse<ApiKeyDataModel>> ReadAll(int id)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        string url = ApiServer.PathURL("apiKey/read/all");

        // Crear HttpRequestMessage y agregar el encabezado
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("id", $"{id}");

        try
        {

            // Hacer la solicitud GET
            HttpResponseMessage response = await httpClient.SendAsync(request);

            // Leer la respuesta como una cadena
            string responseBody = await response.Content.ReadAsStringAsync();


            var obj = JsonConvert.DeserializeObject<ReadAllResponse<ApiKeyDataModel>>(responseBody);

            return obj ?? new();


        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {e.Message}");
        }


        return new();
    }







    public async static Task<ResponseBase> ChangeState(int id, ApiKeyStatus estado)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        string url = ApiServer.PathURL("apiKey/update/State");


        // Crear HttpRequestMessage y agregar el encabezado
        var request = new HttpRequestMessage(HttpMethod.Patch, url);
        request.Headers.Add("key", $"{id}");
        request.Headers.Add("estado", $"{(int)estado}");

        try
        {

            // Hacer la solicitud GET
            var response = await httpClient.SendAsync(request);

            // Leer la respuesta como una cadena
            string responseBody = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<ResponseBase>(responseBody);

            return obj ?? new();

        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {e.Message}");
        }


        return new();





    }



    public async static Task<CreateResponse> GenerateUse(ApiKeyUsesDataModel modelo, string key)
    {

        // Variables
        var client = new HttpClient();

        string url = ApiServer.PathURL("key/uses/create");
        string json = JsonConvert.SerializeObject(modelo);
        client.DefaultRequestHeaders.Add("apiKey", key);


        try
        {
            // Contenido
            StringContent content = new(json, Encoding.UTF8, "application/json");

            // Envia la solicitud 
            HttpResponseMessage response = await client.PostAsync(url, content);

            // Lee la respuesta del servidor
            string responseContent = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<CreateResponse>(responseContent);

            return obj ?? new();

        }
        catch
        {
        }

        return new();

    }



}
