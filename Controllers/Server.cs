using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIN.Access.Developer.Controllers;

public class Server
{


    public static async Task<bool> IsRunnig()
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
