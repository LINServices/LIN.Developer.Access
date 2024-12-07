namespace LIN.Access.Developer;

internal class Service
{

    /// <summary>
    /// Servicio.
    /// </summary>

    public static Global.Http.Service _Service = new();


    /// <summary>
    /// Obtener un cliente.
    /// </summary>
    public static Client GetClient(string url) => _Service.GetClient(url);

}