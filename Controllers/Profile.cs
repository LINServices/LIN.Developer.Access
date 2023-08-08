namespace LIN.Access.Developer.Controllers;


public static class Profile
{


    /// <summary>
    /// Crea un nuevo perfil
    /// </summary>
    /// <param name="modelo">Modelo</param>
    public async static Task<CreateResponse> Generate(ProfileDataModel modelo)
    {

        // Variables
        var client = new HttpClient();

        string url = ApiServer.PathURL("profile/create");
        string json = JsonConvert.SerializeObject(modelo);

        try
        {
            // Contenido
            StringContent content = new(json, Encoding.UTF8, "application/json");

            // Envía la solicitud
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
    /// Valida un OTP
    /// </summary>
    /// <param name="id">ID del perfil</param>
    /// <param name="otp">Código OTP</param>
    public async static Task<ResponseBase> ValidateOTP(int id, string otp)
    {

        // Variables
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("id", id.ToString());
        client.DefaultRequestHeaders.Add("otp", otp);

        string url = ApiServer.PathURL("profile/security/validate/otp");

        try
        {
            // Contenido
            StringContent content = new(string.Empty, Encoding.UTF8, "application/json");

            // Envía la solicitud
            HttpResponseMessage response = await client.PostAsync(url, content);

            // Lee la respuesta del servidor
            string responseContent = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<ResponseBase>(responseContent);

            return obj ?? new();

        }
        catch
        {
        }

        return new();

    }









    public async static Task<ResponseBase> ReplaceProfileMail(int id, string mail)
    {

        // Variables
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("id", id.ToString());

        string url = ApiServer.PathURL("profile/security/onCreating/replace/mail");

        url = Web.AddParameters(url, new()
        {
            { "newEmail", mail }
        });

        try
        {
            // Contenido
            StringContent content = new(string.Empty, Encoding.UTF8, "application/json");

            // Envia la solicitud
            HttpResponseMessage response = await client.PostAsync(url, content);

            // Lee la respuesta del servidor
            string responseContent = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<ResponseBase>(responseContent);

            return obj ?? new();

        }
        catch
        {
        }

        return new();

    }

















    public async static Task<ReadOneResponse<ProfileDataModel>> ReadOneAsync(int id)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        string url = ApiServer.PathURL("profile/read");

        // Crear HttpRequestMessage y agregar el encabezado
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("id", $"{id}");

        try
        {

            // Hacer la solicitud GET
            HttpResponseMessage response = await httpClient.SendAsync(request);

            // Leer la respuesta como una cadena
            string responseBody = await response.Content.ReadAsStringAsync();


            var obj = JsonConvert.DeserializeObject<ReadOneResponse<ProfileDataModel>>(responseBody);

            return obj ?? new();


        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {e.Message}");
        }


        return new();
    }


    public async static Task<ReadOneResponse<bool>> HasProfile(int id)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        string url = ApiServer.PathURL("profile/haveFor");


        // Crear HttpRequestMessage y agregar el encabezado
        var request = new HttpRequestMessage(HttpMethod.Get, url);

        request.Headers.Add("id", $"{id}");

        try
        {

            // Hacer la solicitud GET
            var response = await httpClient.SendAsync(request);

            // Leer la respuesta como una cadena
            string responseBody = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<ReadOneResponse<bool>>(responseBody);

            return obj ?? new();

        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {e.Message}");
        }


        return new();





    }



    public async static Task<ReadOneResponse<ProfileDataModel>> Find(int id)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        string url = ApiServer.PathURL("profile/find");


        // Crear HttpRequestMessage y agregar el encabezado
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("id", $"{id}");

        try
        {

            // Hacer la solicitud GET
            var response = await httpClient.SendAsync(request);

            // Leer la respuesta como una cadena
            string responseBody = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<ReadOneResponse<ProfileDataModel>>(responseBody);

            return obj ?? new();

        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {e.Message}");
        }


        return new();





    }




    public async static Task<ResponseBase> GenerateCobro(string token, decimal ammount)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        string url = ApiServer.PathURL("billing/generate");


        // Crear HttpRequestMessage y agregar el encabezado
        var request = new HttpRequestMessage(HttpMethod.Post, url);

        request.Headers.Add("token", $"{token}");
        request.Headers.Add("amount", $"{ammount}");

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





    public async static Task<ReadAllResponse<TransactionDataModel>> ReadAllAsync(int id)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        string url = ApiServer.PathURL("billing/read/all");

        // Crear HttpRequestMessage y agregar el encabezado
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("id", $"{id}");

        try
        {

            // Hacer la solicitud GET
            HttpResponseMessage response = await httpClient.SendAsync(request);

            // Leer la respuesta como una cadena
            string responseBody = await response.Content.ReadAsStringAsync();


            var obj = JsonConvert.DeserializeObject<ReadAllResponse<TransactionDataModel>>(responseBody);

            return obj ?? new();


        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {e.Message}");
        }


        return new();
    }




}
