namespace LIN.Access.Developer.Controllers;

public class PDF
{

    /// <summary>
    /// Convierte un html a PDF
    /// </summary>
    /// <param name="html">HTML</param>
    public static async Task<PDFResponse> ConvertHTML(string html)
    {

        try
        {
            HttpClient client = new();
            var json = JsonSerializer.Serialize(html);

            StringContent content = new(json, Encoding.UTF8, "application/json");

            var response = await (await client.PostAsync("https://linpdf.azurewebsites.net/convert", content)).Content.ReadAsStringAsync();

            var obj = JsonSerializer.Deserialize<PDFResponse>(response) ?? new();



            return obj;
        }
        catch
        {

        }
        return new();
    }

}