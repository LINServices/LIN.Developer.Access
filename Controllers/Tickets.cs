using LIN.Types.Developer.Enumerations.Tickets;
using LIN.Types.Developer.Models.Tickets;
using LIN.Types.Developer.TransactionModels.Tickets;

namespace LIN.Access.Developer.Controllers;

public static class Tickets
{

    public static async Task<CreateResponse> Create(TicketMongoModel modelo, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("tickets");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Post<CreateResponse>(modelo);

        // Retornar.
        return Content;

    }


    public static async Task<ReadAllResponse<TicketMongoModel>> ReadAll(string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("tickets/my-tickets");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<TicketMongoModel>>();

        // Retornar.
        return Content;

    }


    public static async Task<ResponseBase> Close(string id, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient($"tickets/close");

        // Headers.
        client.AddHeader("token", token);
        client.AddParameter("id", id);

        // Resultado.
        var Content = await client.Post<ResponseBase>();

        // Retornar.
        return Content;

    }


    public static async Task<ReadOneResponse<TicketDetailDto>> ReadOne(string id, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient($"tickets/{id}");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadOneResponse<TicketDetailDto>>();

        // Retornar.
        return Content;

    }



    public static async Task<ResponseBase> PostEvent(string ticket, AddTicketEventRequest evento, string token )
    {

        // Cliente HTTP.
        Client client = Service.GetClient($"tickets/{ticket}/events");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Post<ResponseBase>(evento);

        // Retornar.
        return Content;

    }


    public static async Task<ReadAllResponse<TicketEvent>> GetEvents(string ticket,string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient($"tickets/{ticket}/events");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<TicketEvent>>();

        // Retornar.
        return Content;

    }

}

public class AddTicketEventRequest
{
    public TicketEventType Type { get; set; }
    public string Message { get; set; } = string.Empty;
}

