namespace LIN.Access.Developer;

internal class Service
{
    /// <summary>
    /// Servicio.
    /// </summary>

    public static Global.Http.Service _Service = new();

    /// <summary>
    /// Servicio de administración (LIN.Cloud.Orchestrator.Admin).
    /// </summary>
    public static Global.Http.Service _AdminService = new();

    /// <summary>
    /// Obtener un cliente.
    /// </summary>
    public static Client GetClient(string url) => _Service.GetClient(url);

    /// <summary>
    /// Obtener un cliente del servicio de administración.
    /// </summary>
    public static Client GetAdminClient(string url) => _AdminService.GetClient(url);

}