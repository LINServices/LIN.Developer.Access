
namespace LIN.Access.Developer.Controllers;


public static class Profile
{


    /// <summary>
    /// Crea un nuevo perfil
    /// </summary>
    /// <param name="modelo">Modelo</param>
    public static async Task<CreateResponse> Generate(ProfileDataModel modelo)
    {

        // Variables
        var client = new HttpClient();

        var url = ApiServer.PathURL("profile/create");
        var json = JsonSerializer.Serialize(modelo);

        try
        {
            // Contenido
            StringContent content = new(json, Encoding.UTF8, "application/json");

            // Envía la solicitud
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
    /// Valida un OTP
    /// </summary>
    /// <param name="id">ID del perfil</param>
    /// <param name="otp">Código OTP</param>
    public static async Task<ResponseBase> ValidateOTP(int id, string otp)
    {

        // Variables
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("id", id.ToString());
        client.DefaultRequestHeaders.Add("otp", otp);

        var url = ApiServer.PathURL("profile/security/validate/otp");

        try
        {
            // Contenido
            StringContent content = new(string.Empty, Encoding.UTF8, "application/json");

            // Envía la solicitud
            var response = await client.PostAsync(url, content);

            // Lee la respuesta del servidor
            var responseContent = await response.Content.ReadAsStringAsync();

            var obj = JsonSerializer.Deserialize<ResponseBase>(responseContent);

            return obj ?? new();

        }
        catch
        {
        }

        return new();

    }












    /// <summary>
    /// Inicia una sesion
    /// </summary>
    public static async Task<ReadOneResponse<Types.Cloud.Identity.Abstracts.AuthModel<ProfileDataModel>>> Login(string cuenta, string password)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        var url = ApiServer.PathURL("authentication/login");


        url = Web.AddParameters(url, new()
        {
            {
                "user", cuenta
            },
            {
                "password", password
            }
        });


        try
        {

            // Hacer la solicitud GET
            var response = await httpClient.GetAsync(url);

            // Leer la respuesta como una cadena
            var responseBody = await response.Content.ReadAsStringAsync();

            var obj = JsonSerializer.Deserialize<ReadOneResponse<Types.Cloud.Identity.Abstracts.AuthModel<ProfileDataModel>>>(responseBody);

            return obj ?? new();

        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {e.Message}");
        }


        return new();





    }




    /// <summary>
    /// Inicia una sesion
    /// </summary>
    public static async Task<ReadOneResponse<Types.Cloud.Identity.Abstracts.AuthModel<ProfileDataModel>>> Login(string token)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        var url = ApiServer.PathURL("authentication/login/token");


        url = Web.AddParameters(url, new()
        {
            {
                "token", token
            }
        });


        try
        {

            // Hacer la solicitud GET
            var response = await httpClient.GetAsync(url);

            // Leer la respuesta como una cadena
            var responseBody = await response.Content.ReadAsStringAsync();

            var obj = JsonSerializer.Deserialize<ReadOneResponse<Types.Cloud.Identity.Abstracts.AuthModel<ProfileDataModel>>>(responseBody);

            return obj ?? new();

        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {e.Message}");
        }


        return new();





    }


















    public static async Task<ResponseBase> ReplaceProfileMail(int id, string mail)
    {

        // Variables
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("id", id.ToString());

        var url = ApiServer.PathURL("profile/security/onCreating/replace/mail");

        url = Web.AddParameters(url, new()
        {
            {
                "newEmail", mail
            }
        });

        try
        {
            // Contenido
            StringContent content = new(string.Empty, Encoding.UTF8, "application/json");

            // Envia la solicitud
            var response = await client.PostAsync(url, content);

            // Lee la respuesta del servidor
            var responseContent = await response.Content.ReadAsStringAsync();

            var obj = JsonSerializer.Deserialize<ResponseBase>(responseContent);

            return obj ?? new();

        }
        catch
        {
        }

        return new();

    }

















    public static async Task<ReadOneResponse<ProfileDataModel>> ReadOneAsync(int id)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        var url = ApiServer.PathURL("profile/read");

        // Crear HttpRequestMessage y agregar el encabezado
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("id", $"{id}");

        try
        {

            // Hacer la solicitud GET
            var response = await httpClient.SendAsync(request);

            // Leer la respuesta como una cadena
            var responseBody = await response.Content.ReadAsStringAsync();


            var obj = JsonSerializer.Deserialize<ReadOneResponse<ProfileDataModel>>(responseBody);

            return obj ?? new();


        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {e.Message}");
        }


        return new();
    }


    public static async Task<ReadOneResponse<bool>> HasProfile(int id)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        var url = ApiServer.PathURL("profile/haveFor");


        // Crear HttpRequestMessage y agregar el encabezado
        var request = new HttpRequestMessage(HttpMethod.Get, url);

        request.Headers.Add("id", $"{id}");

        try
        {

            // Hacer la solicitud GET
            var response = await httpClient.SendAsync(request);

            // Leer la respuesta como una cadena
            var responseBody = await response.Content.ReadAsStringAsync();

            var obj = JsonSerializer.Deserialize<ReadOneResponse<bool>>(responseBody);

            return obj ?? new();

        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {e.Message}");
        }


        return new();





    }



    public static async Task<ReadOneResponse<ProfileDataModel>> Find(int id)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        var url = ApiServer.PathURL("profile/find");


        // Crear HttpRequestMessage y agregar el encabezado
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("id", $"{id}");

        try
        {

            // Hacer la solicitud GET
            var response = await httpClient.SendAsync(request);

            // Leer la respuesta como una cadena
            var responseBody = await response.Content.ReadAsStringAsync();

            var obj = JsonSerializer.Deserialize<ReadOneResponse<ProfileDataModel>>(responseBody);

            return obj ?? new();

        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {e.Message}");
        }


        return new();





    }




    public static async Task<ResponseBase> GenerateCobro(string token, decimal ammount)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        var url = ApiServer.PathURL("billing/generate");


        // Crear HttpRequestMessage y agregar el encabezado
        var request = new HttpRequestMessage(HttpMethod.Post, url);

        request.Headers.Add("token", $"{token}");
        request.Headers.Add("amount", $"{ammount}");

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





    public static async Task<ReadAllResponse<TransactionDataModel>> ReadAllAsync(int id, string token)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        var url = ApiServer.PathURL("billing/read/all");

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


            var obj = JsonSerializer.Deserialize<ReadAllResponse<TransactionDataModel>>(responseBody);

            return obj ?? new();


        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {e.Message}");
        }


        return new();
    }




}