using Microsoft.Extensions.DependencyInjection;

namespace LIN.Access.Developer;

public static class Build
{
    /// <summary>
    /// Autenticación de la aplicación.
    /// </summary>
    internal static string Application { get; set; } = string.Empty;

    /// <summary>
    /// Utilizar LIN Authentication.
    /// </summary>
    /// <param name="app">Aplicación.</param>
    /// <param name="url">Ruta.</param>
    /// <param name="adminUrl">Ruta del servicio de administración (LIN.Cloud.Orchestrator.Admin).</param>
    public static IServiceCollection AddDeveloperService(this IServiceCollection service, string? url = null, string? app = null, string? adminUrl = null)
    {
        Service._Service = new();
        Service._Service.SetDefault(url ?? "https://api.linplatform.com/Developer/");
        Service._AdminService = new();
        Service._AdminService.SetDefault(adminUrl ?? "https://api.linplatform.com/admin/developer/");
        Application = app ?? "default";
        return service;
    }
}