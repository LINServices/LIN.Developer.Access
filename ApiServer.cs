global using LIN.Developer.Types.Models;
global using LIN.Shared.Responses;

namespace LIN.Access.Developer;

public static class ApiServer
{
    private static bool IsSeted = false;
    private static string SetedUrl = "";

    public static string GetURL
    {
        get
        {
            if (IsSeted)
                return SetedUrl;

return "http://lindevelopers.somee.com/";
            return "https://lindeveloper.azurewebsites.net/";
            return "https://localhost:7020/";
            

        }
    }



    public static void SetUrl(string url)
    {
        IsSeted = true;
        SetedUrl = url;
    }


    public static string PathURL(string value)
    {
        return GetURL + value;
    }


}
