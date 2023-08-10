namespace LIN.Access.Developer.Controllers;


public class Server
{


    public static async Task<bool> IsRunning()
    {
        try
        {

            var client = new HttpClient();
            var responseHttp = await client.GetAsync(ApiServer.PathURL("status"));

            return responseHttp.IsSuccessStatusCode;
        }
        catch { }

        return false;
    }

}
