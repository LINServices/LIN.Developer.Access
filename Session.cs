﻿global using Global.Http.Services;
global using LIN.Types.Developer.Enumerations;
global using LIN.Types.Developer.Models;
global using LIN.Types.Responses;
global using System.Threading.Tasks;

namespace LIN.Access.Developer;

public sealed class Session
{

    /// <summary>
    /// Token de acceso.
    /// </summary>
    public string Token { get; set; }


    /// <summary>
    /// Información del usuario
    /// </summary>
    public ProfileDataModel? Information { get; private set; } = new();


    /// <summary>
    /// Información del usuario
    /// </summary>
    public Types.Cloud.Identity.Models.AccountModel Account { get; private set; } = new();


    /// <summary>
    /// Token de identidad.
    /// </summary>
    public string AccountToken { get; set; }


    /// <summary>
    /// Si la sesión es activa
    /// </summary>
    public static bool IsAccountOpen => Instance.Account.Id > 0;


    /// <summary>
    /// Si la sesión es activa
    /// </summary>
    public static bool IsDevOpen => Instance.Information?.Id > 0;


    /// <summary>
    /// Recarga o inicia una sesión
    /// </summary>
    public static async Task<(Session? Sesion, Responses Response)> LoginWith(string user, string password)
    {

        // Cierra la sesión Actual
        CloseSession();

        // Validación de user
        var response = await Controllers.Authentication.Login(user, password);


        if (response.Response != Responses.Success)
            return (null, response.Response);

        // Datos de la instancia.
        Instance.Information = response.Model.Profile;
        Instance.Account = response.Model.Account;

        Instance.Token = response.Token;
        Instance.AccountToken = response.Model.TokenCollection["identity"];

        return (Instance, Responses.Success);

    }


    /// <summary>
    /// Recarga o inicia una sesión
    /// </summary>
    public static async Task<(Session? Sesion, Responses Response)> LoginWith(string token)
    {

        // Cierra la sesión Actual
        CloseSession();

        // Validación de user
        var response = await Controllers.Authentication.Login(token);


        if (response.Response != Responses.Success)
            return (null, response.Response);


        // Datos de la instancia
        Instance.Information = response.Model.Profile;
        Instance.Account = response.Model.Account;

        Instance.Token = response.Token;
        Instance.AccountToken = response.Model.TokenCollection["identity"];

        return (Instance, Responses.Success);

    }


    /// <summary>
    /// Cierra la sesión
    /// </summary>
    public static void CloseSession()
    {
        Instance.Information = new();
        Instance.Account = new();
    }


    //==================== Singleton ====================//


    private static readonly Session _instance = new();

    private Session()
    {
        Information = new();
    }


    public static Session Instance => _instance;
}