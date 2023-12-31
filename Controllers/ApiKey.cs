﻿namespace LIN.Access.Developer.Controllers;


public static class ApiKey
{


    /// <summary>
    /// Crea una api key
    /// </summary>
    /// <param name="modelo">Modelo</param>
    /// <param name="token">Token de acceso</param>
    public static async Task<CreateResponse> Create(KeyModel modelo, string token)
    {

        // Variables
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("token", token);

        var url = ApiServer.PathURL("apikey/create");
        var json = JsonSerializer.Serialize(modelo);

        try
        {
            // Contenido
            StringContent content = new(json, Encoding.UTF8, "application/json");

            // Envia la solicitud
            var response = await client.PostAsync(url, content);

            // Lee la respuesta del servidor
            var responseContent = await response.Content.ReadAsStringAsync();

            var obj = JsonSerializer.Deserialize<CreateResponse>(responseContent);

            return obj ?? new();

        }
        catch
        {
        }

        return new();

    }



    /// <summary>
    /// Obtiene las llaves asociadas a un proyecto
    /// </summary>
    /// <param name="id">ID del proyecto</param>
    /// <param name="token">Token de acceso</param>
    public static async Task<ReadAllResponse<KeyModel>> ReadAll(int id, string token)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        var url = ApiServer.PathURL("apiKey/read/all");

        // Crear HttpRequestMessage y agregar el encabezado
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("id", $"{id}");
        request.Headers.Add("token", token);

        try
        {

            // Hacer la solicitud GET
            var response = await httpClient.SendAsync(request);

            // Leer la respuesta como una cadena
            var responseBody = await response.Content.ReadAsStringAsync();


            var obj = JsonSerializer.Deserialize<ReadAllResponse<KeyModel>>(responseBody);

            return obj ?? new();


        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {e.Message}");
        }


        return new();
    }



    /// <summary>
    /// Cambia el estado de una llave
    /// </summary>
    /// <param name="id">ID de la llave</param>
    /// <param name="estado">Nuevo estado</param>
    /// <param name="token">Token de acceso</param>
    /// <returns></returns>
    public static async Task<ResponseBase> ChangeState(int id, ApiKeyStatus estado, string token)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        var url = ApiServer.PathURL("apiKey/update/State");


        // Crear HttpRequestMessage y agregar el encabezado
        var request = new HttpRequestMessage(HttpMethod.Patch, url);
        request.Headers.Add("key", $"{id}");
        request.Headers.Add("estado", $"{(int)estado}");
        request.Headers.Add("token", token);

        try
        {

            // Hacer la solicitud GET
            var response = await httpClient.SendAsync(request);

            // Leer la respuesta como una cadena
            var responseBody = await response.Content.ReadAsStringAsync();

            var obj = JsonSerializer.Deserialize<ResponseBase>(responseBody);

            return obj ?? new();

        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {e.Message}");
        }


        return new();





    }



    /// <summary>
    /// Generar uso a una llave
    /// </summary>
    /// <param name="modelo">Modelo</param>
    /// <param name="key">LLave</param>
    public static async Task<CreateResponse> GenerateUse(KeyModel modelo, string key)
    {

        // Variables
        var client = new HttpClient();

        var url = ApiServer.PathURL("key/uses/create");
        var json = JsonSerializer.Serialize(modelo);
        client.DefaultRequestHeaders.Add("apiKey", key);


        try
        {
            // Contenido
            StringContent content = new(json, Encoding.UTF8, "application/json");

            // Envia la solicitud 
            var response = await client.PostAsync(url, content);

            // Lee la respuesta del servidor
            var responseContent = await response.Content.ReadAsStringAsync();

            var obj = JsonSerializer.Deserialize<CreateResponse>(responseContent);

            return obj ?? new();

        }
        catch
        {
        }

        return new();

    }


}