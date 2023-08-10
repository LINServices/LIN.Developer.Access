global using Newtonsoft.Json;
global using System;
global using System.Net.Http;
global using System.Text;
global using System.Threading.Tasks;
global using LIN.Types.Developer.Enumerations;
global using LIN.Types.Developer.Models;
global using LIN.Shared.Tools;
global using LIN.Types.Responses;
global using LIN.Modules;

namespace LIN.Access.Developer;


public sealed class Session
{


    public string Token { get; set; }


    /// <summary>
    /// Información del usuario
    /// </summary>
    public ProfileDataModel Informacion { get; private set; }


    /// <summary>
    /// Información del usuario
    /// </summary>
    public LIN.Types.Auth.Models.AccountModel Account { get; private set; }



    /// <summary>
    /// Si la sesión es activa
    /// </summary>
    public static bool IsOpen { get; set; } = false;




    /// <summary>
    /// Recarga o inicia una sesión
    /// </summary>
    public static async Task<(Session? Sesion, Responses Response)> LoginWith(int id)
    {

        // Cierra la sesión Actual
        CloseSession();

        // Validación de user
        var response = await Controllers.Profile.ReadOneAsync(id);

        if (response.Response != Responses.Success)
            return (null, response.Response);


        // Datos de la instancia
        Instance.Informacion = response.Model;

        IsOpen = true;

        Instance.Token = response.Token;

        return (Instance, Responses.Success);

    }




    /// <summary>
    /// Cierra la sesión
    /// </summary>
    public static void CloseSession()
    {
        IsOpen = false;
        Instance.Informacion = new();
    }






    //==================== Singleton ====================//


    private readonly static Session _instance = new();

    private Session()
    {
        Informacion = new();
    }


    public static Session Instance => _instance;
}
