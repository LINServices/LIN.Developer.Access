namespace LIN.Access.Developer.Controllers;


public static class FirewallRule
{


    /// <summary>
    /// Crea una regla de firewall
    /// </summary>
    /// <param name="modelo">Modelo de la regla</param>
    /// <param name="token">Token de acceso</param>
    public async static Task<CreateResponse> Create(FirewallRuleDataModel modelo, string token)
    {

        // Variables
        var client = new HttpClient();

        client.DefaultRequestHeaders.Add("token", token);

        string url = ApiServer.PathURL("firewallrules/create");
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



    /// <summary>
    /// Obtiene las reglas de firewall
    /// </summary>
    /// <param name="id">ID del proyecto</param>
    /// <param name="token">Token de acceso</param>
    public async static Task<ReadAllResponse<FirewallRuleDataModel>> ReadAllAsync(int id, string token)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        string url = ApiServer.PathURL("firewallrules/read/all");

        // Crear HttpRequestMessage y agregar el encabezado
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("id", $"{id}");
        request.Headers.Add("token", $"{token}");

        try
        {

            // Hacer la solicitud GET
            HttpResponseMessage response = await httpClient.SendAsync(request);

            // Leer la respuesta como una cadena
            string responseBody = await response.Content.ReadAsStringAsync();


            var obj = JsonConvert.DeserializeObject<ReadAllResponse<FirewallRuleDataModel>>(responseBody);

            return obj ?? new();


        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {e.Message}");
        }


        return new();
    }



    /// <summary>
    /// Elimina una regla de acceso
    /// </summary>
    /// <param name="id">ID de la regla</param>
    /// <param name="token">Token de acceso</param>
    public async static Task<ResponseBase> Delete(int id, string token)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        string url = ApiServer.PathURL("firewallrules/delete");

        // Crear HttpRequestMessage y agregar el encabezado
        var request = new HttpRequestMessage(HttpMethod.Delete, url);
        request.Headers.Add("id", $"{id}");
        request.Headers.Add("token", $"{token}");

        try
        {

            // Hacer la solicitud GET
            HttpResponseMessage response = await httpClient.SendAsync(request);

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



    /// <summary>
    /// Elimina los accesos bloqueados por el firewall
    /// </summary>
    /// <param name="id">id del proyecto</param>
    /// <param name="token">Token de acceso</param>
    public async static Task<ResponseBase> DeleteBasAccess(int id, string token)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        string url = ApiServer.PathURL("firewallrules/delete/bad");

        // Crear HttpRequestMessage y agregar el encabezado
        var request = new HttpRequestMessage(HttpMethod.Delete, url);
        request.Headers.Add("id", $"{id}");
        request.Headers.Add("token", $"{token}");

        try
        {

            // Hacer la solicitud GET
            HttpResponseMessage response = await httpClient.SendAsync(request);

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



    /// <summary>
    /// Obtiene todos los accesos bloqueados
    /// </summary>
    /// <param name="id">ID del proyecto</param>
    /// <param name="token">Token de acceso</param>
    public async static Task<ReadAllResponse<FirewallBlockLogDataModel>> ReadAllBad(int id, string token)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        string url = ApiServer.PathURL("firewallrules/read/bad");

        // Crear HttpRequestMessage y agregar el encabezado
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("id", $"{id}");
        request.Headers.Add("token", $"{token}");

        try
        {

            // Hacer la solicitud GET
            HttpResponseMessage response = await httpClient.SendAsync(request);

            // Leer la respuesta como una cadena
            string responseBody = await response.Content.ReadAsStringAsync();


            var obj = JsonConvert.DeserializeObject<ReadAllResponse<FirewallBlockLogDataModel>>(responseBody);

            return obj ?? new();


        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {e.Message}");
        }


        return new();
    }



}