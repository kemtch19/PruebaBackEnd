using System.Text;
using System.Text.Json;
using Prueba.Models;


namespace Prueba.AddControllers
{
  public class MailController
  {
    public async void EnviarCorreo(string email, string student, string teacher, string course, DateOnly? enrollment)
    {
      try
      {
        string url = "https://api.mailersend.com/v1/email";

        string jwtToken = "mlsn.638da9525b2a1268411ed4600ca146d89ee6115af0d802dd816768551d7b26f5";

        var EmailMessage = new Email
        {
          from = new From { email = "MS_GXlEIi@trial-jpzkmgqy0dyl059v.mlsender.net" },
          to = [
                new To { email = email }
            ],
          subject = "Matricula Success",
          text = $"Hola, {student} haz matriculado el curso {course} con el profesor {teacher} y la fecha de tu matricula es {enrollment}",
        };

        string jsonBody = JsonSerializer.Serialize(EmailMessage);

        using (HttpClient client = new HttpClient())
        {
          client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwtToken}");

          StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

          HttpResponseMessage response = await client.PostAsync(url, content);

          if (response.IsSuccessStatusCode)
          {
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Respuesta del servidor:");
            Console.WriteLine(responseBody);
            Console.WriteLine($"Se mandó correctamente el correo a {email} con el asunto: {EmailMessage.text}");
          }
          else
          {
            Console.WriteLine($"La solicitud falló: {response.StatusCode}");
            Console.WriteLine(response);
          }
        }
      }
      catch
      {
        
      }
    }
  }
}