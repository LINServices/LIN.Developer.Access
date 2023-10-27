namespace LIN.Access.Developer.Controllers;


public static class Project
{


    /// <summary>
    /// Crea un nuevo proyecto
    /// </summary>
    /// <param name="modelo">Modelo del proyecto</param>
    /// <param name="token">Token de acceso</param>
    public static async Task<CreateResponse> Create(ProjectDataModel modelo, string token)
    {

        // Variables
        var client = new HttpClient();

        client.DefaultRequestHeaders.Add("token", token);

        var url = ApiServer.PathURL("project/create");
        var json = JsonConvert.SerializeObject(modelo);

        try
        {
            // Contenido
            StringContent content = new(json, Encoding.UTF8, "application/json");

            // Envía la solicitud
            var response = await client.PostAsync(url, content);

            // Lee la respuesta del servidor
            var responseContent = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<CreateResponse>(responseContent);

            return obj ?? new();

        }
        catch
        {
        }

        return new();

    }



    /// <summary>
    /// Obtiene los proyectos asociados a un perfil
    /// </summary>
    /// <param name="token">Token de acceso</param>
    public static async Task<ReadAllResponse<ProjectDataModel>> ReadAllAsync(string token, string tokenAuth)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        var url = ApiServer.PathURL("project/read/all");

        // Crear HttpRequestMessage y agregar el encabezado
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("token", $"{token}");
        request.Headers.Add("tokenAuth", $"{tokenAuth}");

        try
        {

            // Hacer la solicitud GET
            var response = await httpClient.SendAsync(request);

            // Leer la respuesta como una cadena
            var responseBody = await response.Content.ReadAsStringAsync();


            var obj = JsonConvert.DeserializeObject<ReadAllResponse<ProjectDataModel>>(responseBody);

            return obj ?? new();


        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {e.Message}");
        }


        return new();
    }



    /// <summary>
    /// Obtiene un proyecto
    /// </summary>
    /// <param name="id">ID del proyecto</param>
    /// <param name="token">Token de acceso</param>
    public static async Task<ReadOneResponse<ProjectDataModel>> ReadOne(int id, string token)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        var url = ApiServer.PathURL("project/read");

        // Crear HttpRequestMessage y agregar el encabezado
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("id", $"{id}");
        request.Headers.Add("token", $"{token}");

        try
        {

            // Hacer la solicitud GET
            var response = await httpClient.SendAsync(request);

            // Leer la respuesta como una cadena
            var responseBody = await response.Content.ReadAsStringAsync();


            var obj = JsonConvert.DeserializeObject<ReadOneResponse<ProjectDataModel>>(responseBody);

            return obj ?? new();


        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {e.Message}");
        }


        return new();
    }



    /// <summary>
    /// Elimina un proyecto
    /// </summary>
    /// <param name="id">ID del proyecto</param>
    /// <param name="token">Token de acceso</param>
    public static async Task<ReadOneResponse<bool>> Delete(int id, string token)
    {

        Console.WriteLine($"Consulta Update");

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        var url = ApiServer.PathURL("project/delete");

        // Crear HttpRequestMessage y agregar el encabezado
        var request = new HttpRequestMessage(HttpMethod.Delete, url);
        request.Headers.Add("id", $"{id}");
        request.Headers.Add("token", $"{token}");

        try
        {

            // Hacer la solicitud GET
            var response = await httpClient.SendAsync(request);

            // Leer la respuesta como una cadena
            var responseBody = await response.Content.ReadAsStringAsync();


            var obj = JsonConvert.DeserializeObject<ReadOneResponse<bool>>(responseBody);

            return obj ?? new();


        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {e.Message}");
        }


        return new();
    }



}